using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Base
{
    public abstract class ValueBase
    {
        public int Id { get; set; }
        [Required, MaxLength(75)]
        public string Name { get; set; }
    }
}
