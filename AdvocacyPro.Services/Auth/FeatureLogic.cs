using AdvocacyPro.Services.Extensions;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Auth
{
    public class FeatureLogic
    {
        public List<Feature> GetAll()
        {
            List<Feature> list = new List<Feature>();
            var features = new ProductFeatures();
            foreach (FieldInfo fi in typeof(ProductFeatures).GetFields())
            {
                var value = fi.GetValue(features) as string;
                list.Add(new Feature() { Name = fi.Name.SplitCamelCase(), Value = value });
            }

            return list;
        }
    }
}
