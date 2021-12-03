//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Threading;
using Eiffel.RabbitMq.Client.Exceptions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Eiffel.RabbitMq.Client.Common
{
    internal class RabbitMqWrapper : IRabbitMqWrapper
    {
        #region Fields

        private readonly IModel _channel;
        private readonly RabbitMqConfig _config;
        private readonly IConnection _connection;
        private EventingBasicConsumer _consumer;
        private bool _disposed;

        #endregion

        public RabbitMqWrapper(RabbitMqConfig rabbitMqConfig, int connectionRetries = 10)
        {
            try
            {
                _connection = InitConnection(rabbitMqConfig, connectionRetries);
                _channel = CreateChannel(_connection);
                _config = rabbitMqConfig;
            }
            catch (Exception e)
            {
                throw new RabbitMqException("An error occured while initializing RabbitMQ client", e);
            }
        }

        #region private methods

        /// <summary>
        /// Initialize connection to RabbitMQ
        /// </summary>
        /// <param name="rabbitMqConfig"></param>
        /// <param name="connectionRetries">Number of connection retries</param>
        /// <param name="connectionShutdownHandler">The event invoked when connection closed</param>
        /// <returns></returns>
        /// <exception cref="BrokerUnreachableException">Can not establish connection to RabbitMq service</exception>
        /// <exception cref="Exception">General exception</exception>
        private IConnection InitConnection(RabbitMqConfig rabbitMqConfig,
            int connectionRetries = 10, EventHandler<ShutdownEventArgs> connectionShutdownHandler = null)
        {
            ValidateRabbitMqConfig(rabbitMqConfig);

            var factory = new ConnectionFactory
            {
                HostName = rabbitMqConfig.HostName,
                UserName = rabbitMqConfig.UserName,
                Password = rabbitMqConfig.Password,
                Port = rabbitMqConfig.Port
            };

            var isOpen = false;
            var count = 0;
            while (!isOpen && count < connectionRetries)
            {
                try
                {
                    factory.AutomaticRecoveryEnabled = true;
                    factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);
                    // create connection  
                    var connection = factory.CreateConnection();
                    isOpen = true;
                    connection.ConnectionShutdown += connectionShutdownHandler;
                    return connection;
                }
                catch (BrokerUnreachableException unreachableException)
                {
                    if (count < connectionRetries)
                        Thread.Sleep(2000);
                    else
                        throw new RabbitMqException("Can't establish connection with RabbitMQ instance.",
                            unreachableException);
                }

                count++;
            }

            return null;
        }

        /// <summary>
        /// Initiate RabbitMQ channel
        /// </summary>
        /// <param name="connection">RabbitMQ connection</param>
        /// <returns></returns>
        private IModel CreateChannel(IConnection connection)
        {
            if (connection != null)
            {
                IModel channel = connection.CreateModel();
                return channel;
            }
            else
                throw new RabbitMqException("Can't establish connection with RabbitMQ instance.");
        }

        /// <summary>
        /// Create RabbitMQ exchange if it wasn't found.
        /// </summary>
        /// <param name="exchangeName">Exchange name to be created</param>
        private void DeclareExchange(string exchangeName)
        {
            DeclareExchange(exchangeName, ExchangeType.Topic, true);
        }

        /// <summary>
        /// Create RabbitMQ exchange if it wasn't found.
        /// </summary>
        /// <param name="exchangeName">Exchange name to be created</param>
        /// <param name="exchangeType">exchangeType Direct, Topic, Fanout, Headers</param>
        /// <param name="durable"></param>
        private void DeclareExchange(string exchangeName, string exchangeType, bool durable)
        {
            _channel.ExchangeDeclare(exchangeName, exchangeType, durable);
        }

        /// <summary>
        /// Create a queue if it wasn't exist and bind it to specified exchange using specified routing key
        /// </summary>
        /// <param name="queueName">Queue name to be created</param>
        /// <param name="exchangeName">Exchange to be binded with created queue</param>
        /// <param name="routingKey">Routing key used to bind created queue to exchange</param>
        /// <returns></returns>
        private void DeclareAndBindQueue(string queueName, string exchangeName, string routingKey)
        {
            //Declare the Queue
            var createdQueue =
                _channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: true, null);
            //Bind the Queue to the Exchange
            _channel.QueueBind(createdQueue.QueueName, exchangeName, routingKey, null);
            _channel.BasicQos(0, 1, false);
        }

        /// <summary>
        /// Broadcast a message on the given queue channel
        /// </summary>
        /// <param name="exchange">Exchange name</param>
        /// <param name="routingKey">Routing key</param>
        /// <param name="body">Message body as array of bytes</param>
        /// <returns></returns>
        private bool SendMessage(string exchange, string routingKey, byte[] body)
        {
            if (!_channel.IsOpen) return false; //Todo: We shall add logging
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: properties,
                body: body
            );

            return true;
        }
        
        /// <summary>
        /// Add event handler to be executed after receive message/event.
        /// </summary>
        /// <param name="eventHandler">method or code block to be executed after receive message/event.</param>
        private void AddReceivingHandler(EventHandler<BasicDeliverEventArgs> eventHandler)
        {
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += eventHandler;
        }


        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _channel?.Close();
                _connection?.Close();
            }

            _disposed = true;
        }

        /// <summary>
        /// Validates RabbitMqConfig.
        /// </summary>
        /// <param name="rabbitMqConfig"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private static void ValidateRabbitMqConfig(RabbitMqConfig rabbitMqConfig)
        {
            if (rabbitMqConfig == null)
                throw new RabbitMqNullArgumentException(nameof(rabbitMqConfig));

            if (string.IsNullOrWhiteSpace(rabbitMqConfig.HostName))
            {
                throw new RabbitMqNullArgumentException(nameof(rabbitMqConfig.HostName));
            }

            if (string.IsNullOrWhiteSpace(rabbitMqConfig.UserName))
            {
                throw new RabbitMqNullArgumentException(nameof(rabbitMqConfig.UserName));
            }

            if (string.IsNullOrWhiteSpace(rabbitMqConfig.Password))
            {
                throw new RabbitMqNullArgumentException(nameof(rabbitMqConfig.Password));
            }

            if (rabbitMqConfig.Port == default)
            {
                throw new RabbitMqNullArgumentException(nameof(rabbitMqConfig.Port));
            }
        }

        #endregion

        #region public  methods

        ///  <inheritdoc/>
        public void CreateQueue(string queueName, string routingKey)
        {
            DeclareExchange(_config.ExchangeName);
            DeclareAndBindQueue(queueName, _config.ExchangeName, routingKey);
        }
     
        ///  <inheritdoc/>
        public bool Publish(string routingKey, byte[] body)
        {
            DeclareExchange(_config.ExchangeName);

            return SendMessage(_config.ExchangeName, routingKey, body);
        }

        /// <inheritdoc/>
        public void Ack(ulong deliveryTag)
        {
            try
            {
                _channel.BasicAck(deliveryTag, multiple: false);
            }
            catch (Exception e)
            {
                throw new RabbitMqException($"Error occurred while ack {deliveryTag}", e);
            }
        }

        /// <inheritdoc/>
        public void Reject(ulong deliveryTag, bool requeue)
        {
            try
            {
                _channel.BasicReject(deliveryTag, requeue);
            }
            catch (Exception e)
            {
                throw new RabbitMqException($"Error occurred while rejecting {deliveryTag}", e);
            }
        }

        /// <inheritdoc/>
        public void Unsubscribe(string subscriptionId)
        {
            try
            {
                _channel.BasicCancel(subscriptionId);
            }
            catch (Exception e)
            {
                throw new RabbitMqException($"Error occurred while unsubscribing {subscriptionId}", e);
            }
        }

        ///  <inheritdoc/>
        public string Consume(string queueName, EventHandler<BasicDeliverEventArgs> eventHandler)
        {
            AddReceivingHandler(eventHandler);
            return _channel.BasicConsume(queueName, false, _consumer);
        }


        /// <inheritdoc/>
        public string GetRoutingKey(string eventType)
        {
            return $"{RabbitMqConstants.EiffelRoutingKeyFirstSegment}._.{eventType}._._";
        }

        public void Dispose() => Dispose(true);

        #endregion
    }
}