using System;
using POGOProtos.Enums;

namespace PoGo.Windows.Models
{
    public class BadgeTypeAttribute : Attribute
    {
        public BadgeTypeAttribute(BadgeType value)
        {
            Value = value;
        }

        public BadgeType Value { get; set; }
    }
}