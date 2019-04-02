using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CaseDocument : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        [MaxLength(250)]
        [Display(Name = "File name")]
        public string FileName { get; set; }

        public byte[] File { get; set; }

        public int? DocumentTypeId { get; set; }

        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseDocument>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseDocument>().HasOne<DocumentType>().WithMany().HasForeignKey(c => c.DocumentTypeId);
            modelBuilder.Entity<CaseDocument>().HasOne<Case>().WithMany(c => c.Documents).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseDocument>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseDocument>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);

        }
    }
}
