using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parse;
using System.Reflection;
using ToDoDemo.Helpers;

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

                // Set the value of the toReturn object's property. 
                // (Off Topic: Agreed, the syntax doesn't make sense)
                prop.SetValue(obj: toReturn, value: valueToSet);
            }
            return toReturn;
        }
        #endregion

        //public ParseObject MapToParseObject() {

        //}














































    }
}
