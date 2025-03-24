using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ITECApp.DataAccess
{
    public static class DataReaderMap
    {
        public static List<T> ToList<T>(IDataReader dr) where T : new()
        {
            List<T> list = new List<T>();
            while (dr.Read())
            {
                T obj = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (HasColumn(dr, prop.Name))
                    {
                        prop.SetValue(obj, dr[prop.Name] is DBNull ? null : dr[prop.Name]);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        private static bool HasColumn(IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}