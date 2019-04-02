using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvocacyPro.Models
{
    public class CaseLetter : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        [Required]
        [Display(Name = "Letter Type")]
        public int LetterTypeId { get; set; }

        [Required]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseLetter>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseLetter>().HasOne<Case>().WithMany(c => c.Letters).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseLetter>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseLetter>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseLetter>().HasOne<LetterType>().WithMany().HasForeignKey(c => c.LetterTypeId);
            modelBuilder.Entity<CaseLetter>().HasOne<Language>().WithMany().HasForeignKey(c => c.LanguageId);
        }
    }
}
