using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace SMS.Services.DALUtilities
{
    ///<summary>
    ///Summary Description fo CBO
    ///</summary>

    public class CBO
    {
        public CBO()
        {
            //
            // TODO: Add Constructor logic here
            //
        }

        public static ArrayList GetPropertyInfo(Type type)
        {
            ArrayList properties = new ArrayList();

            foreach(PropertyInfo p in type.GetProperties())
            {
                properties.Add(p);
            }

            return properties;
        }

        private static int[] GetOrdinals(ArrayList properties, IDataReader dr)
        {
            int[] ordinals = new int[properties.Count];

            if (dr != null)
            {
                for (int i = 0; i <= properties.Count - 1; i++)
                {
                    ordinals[i] = -1;
                    try
                    {
                        ordinals[i] = dr.GetOrdinal(((PropertyInfo)properties[i]).Name);
                    }
                    catch (Exception)
                    {
                        //property does not exist in datareader
                    }
                }
            }
            return ordinals;
        }
        private static T CreateObject<T>(IDataReader dr)
        {
            PropertyInfo propertyInfo = null;
            Object targetValue = null;
            Type propertyType = null;
            

            T targetObject = Activator.CreateInstance<T>();

            //get properties for type
            ArrayList properties = GetPropertyInfo(targetObject.GetType());

            //get ordinal positions in datareader
            int[] ordinals = GetOrdinals(properties, dr);

            //fill object with values from datareader
            for (int i = 0; i <= properties.Count - 1; i++)
            {
                propertyInfo = properties[i] as PropertyInfo;
                if (propertyInfo.CanWrite)
                {
                    targetValue = Null.SetNull(propertyInfo);

                    if (ordinals[i] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(ordinals[i])))
                            // translate Null value
                            propertyInfo.SetValue(targetObject, targetValue, null);
                        else
                        {
                            try
                            {
                                // try implicit conversion first
                                propertyInfo.SetValue(targetObject, dr.GetValue(ordinals[i]), null);
                            }
                            catch (Exception)
                            {
                                // business object info class member data type does not match datareader member data type
                                try
                                {
                                    propertyType = propertyInfo.PropertyType;

                                    // need to handle enumeration conversions differently than other base types
                                    if (propertyType.BaseType.Equals(typeof(System.Enum)))
                                    {
                                        // check if value is numeric and if not convert to integer ( supports databases like Oracle )
                                        if (IsNumeric(dr.GetValue(ordinals[i])))
                                            ((PropertyInfo)properties[i]).SetValue(targetObject, System.Enum.ToObject(propertyType, Convert.ToInt32(dr.GetValue(ordinals[i]))), null);
                                        else
                                            ((PropertyInfo)properties[i]).SetValue(targetObject, System.Enum.ToObject(propertyType, dr.GetValue(ordinals[i])), null);
                                    }
                                    else
                                        // try explicit conversion
                                        propertyInfo.SetValue(targetObject, Convert.ChangeType(dr.GetValue(ordinals[i]), propertyType), null);
                                }
                                catch (Exception)
                                {
                                    propertyInfo.SetValue(targetObject, Convert.ChangeType(dr.GetValue(ordinals[i]), propertyType), null);
                                }
                            }
                        }
                    }
                }
                else { }// property does not exist in datareader
            }

            return targetObject;
        }

        ///<summary>
        ///Generic version of FillCollection fills a List custom business object of a specified type 
        ///from the supplied DataReader
        ///</summary>
        ///<typeparam name="T">The type of the business object</typeparam>
        ///<param name="dr">The IDataReader to use to fill the object</param>
        ///<returns>A List of custom business objects</returns>
        ///<remarks></remarks>
        ///<history>
        ///</history>
        public static List<T> FillCollection<T>(IDataReader dr)
        {
            List<T> fillCollection = new List<T>();
            T fillObject;

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                fillObject = CreateObject<T>(dr);
                // add to collection
                fillCollection.Add(fillObject);
            }

            // close datareader
            if (dr != null)
                dr.Close();

            return fillCollection;
        }

        public static List<T> FillMultipleCollection<T>(IDataReader dr)
        {
            List<T> fillCollection = new List<T>();
            T fillObject;

            // iterate datareader
            while (dr.Read())
            {
                // fill business object
                fillObject = CreateObject<T>(dr);
                // add to collection
                fillCollection.Add(fillObject);
            }
            return fillCollection;
        }

        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}

