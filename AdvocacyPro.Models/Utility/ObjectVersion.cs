using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvocacyPro.Models.Utility
{
    public class ObjectVersion
    {
        public ObjectVersion()
        {

        }
        public ObjectVersion(string Type)
        {
            this.Type = Type;
            Version = 1;
        }

        [Required, MaxLength(250), Key]
        public string Type { get; set; }

        public long Version { get; set; }
    }
}
