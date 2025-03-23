using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Helpers
{
    //internal static class DataTableConverter
    //{
    //    public static DataTable ConvertToDataTable<T>(BindingList<T> items)
    //    {
    //        DataTable dt = new DataTable();
    //        var properties = typeof(T).GetProperties();

    //        foreach (var prop in properties)
    //            if (prop.PropertyType.Name != "Nullable`1") { 
    //                dt.Columns.Add(prop.Name, prop.PropertyType);
    //            }
    //        //foreach (var item in items)
    //        //{
    //        //    var row = dt.NewRow();
    //        //    foreach (var prop in properties)
    //        //        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    //        //    dt.Rows.Add(row);
    //        //}
    //        foreach (var item in items)
    //        {
    //            var row = dt.NewRow();
    //            foreach (var prop in properties)
    //                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    //            dt.Rows.Add(row);
    //        }

    //        return dt;
    //    }
    //}
    internal static class DataTableConverter
    {
        public static DataTable ConvertToDataTable<T>(BindingList<T> items)
        {
            DataTable dt = new DataTable();
            var properties = typeof(T).GetProperties();

            // Add columns, properly handling nullable types
            foreach (var prop in properties)
            {
                Type columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                // Convert DateOnly to string for DataTable compatibility
                if (columnType == typeof(DateOnly))
                {
                    dt.Columns.Add(prop.Name, typeof(string));
                }
                else
                {
                    dt.Columns.Add(prop.Name, columnType);
                }
            }

            // Add rows
            foreach (var item in items)
            {
                var row = dt.NewRow();
                foreach (var prop in properties)
                {
                    object? value = prop.GetValue(item);

                    // Convert DateOnly? to string
                    if (prop.PropertyType == typeof(DateOnly?) || prop.PropertyType == typeof(DateOnly))
                    {
                        value = value != null ? ((DateOnly)value).ToString("yyyy-MM-dd") : "No Delivery Scheduled";
                    }

                    row[prop.Name] = value ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
