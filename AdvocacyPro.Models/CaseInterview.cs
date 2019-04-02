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
    public class CaseInterview : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        public bool Planned { get; set; }

        public bool OnSite { get; set; }

        [Required]
        public DateTime InterviewDate { get; set; }

        [Display(Name = "Interviewer Position")]
        public int InterviewerPositionId { get; set; }

        [MaxLength(250)]
        public string InterviewerName { get; set; }

        public string Observers { get; set; }

        public bool ProtocolFollowed { get; set; }

        [UIHint("interviewDocumentationTypes", "HTML", "objectKey", "caseInterviewId", "childKey", "interviewDocumentationTypeId")]
        public List<CaseInterviewDocumentationType> CaseInterviewDocumentationTypes { get; set; }

        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseInterview>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseInterview>().HasOne<Case>().WithMany(c => c.Interviews).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseInterview>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseInterview>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseInterview>().HasOne<InterviewerPosition>().WithMany().HasForeignKey(c => c.InterviewerPositionId);
        }
    }

    public class CaseInterviewDocumentationType
    {
        public int InterviewDocumentationTypeId { get; set; }
        public int CaseInterviewId { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseInterviewDocumentationType>().HasKey(k => new { k.CaseInterviewId, k.InterviewDocumentationTypeId });
            modelBuilder.Entity<CaseInterviewDocumentationType>().HasOne<CaseInterview>().WithMany(c => c.CaseInterviewDocumentationTypes).HasForeignKey(c => c.CaseInterviewId);
            modelBuilder.Entity<CaseInterviewDocumentationType>().HasOne<InterviewDocumentationType>().WithMany().HasForeignKey(c => c.InterviewDocumentationTypeId);
        }
    }
}
