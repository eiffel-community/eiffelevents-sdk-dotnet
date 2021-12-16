using EiffelEvents.Net.Events.Edition_Lyon;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using Newtonsoft.Json.Linq;

namespace EiffelEvents.Net.Tests.TestData.Edition_Lyon;

public class EiffelActivityTriggeredEventFixture
{
    #region Valid Event with all properties populated

    /// <summary>
    /// Get a complete valid instance of EiffelActivityTriggeredEvent.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetValidCompleteEvent()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new()
                    {
                        Type = EiffelDataTriggerType.SOURCE_CHANGE,
                        Description = "Description"
                    }
                },
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2",
                        DomainId = "test-domain-id"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd",
                    DomainId = "test-domain-id"
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf",
                        DomainId = "test-domain-id"
                    }
                }
            }
        };
    }

    public string GetCompletedEventSerialized()
    {
        var json = JObject.Parse(@"{
                              'data': {
                                        'name': 'My activity',
                                        'categories': [
                                        'category 1',
                                        'category 2'
                                            ],
                                        'triggers': [
                                        {
                                            'type': 'SOURCE_CHANGE',
                                            'description': 'Description'
                                        }
                                        ],
                                        'executionType': 'AUTOMATED',
                                         'customData': [
                                            {
                                                'key': 'key1',
                                                'value': 'test'
                                            },
                                            {
                                                'key': 'key2',
                                                'value': 1
                                            }
                                            ]
                                    },
                                    'meta': {
                                        'type': 'EiffelActivityTriggeredEvent',
                                        'version': '4.1.0',
                                        'tags': [
                                        'activity_block'
                                            ],
                                        'source': {
                                                    'serializer': 'pkg:nuget/EiffelEvents.Net@1.0.0.0'
                                         },
                                        'security': {
                                            'authorIdentity': 'Flower'
                                        },
                                        'id': '91d0c7da-8d90-4033-8685-a035853aeea1',
                                        'time': 1637001247776
                                    },
                                'links': [
                                {
                                    'domainId': 'test-domain-id',
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea2'
                                },
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea3'
                                },
                                {
                                    'domainId': 'test-domain-id',
                                    'type': 'CONTEXT',
                                    'target': '82f11609-bd5b-4c82-a5f2-c2a9d982cdbd'
                                },
                                {
                                    'domainId': 'test-domain-id',
                                    'type': 'FLOW_CONTEXT',
                                    'target': 'cf056717-201b-43f6-9f2c-839b33b71baf'
                            }
                            ]
                            }");
        return json.ToString();
    }

    public EiffelActivityTriggeredEvent GetCompletedEventDeserialized()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower",
                    SequenceProtection = new()
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2",
                        DomainId = "test-domain-id"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd",
                    DomainId = "test-domain-id"
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf",
                        DomainId = "test-domain-id"
                    }
                }
            }
        };
    }

    #endregion

    #region Valid Event with null optional properties (primitive types)

    /// <summary>
    /// Get a valid instance of EiffelActivityTriggeredEvent with null for optional properties.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithNullProperties()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                    }
                }
            }
        };
    }

    public string GetEventWithNullPropertiesSerialized()
    {
        var json = JObject.Parse(@"{
                              'data': {
                                        'name': 'My activity',
                                        'categories': [
                                        'category 1',
                                        'category 2'
                                            ],
                                        'triggers': [
                                        {
                                            'type': 'SOURCE_CHANGE',
                                            'description': 'Description'
                                        }
                                        ],
                                        'customData': [
                                            {
                                                'key': 'key1',
                                                'value': 'test'
                                            },
                                            {
                                                'key': 'key2',
                                                'value': 1
                                            }
                                            ]
                                    },
                                    'meta': {
                                        'type': 'EiffelActivityTriggeredEvent',
                                        'version': '4.1.0',
                                        'tags': [
                                        'activity_block'
                                            ],
                                        'source': {
                                                    'serializer': 'pkg:nuget/EiffelEvents.Net@1.0.0.0'
                                         },
                                        'security': {
                                            'authorIdentity': 'Flower'
                                        },
                                        'id': '91d0c7da-8d90-4033-8685-a035853aeea1',
                                        'time': 1637001247776
                                    },
                                'links': [
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea2'
                                },
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea3'
                                },
                                {
                                    'type': 'FLOW_CONTEXT',
                                    'target': 'cf056717-201b-43f6-9f2c-839b33b71baf'
                            }
                            ]
                            }");
        return json.ToString();
    }

    public EiffelActivityTriggeredEvent GetEventWithNullPropertiesDeserialized()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                ExecutionType = null,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower",
                    SequenceProtection = new()
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = null,
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                    }
                }
            }
        };
    }

    #endregion

    #region Valid Event null optional properties (ICollection types)

    /// <summary>
    /// Get a valid instance of EiffelActivityTriggeredEvent with null for optional (Collections) properties.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithNullCollections()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = null,
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = null
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd"
                },
                FlowContext = null
            }
        };
    }

    public string GetEventWithNullCollectionsSerialized()
    {
        var json = JObject.Parse(@"{
                              'data': {
                                        'name': 'My activity',
                                        'categories': [
                                        'category 1',
                                        'category 2'
                                            ],
                                        'executionType': 'AUTOMATED'
                                    },
                                    'meta': {
                                        'type': 'EiffelActivityTriggeredEvent',
                                        'version': '4.1.0',
                                        'tags': [
                                        'activity_block'
                                            ],
                                        'source': {
                                                    'serializer': 'pkg:nuget/EiffelEvents.Net@1.0.0.0'
                                         },
                                        'security': {
                                            'authorIdentity': 'Flower'
                                        },
                                        'id': '91d0c7da-8d90-4033-8685-a035853aeea1',
                                        'time': 1637001247776
                                    },
                                'links': [
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea2'
                                },
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea3'
                                },
                                {
                                    'type': 'CONTEXT',
                                    'target': '82f11609-bd5b-4c82-a5f2-c2a9d982cdbd'
                                }
                            ]
                            }");
        return json.ToString();
    }

    public EiffelActivityTriggeredEvent GetEventWithNullCollectionsDeserialized()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new(),
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower",
                    SequenceProtection = new()
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd"
                },
                FlowContext = new()
            }
        };
    }

    #endregion

    #region Valid Event empty optional properties (ICollection types)

    /// <summary>
    /// Get a valid instance of EiffelActivityTriggeredEvent with empty for optional (Collections) properties.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithEmptyCollections()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new(),
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd"
                },
                FlowContext = new()
            }
        };
    }

    public string GetEventWithEmptyCollectionsSerialized()
    {
        var json = JObject.Parse(@"{
                              'data': {
                                        'name': 'My activity',
                                        'categories': [
                                        'category 1',
                                        'category 2'
                                            ],
                                        'executionType': 'AUTOMATED'
                                    },
                                    'meta': {
                                        'type': 'EiffelActivityTriggeredEvent',
                                        'version': '4.1.0',
                                        'tags': [
                                        'activity_block'
                                            ],
                                        'source': {
                                                    'serializer': 'pkg:nuget/EiffelEvents.Net@1.0.0.0'
                                         },
                                        'security': {
                                            'authorIdentity': 'Flower'
                                        },
                                        'id': '91d0c7da-8d90-4033-8685-a035853aeea1',
                                        'time': 1637001247776
                                    },
                                'links': [
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea2'
                                },
                                {
                                    'type': 'CAUSE',
                                    'target': '91d0c7da-8d90-4033-8685-a035853aeea3'
                                },
                                {
                                    'type': 'CONTEXT',
                                    'target': '82f11609-bd5b-4c82-a5f2-c2a9d982cdbd'
                                }
                            ]
                            }");
        return json.ToString();
    }

    #endregion

    #region Not Valid Guids

    /// <summary>
    /// Get a complete instance of EiffelActivityTriggeredEvent with invalid Guid.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithInvalidGuid()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "test-guid"
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                    }
                }
            }
        };
    }

    /// <summary>
    /// Get a complete instance of EiffelActivityTriggeredEvent with empty Guid ("00000000-0000-0000-0000-000000000000")
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithEmptyGuid()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea2"
                    },
                    new()
                    {
                        Target = "91d0c7da-8d90-4033-8685-a035853aeea3"
                    }
                },
                Context = new()
                {
                    Target = "00000000-0000-0000-0000-000000000000"
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                    }
                }
            }
        };
    }

    /// <summary>
    /// Get a complete instance of EiffelActivityTriggeredEvent with invalid Guid list.
    /// </summary>
    /// <returns></returns>
    public EiffelActivityTriggeredEvent GetEventWithInvalidGuidList()
    {
        return new EiffelActivityTriggeredEvent()
        {
            Data = new()
            {
                Name = "My activity",
                Categories = new() { "category 1", "category 2" },
                Triggers = new()
                {
                    new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                },
                ExecutionType = EiffelDataExecutionType.AUTOMATED,
                CustomData = new()
                {
                    { "key1", "test" },
                    { "key2", 1 }
                }
            },
            Meta = new()
            {
                Id = "91d0c7da-8d90-4033-8685-a035853aeea1",
                Time = 1637001247776,
                Tags = new() { "activity_block" },
                Security = new()
                {
                    AuthorIdentity = "Flower"
                }
            },
            Links = new()
            {
                Cause = new()
                {
                    new()
                    {
                        Target = "test1"
                    },
                    new()
                    {
                        Target = "test2"
                    }
                },
                Context = new()
                {
                    Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd"
                },
                FlowContext = new()
                {
                    new()
                    {
                        Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                    }
                }
            }
        };
    }

    #endregion
}