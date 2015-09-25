using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parse;
using System.Reflection;
using ToDoDemo.Helpers;
using ToDoDemo.Models;

namespace ToDoDemo.Services {
    public class ParseService {


        // TODO: Convert values
        #region ParseObject to Object Mapper
        public static T MapToObject<T>(ParseObject poToConvert) where T : class, new() {

            // Create an instance of the object to return
            T toReturn = Activator.CreateInstance<T>();

            // Get all of the properties of that object
            PropertyInfo[] toReturnProperties = toReturn.GetType().GetProperties();

            // Iterate through each property 
            foreach (PropertyInfo prop in toReturnProperties) {

                // Get the property's POAttribute which contains the column name to get out of the ParseObject's [Key]
                POAttribute parseAttribute = (POAttribute)prop.GetCustomAttribute(typeof(POAttribute));
                // Skip to next property if it doesn't have a POAttribute
                if (parseAttribute == null)
                    continue;
             
                // Get value to set property to (ParseObject is a Dictionary)
                // "title" : "Read this article tonight"
                // "linkUri" : "www.NeatSite.com/NeatArticle"
                // "owner" : <ParseUser>
                var valueToSet = poToConvert[parseAttribute.ColumnName];

                // TODO: Converts the object to the property's type -> Returns null if empty
                //prop.TryConvert(valueObj: valueToSet);
                var castedValue = CastPropertyValue(property: prop, value: valueToSet);

                // Set the value of the toReturn object's property.
                prop.SetValue(obj: toReturn, value: castedValue);
            }
            return toReturn;
        }
        private static object CastPropertyValue(PropertyInfo property, object value) {
            if (property == null)
                return null;
            else if (property.PropertyType == typeof(Uri))
                return new Uri(value.ToString());
            else
                return Convert.ChangeType(value: value, conversionType: property.PropertyType);
        }
        #endregion

        internal static ParseObject MapToParseObject<T>(T objToMap, string tableName = null) where T : class, new() {
            // Ensure the object isn't null
            if (object.ReferenceEquals(objToMap, null)) {
                throw new ArgumentNullException("Cannot map a null object");
            }
            ParseObject po;
            if (tableName != null)
                po = new ParseObject(className: tableName);
            else
                po = new ParseObject(objToMap.GetType().Name);
            
            // Gets all properties in as KeyValuePairs (string PropName.ToCamelCase, obj PropValue)
            var propertiesMappingList = GetObjectPropertyMappingForParse(objToMap);

            foreach (var map in propertiesMappingList) {
                if (map.Value == null) {
                    continue;
                }
                if (map.Key.ToLower() == "objectid") {
                    po.ObjectId = map.Value.ToString();
                    continue;
                }
                if (map.Value != null && map.Value.GetType() == typeof(Uri)) {
                    po.Add(map.Key, map.Value.ToString());
                }
                else {
                    po.Add(map.Key, map.Value);
                }
            }
            return po;
        }

        private static IEnumerable<KeyValuePair<string, object>> GetObjectPropertyMappingForParse(object obj) {
            List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();

            Type type = obj.GetType();
            foreach (PropertyInfo pi in type.GetRuntimeProperties()) {
                IEnumerable<Attribute> propertyAttributes = pi.GetCustomAttributes();
                if (propertyAttributes.Any(a => a.GetType() == typeof(POAttribute))) {
                    POAttribute pomAtt = (POAttribute)propertyAttributes.FirstOrDefault();
                    if (pomAtt.ColumnName != null) {
                        result.Add(new KeyValuePair<string, object>(pomAtt.ColumnName, pi.GetValue(obj)));
                    }
                    //else {
                    //    result.Add(new KeyValuePair<string, object>(pomAtt.IsIdentity ? pi.Name : pi.Name.ToFirstCharacterLower(), pi.GetValue(obj)));
                    //}
                }
            }

            return result;
        }
    

      
        //public ParseObject MapToParseObject() {

        //}














































    }
}
