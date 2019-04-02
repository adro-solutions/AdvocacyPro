using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

namespace AdvocacyPro.Models
{
    public static class Typings
    {
        public static object GetValidationInfo(string name)
        {
            List<KeyValuePair<string, dynamic>> attributeList = new List<KeyValuePair<string, dynamic>>();
            dynamic d;
            string displayName = "";

            Type type = Type.GetType($"AdvocacyPro.Models.{name}");
            
            if (type == null)
                type = Type.GetType($"AdvocacyPro.Models.Values.{name}");

            if (type == null)
                type = Type.GetType($"AdvocacyPro.Models.DTO.{name}");

            if (type == null)
                type = Type.GetType($"AdvocacyPro.Models.Base.{name}");

            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                var attributes = prop.GetCustomAttributes(true);
                var displayAttribute = attributes.FirstOrDefault(a => a is DisplayAttribute);

                if (displayAttribute == null)
                    displayName = prop.Name;
                else
                    displayName = ((DisplayAttribute)displayAttribute).Name;

                foreach (Attribute attribute in attributes.Where(a => a is ValidationAttribute))
                {
                    d = null;

                    switch (attribute)
                    {
                        case RequiredAttribute r:
                            d = new { type = "required", displayName };
                            break;
                        case EmailAddressAttribute e:
                            d = new { type = "email", displayName };
                            break;
                        case PhoneAttribute p:
                            d = new { type = "phone", displayName };
                            break;
                        case MaxLengthAttribute m:
                            d = new { type = "maxLength", length = m.Length, displayName };
                            break;
                        case MinLengthAttribute m:
                            d = new { type = "minLength", length = m.Length, displayName };
                            break;
                        case RangeAttribute r:
                            d = new
                            {
                                type = "range",
                                minValue = r.Minimum,
                                maxValue = r.Maximum,
                                displayName
                            };
                            break;
                        case RegularExpressionAttribute r:
                            d = new { type = "regex", pattern = r.Pattern,  displayName };
                            break;
                        default: break;
                    }

                    if (d != null)
                        attributeList.Add(new KeyValuePair<string, dynamic>(prop.Name, d));

                }

                var uiHintAttribute = attributes.FirstOrDefault(a => a is UIHintAttribute) as UIHintAttribute;

                if (uiHintAttribute != null)
                {
                    d = new {
                        type = "uiHint",
                        valuesFunction = uiHintAttribute.UIHint, 
                        objectKey = uiHintAttribute.ControlParameters["objectKey"],
                        childKey = uiHintAttribute.ControlParameters["childKey"]
                    };

                    attributeList.Add(new KeyValuePair<string, dynamic>(prop.Name, d));
                }


            }

            return attributeList;
        }
    }
}
