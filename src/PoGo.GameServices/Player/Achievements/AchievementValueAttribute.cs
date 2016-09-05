using System;

namespace PoGo.GameServices.Models
{
    public class AchievementValueAttribute : System.Attribute
    {
        public AchievementValueAttribute(object value)
        {
            Value = value;
        }

        public object Value { get; set; }
    }
}