using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class VictimType : ValueBase
    {
        public static List<VictimType> Seed()
        {
            return new List<VictimType> {
                new VictimType { Name = "Adult Physical Assault (Includes Aggrevated and Simple Assault)" },
                new VictimType { Name = "Adult Sexual Assault" },
                new VictimType { Name = "Adults Sexually Abused/Assaulted as Children" },
                new VictimType { Name = "Arson" },
                new VictimType { Name = "Bullying (Verbal, Cyber or Physical)" },
                new VictimType { Name = "Burglary" },
                new VictimType { Name = "Child Physical Abuse or Neglect" },
                new VictimType { Name = "Child Pornography" },
                new VictimType { Name = "Child Sexual Abuse/Assault" },
                new VictimType { Name = "Domestic and/or Family Violence" },
                new VictimType { Name = "DUI/DWI Incidents" },
                new VictimType { Name = "Elder Abuse or Neglect" },
                new VictimType { Name = "Hate Crime: Racial/Religious/Gender/Sexual Orientation, etc." },
                new VictimType { Name = "Human Trafficing: Labor" },
                new VictimType { Name = "Human Trafficing: Sex" },
                new VictimType { Name = "Identity Theft/Fraud/Financial Crime" },
                new VictimType { Name = "Kidnapping (Non-Custodial)" },
                new VictimType { Name = "Kidnapping (Custodial)" },
                new VictimType { Name = "Mass Violence (Domestic/International)" },
                new VictimType { Name = "Other Vehicular Victimization (e.g., Hit and Run)" },
                new VictimType { Name = "Robbery" },
                new VictimType { Name = "Stalking/Harrassment" },
                new VictimType { Name = "Survivor of Homicide Victims" },
                new VictimType { Name = "Teen Dating Victimization" },
                new VictimType { Name = "Terrorism (Domestic/International)" },
                new VictimType { Name = "Violation of Court Order" },
                new VictimType { Name = "Other (describe below)" }
            };
        }
    }
}
