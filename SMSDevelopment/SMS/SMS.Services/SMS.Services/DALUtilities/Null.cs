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
    public class Null
    {
        // define application encoded null values 
        public static short NullShort
        {
            get { return -1; }
        }
        public static int NullInteger
        {
            get { return -1; }
        }
        public static float NullSingle
        {
            get { return Single.MinValue; }
        }
        public static double NullDouble
        {
            get { return Double.MinValue; }
        }
        public static decimal NullDecimal
        {
            get { return Decimal.MinValue; }
        }
        public static DateTime NullDateTime
        {
            get { return DateTime.MinValue; }
        }
        public static string NullString
        {
            get { return ""; }
        }
        public static bool NullBoolean
        {
            get { return false; }
        }
        public static Guid NullGuid
        {
            get { return Guid.Empty; }
        }

        // sets a field to an application encoded null value ( used in BLL layer )
        public static Object SetNull(Object value, Object field)
        {
            Object ret;

            if (Convert.IsDBNull(value))
            {
                if (field.GetType() is short)
                    ret = NullShort;
                else if (field.GetType() is int)
                    ret = NullInteger;
                else if (field.GetType() is Single)
                    ret = NullSingle;
                else if (field.GetType() is Double)
                    ret = NullDouble;
                else if (field.GetType() is Decimal)
                    ret = NullDecimal;
                else if (field.GetType() is DateTime)
                    ret = NullDateTime;
                else if (field.GetType() is string)
                    ret = NullString;
                else if (field.GetType() is bool)
                    ret = NullBoolean;
                else if (field.GetType() is Guid)
                    ret = NullGuid;
                else // complex object
                    ret = null;
            }
            else    // return value
                ret = value;

            return ret;
        }

        // sets a field to an application encoded null value ( used in BLL layer )
        public static Object SetNull(PropertyInfo propertyInfo)
        {
            Object ret;

            switch (propertyInfo.PropertyType.ToString())
            {
                case "System.Int16":
                    ret = NullShort;
                    break;
                case "System.Int32":
                    ret = NullInteger;
                    break;
                case "System.Int64":
                    ret = NullInteger;
                    break;
                case "System.Single":
                    ret = NullSingle;
                    break;
                case "System.Double":
                    ret = NullDouble;
                    break;
                case "System.Decimal":
                    ret = NullDecimal;
                    break;
                case "System.DateTime":
                     ret = NullDateTime;
                    //ret = NullString;
                    break;
                case "System.String":
                    ret = NullString;
                    break;
                case "System.Char":
                    ret = NullString;
                    break;
                case "System.Boolean":
                    ret = NullBoolean;
                    break;
                case "System.Guid":
                    ret = NullGuid;
                    break;
                default:
                    // Enumerations default to the first entry
                    Type type = propertyInfo.PropertyType;
                    if (type.BaseType.Equals(typeof(System.Enum)))
                    {
                        Array enumValues = System.Enum.GetValues(type);
                        Array.Sort(enumValues);
                        ret = System.Enum.ToObject(type, enumValues.GetValue(0));
                    }
                    else // complex object
                        ret = null;
                    break;
            }

            return ret;
        }

        // convert an application encoded null value to a database null value ( used in DAL )
        public static Object GetNull(Object field, Object dbNull)
        {
            Object ret = field;

            if (field == null)
                ret = dbNull;
            else if (field.GetType() is short)
            {
                if (Convert.ToInt16(field) == NullShort)
                    ret = dbNull;
            }
            else if (field.GetType() is int)
            {
                if (Convert.ToInt32(field) == NullInteger)
                    ret = dbNull;
            }
            else if (field.GetType() is Single)
            {
                if (Convert.ToSingle(field) == NullSingle)
                    ret = dbNull;
            }
            else if (field.GetType() is Double)
            {
                if (Convert.ToDouble(field) == NullDouble)
                    ret = dbNull;
            }
            else if (field.GetType() is Decimal)
            {
                if (Convert.ToDecimal(field) == NullDecimal)
                    ret = dbNull;
            }
            else if (field.GetType() is DateTime)
            {
                // compare the Date part of the DateTime with the DatePart of the NullDate ( this avoids subtle time differences )
                if (Convert.ToDateTime(field).Date == NullDateTime.Date)
                    ret = dbNull;
            }
            else if (field.GetType() is string)
            {
                if (field == null)
                    ret = dbNull;
                else
                {
                    if (field.ToString() == NullString)
                        ret = dbNull;
                }
            }
            else if (field.GetType() is bool)
            {
                if (Convert.ToBoolean(field) == NullBoolean)
                    ret = dbNull;
            }
            else if (field.GetType() is Guid)
            {
                if (((Guid)field).Equals(NullGuid))
                    ret = dbNull;
            }

            return ret;
        }

        // checks if a field contains an application encoded null value
        public static bool IsNull(Object field)
        {
            bool ret;

            if (field != null)
            {
                if (field.GetType() is int)
                    ret = field.Equals(NullInteger);
                else if (field.GetType() is Single)
                    ret = field.Equals(NullSingle);
                else if (field.GetType() is Double)
                    ret = field.Equals(NullDouble);
                else if (field.GetType() is Decimal)
                    ret = field.Equals(NullDecimal);
                else if (field.GetType() is DateTime)
                {
                    DateTime date = (DateTime)field;
                    ret = date.Date.Equals(NullDateTime.Date);
                }
                else if (field.GetType() is string)
                    ret = field.Equals(NullString);
                else if (field.GetType() is bool)
                    ret = field.Equals(NullBoolean);
                else if (field.GetType() is Guid)
                    ret = field.Equals(NullGuid);
                else // complex object
                    ret = false;
            }
            else
                ret = true;

            return ret;
        }
    }
}
