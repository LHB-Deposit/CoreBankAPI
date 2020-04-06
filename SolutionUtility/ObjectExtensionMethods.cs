using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public static class ObjectExtensionMethods
    {
        public static void CopyPropertiesFrom(this object self, object parent)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if(fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(self, fromProperty.GetValue(parent));
                    }
                }
            }
        }

        public static void MatchPropertiesFrom(this object self, object parent)
        {
            var childProperties = self.GetType().GetProperties();
            foreach (var childProperty in childProperties)
            {
                var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
                var isOfTypeMatchParentAttributes = false;
                MatchParentAttribute currrentAttributes = null;
                foreach (var attribute in attributesForProperty)
                {
                    if(attribute.GetType() == typeof(MatchParentAttribute))
                    {
                        isOfTypeMatchParentAttributes = true;
                        currrentAttributes = (MatchParentAttribute)attribute;
                        break;
                    }

                }

                if (isOfTypeMatchParentAttributes)
                {
                    var parentProperties = parent.GetType().GetProperties();
                    object parentPropertyValue = null;
                    foreach (var parenProperty in parentProperties)
                    {
                        if(parenProperty.Name == currrentAttributes.ParentPropertyName)
                        {
                            if(parenProperty.PropertyType == childProperty.PropertyType)
                            {
                                parentPropertyValue = parenProperty.GetValue(parent);
                            }
                        }
                    }
                    childProperty.SetValue(self, parentPropertyValue);
                }
            }
        }
    }
}
