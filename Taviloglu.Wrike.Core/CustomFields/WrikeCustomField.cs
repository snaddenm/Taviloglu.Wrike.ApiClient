﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;


namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeCustomField : WrikeObjectWithId
    {
        public WrikeCustomField(string title, WrikeCustomFieldType type, List<string> sharedIds = null, WrikeCustomFieldSettings settings = null)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(title), "title can not be empty");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("title can not be null or empty!", "title");
            }

            Title = title;
            Type = type;
            SharedIds = sharedIds;
            Settings = settings;
        }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldType Type { get; private set; }

        [JsonProperty("sharedIds")] 
        public List<string> SharedIds { get; set; }

        [JsonProperty("settings")]        
        public WrikeCustomFieldSettings Settings { get; set; }
    }
}
