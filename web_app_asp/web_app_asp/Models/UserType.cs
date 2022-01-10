using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_app_asp.Models
{
    public record UserType
    {
        public int UserTypeId { get; set; }
        public string Type { get; set; }
    }
}