using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Helpers
{
    public static class ObjectPropertyChangeDetector
    {
        public static List<string> GetPropertyChanges<T>(T oldObject, T newObject)
        {
            List<String> changes = new List<string>();

            if (oldObject == null || newObject == null)
            {
                throw new ArgumentNullException("Not enough arguments provided");
            }

            Type type = oldObject.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties) 
            {
                Object oldValue = property.GetValue(oldObject);
                Object newValue = property.GetValue(newObject);

                if (!Equals(oldValue, newValue))
                {
                    changes.Add(property.Name);
                }
                
            }
            return changes;
        }
    }
}
