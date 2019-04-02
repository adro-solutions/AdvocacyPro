using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CaseNote : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseNote>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseNote>().HasOne<Case>().WithMany(c => c.Notes).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseNote>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseNote>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
        }
    }
}
