using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class OrganizationFeature
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Value { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationFeature>().HasOne<Organization>().WithMany(o => o.Features).HasForeignKey(o => o.OrganizationId);
        }
    }
}
