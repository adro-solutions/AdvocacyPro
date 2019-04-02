using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CaseContact : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public int? ContactTypeId { get; set; }

        public string Notes { get; set; }

        public DateTime ContactDate { get; set; }
        
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseContact>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseContact>().HasOne<ContactType>().WithMany().HasForeignKey(c => c.ContactTypeId);
            modelBuilder.Entity<CaseContact>().HasOne<Case>().WithMany(c => c.ContactLog).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseContact>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseContact>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
        }
    }
}
