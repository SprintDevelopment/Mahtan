using Mahtan.Assets.Attributes;
using Mahtan.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Mahtan.Assets.Extensions
{
    public static class ObjectExtensions
    {
        public static List<PropertyInfo> GetNavigationProperties<T>(this T obj)
        {
            var type = obj.GetType();
            var navigationProperties = new List<PropertyInfo>();
            foreach (var property in type.GetProperties())
            {
                var foreignAttribute = (ForeignKeyAttribute)property.GetCustomAttribute(typeof(ForeignKeyAttribute));
                if (foreignAttribute != null || property.GetMethod.IsVirtual)
                    navigationProperties.Add(property);
            }

            return navigationProperties;
        }

        public static PropertyInfo GetKeyProperty<T>(this T obj)
        {
            var type = obj.GetType();
            return type.GetProperties().SingleOrDefault(p => (KeyAttribute)p.GetCustomAttribute(typeof(KeyAttribute)) != null);
        }

        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }

        public static T LightClone<T>(this T obj) where T : BaseModel
        {
            var deepClone = obj.Clone();
            
            foreach (var property in GetNavigationProperties(obj))
                property.SetValue(deepClone, null);

            return (T)deepClone;
        }

        public static string CrudTitle<T>(this T obj) where T : BaseModel
        {
            var keyPropertyValue = obj.GetPropertyValue(obj.GetKeyProperty().Name);
            var modelAttribute = (ModelAttribute)typeof(T).GetCustomAttribute(typeof(ModelAttribute));
            return keyPropertyValue == "0" ? $"افزودن {modelAttribute.SingleEntityTitle} جدید" : $"ویرایش {modelAttribute.SingleEntityTitle}";
        }

        public static bool ExistsIn<T>(this T source, params T[] others)
        {
            return others.Length == 0 || others.Any(x => EqualityComparer<T>.Default.Equals(source, x));
        }
    }
}
