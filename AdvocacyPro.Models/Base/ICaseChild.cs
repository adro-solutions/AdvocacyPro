using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Base
{
    public interface ICaseChild
    {
        int Id { get; set; }
        int CaseId { get; set; }
        int? UpdatedById { get; set; }
        DateTime? UpdateDate { get; set; }
        int CreatedById { get; set; }
        DateTime? CreateDate { get; set; }
    }
}
