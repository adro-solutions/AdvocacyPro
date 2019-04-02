using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class RelationshipType : ValueBase
    {
        public static List<RelationshipType> Seed()
        {
            return new List<RelationshipType> { new RelationshipType { Name = "Father" },
                    new RelationshipType { Name = "Mother" },
                    new RelationshipType { Name = "Step Father" },
                    new RelationshipType { Name = "Step Mother" },
                    new RelationshipType { Name = "Paternal Grand Father" },
                    new RelationshipType { Name = "Paternal Grand Mother" },
                    new RelationshipType { Name = "Maternal Grand Father" },
                    new RelationshipType { Name = "Maternal Grand Mother" },
                    new RelationshipType { Name = "Aunt" },
                    new RelationshipType { Name = "Uncle" },
                    new RelationshipType { Name = "Foster Mother" },
                    new RelationshipType { Name = "Foster Father" },
                    new RelationshipType { Name = "Brother" },
                    new RelationshipType { Name = "Sister" },
                    new RelationshipType { Name = "Stranger" },
                    new RelationshipType { Name = "Cousin" },
                    new RelationshipType { Name = "Friend" },
                    new RelationshipType { Name = "Sibling's Friend" },
                    new RelationshipType { Name = "Teacher" },
                    new RelationshipType { Name = "Scout Master" },
                    new RelationshipType { Name = "Counselor" },
                    new RelationshipType { Name = "Acquaintance" },
                    new RelationshipType { Name = "Neighbor" },
                    new RelationshipType { Name = "Baby Sitter" },
                    new RelationshipType { Name = "Shelter Dad" },
                    new RelationshipType { Name = "Shelter Mom" },
                    new RelationshipType { Name = "DCFS" },
                    new RelationshipType { Name = "Case Worker" },
                    new RelationshipType { Name = "Foster Care Worker" },
                    new RelationshipType { Name = "Detective" },
                    new RelationshipType { Name = "Doctor" },
                    new RelationshipType { Name = "Nurse" },
                    new RelationshipType { Name = "DA" },
                    new RelationshipType { Name = "AG" },
                    new RelationshipType { Name = "GAL" },
                    new RelationshipType { Name = "Other Professional" },
                    new RelationshipType { Name = "Foster Sibling" },
                    new RelationshipType { Name = "Step Sibling" },
                    new RelationshipType { Name = "Resident" },
                    new RelationshipType { Name = "Class Mate" },
                    new RelationshipType { Name = "Half Sibling" },
                    new RelationshipType { Name = "Adopted Sibling" },
                    new RelationshipType { Name = "Parent Partner" },
                    new RelationshipType { Name = "Religious Leader" },
                    new RelationshipType { Name = "Brother-In-Law" },
                    new RelationshipType { Name = "Sister-In-Law" },
                    new RelationshipType { Name = "Other Related" },
                    new RelationshipType { Name = "Other Non-Related" },
                    new RelationshipType { Name = "Victim's Boy/Girl Friend" },
                    new RelationshipType { Name = "Unknown" },
                    new RelationshipType { Name = "Adoptive Mother" },
                    new RelationshipType { Name = "Adoptive Father" },
                    new RelationshipType { Name = "Spouse / Partner" },
                    new RelationshipType { Name = "Staff or Faculty" }};
        }
    }
}
