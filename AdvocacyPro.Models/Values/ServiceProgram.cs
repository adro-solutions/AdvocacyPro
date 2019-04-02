using AdvocacyPro.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class ServiceProgram : ValueBase
    {
        public int CategoryId { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceProgram>().HasOne<ServiceCategory>().WithMany().HasForeignKey(o => o.CategoryId);
        }
    }
}
