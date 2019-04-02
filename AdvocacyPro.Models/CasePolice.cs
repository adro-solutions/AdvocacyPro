using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CasePolice : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        [MaxLength(100)]
        [Display(Name = "Police department")]
        public string PoliceDepartment { get; set; }

        [MaxLength(50)]
        [Display(Name = "Police sequence no")]
        public string PoliceSequenceNo { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Police case no")]
        public string PoliceCaseNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime? PoliceClosedDate { get; set; }

        public string PoliceOutcome { get; set; }

        public string Notes { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CasePolice>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CasePolice>().HasOne<Case>().WithMany(c => c.Police).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CasePolice>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CasePolice>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);

        }
    }
}
