using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Offense : ValueBase
    {
        public int TypeId { get; set; }

        public bool CleryReport { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offense>().HasOne<OffenseType>().WithMany().HasForeignKey("TypeId");

        }
    }
}
