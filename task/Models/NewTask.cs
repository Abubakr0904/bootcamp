using System.ComponentModel;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task.Models
{
    public class NewTask
    {
        
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public DateTimeOffset OnADay { get; set; }

        public DateTimeOffset AtATime { get; set; }

        [JsonConverter(typeof(EnumConverter))]
        public ETaskStatus Status { get; set; }

        [JsonConverter(typeof(EnumConverter))]
        public ETaskPriority Priority { get; set; }

        [JsonConverter(typeof(EnumConverter))]
        public ETaskRepeat Repeat { get; set; }

        public TaskLocation Location { get; set; }

        public string Url { get; set; }
    }
}