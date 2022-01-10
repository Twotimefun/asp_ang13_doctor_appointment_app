using System;
using System.Collections.Generic;

namespace web_app_asp.Models
{
    public record Session
    {
        public int SessionId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}