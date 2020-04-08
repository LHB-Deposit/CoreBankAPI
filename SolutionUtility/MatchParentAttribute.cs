using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MatchParentAttribute : Attribute
    {
        public readonly string ParentPropertyName;
        public MatchParentAttribute(string parentPropertyame)
        {
            ParentPropertyName = parentPropertyame;
        }
    }
}
