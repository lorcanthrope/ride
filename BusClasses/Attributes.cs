using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusClasses
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FaceValueAttribute : Attribute
    {
        public bool IsPictureCard { get; set; }
    }
}
