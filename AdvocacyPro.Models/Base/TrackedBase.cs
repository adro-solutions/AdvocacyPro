using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Base
{
    public class TrackedBase
    {
        public int? UpdatedById { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int CreatedById { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
