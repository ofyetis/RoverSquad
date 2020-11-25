using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Helpers
{
    public class Helpers
    {
        public static List<Movement> GetMovementEnumList(string movementLettersString)
        {
            List<string> movementListString = new List<string>();
            movementLettersString.ToList().ForEach(x => movementListString.Add(x.ToString()));
            List<Movement> movementList = new List<Movement>();
            movementListString.ForEach(x => movementList.Add(GetValueFromDescription<Movement>(x)));
            return movementList;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }

        public static string GetDescription(Enum value)
        {
            return
            value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
            ?? value.ToString();
        }
    }
}
