using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Validator_Demo
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
                action(item);
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T) attributes[0] : null;
        }

        public static IEnumerable<PropertyInfo> WhereContainsAttribute<T>(this Type type)
        {
            return type.GetProperties()
                .Where(prop => prop.IsDefined(typeof(T), false));
        }

        public static TOutput Map<TInput, TOutput>(this TInput source, Func<TInput, TOutput> mapper)
            where TInput : class
        {
            return mapper.Invoke(source);
        }

        public static T Out<T>(this T value, out T outValue)
        {
            outValue = value;
            return value;
        }

        public static T GetEnumMemberAttribute<T>(this Enum enumVal) where T : Attribute
            => enumVal.GetType().GetMember(enumVal.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<T>();
    }
}