using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace task.Entities
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [MaxLength(1024)]
        public string Tags { get; set; }

        public DateTimeOffset OnADay { get; set; }

        public DateTimeOffset AtATime { get; set; }

        public ETaskStatus Status { get; set; }

        public ETaskPriority Priority { get; set; }

        public ETaskRepeat Repeat { get; set; }

        public string Location { get; set; }

        public string Url { get; set; }


        [Obsolete("Used only for entity binding")]
        public Task() { }

        public Task(string title, string description="", string tags="", DateTimeOffset onADay=default(DateTimeOffset), DateTimeOffset atATime=default(DateTimeOffset), ETaskStatus status=ETaskStatus.None, ETaskPriority priority=ETaskPriority.None, ETaskRepeat repeat=ETaskRepeat.None, string location="", string url="")
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.Tags = tags;
            this.OnADay = onADay;
            this.AtATime = atATime;
            this.Status = status;
            this.Priority = priority;
            this.Repeat = repeat;
            this.Location = location;
            this.Url = url;

        }
    }
}