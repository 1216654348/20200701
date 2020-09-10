using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Asp.NetCoreApi.Extension
{
    public static class PathHelper
    {
        public static string WebAttribute = ConfigurationHelper.Configuration["webAttPath"];
        //public static string WebAttribute = @"http://60.191.9.82:82/";
        public static string RemoveWebAttPathValue(string sourcePath)
        {
            return sourcePath?.Replace(WebAttribute, "");
        }
        public static Dictionary<string, object> RemoveWebAttPath(Dictionary<string, object> keyValuePairs)
        {
            if (keyValuePairs == null) return keyValuePairs;
            List<string> test = new List<string>(keyValuePairs.Keys);//把key值存储到list中
            for (int i = 0; i < test.Count; i++)
            {
                if (keyValuePairs[test[i]] is string)
                {
                    var str = keyValuePairs[test[i]].ToString();
                    if (!string.IsNullOrWhiteSpace(str) && str.Contains(WebAttribute))
                    {
                        keyValuePairs[test[i]] = str.Replace(WebAttribute, "");
                    }
                }
            }
            return keyValuePairs;
        }
        public static Dictionary<string, object> AddWebAttPath(Dictionary<string, object> keyValuePairs)
        {
            if (keyValuePairs == null) return keyValuePairs;
            var pathFields = new List<string> { "SYTLJ", "CCLJ", "DBXTP" };
            List<string> test = new List<string>(keyValuePairs.Keys);//把key值存储到list中
            for (int i = 0; i < keyValuePairs.Keys.Count; i++)
            {
                if (keyValuePairs[test[i]] is string)
                {
                    var str = keyValuePairs[test[i]].ToString();
                    if (!string.IsNullOrWhiteSpace(str) && pathFields.Contains(test[i]))
                    {
                        keyValuePairs[test[i]] = Path.Combine(WebAttribute, str.TrimStart('/'));
                    }
                }
            }
            return keyValuePairs;
        }
        public static Dictionary<string, object> AddWebAttPath(Dictionary<string, object> keyValuePairs, List<string> pathFields)
        {
            if (keyValuePairs == null) return keyValuePairs;
            List<string> test = new List<string>(keyValuePairs.Keys);//把key值存储到list中
            for (int i = 0; i < keyValuePairs.Keys.Count; i++)
            {
                if (keyValuePairs[test[i]] is string)
                {
                    var str = keyValuePairs[test[i]].ToString();
                    if (!string.IsNullOrWhiteSpace(str) && pathFields.Contains(test[i]))
                    {
                        keyValuePairs[test[i]] = Path.Combine(WebAttribute, str.TrimStart('/'));
                    }
                }
            }
            return keyValuePairs;
        }

        public static DataTable AddWebAttPathForDatatable(DataTable dataTable)
        {
            if (dataTable == null) return dataTable;

            var pathFields = new List<string> { "SYTLJ", "CCLJ", "PATH", "DBXTP", "HDXCTP", "SYTP", "TPLJ", "BHLMTLJ", "BHSYT", "YCYSCJSJTP", "YCYSJCSJTP" };
            foreach (var item in pathFields)
            {
                if (dataTable.Columns.Contains(item))
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr[item] + ""))
                        {
                            dr[item] = Path.Combine(WebAttribute, (dr[item] + "").TrimStart('/'));
                        }
                    }
                }
            }
            return dataTable;
        }

        public static DataTable AddWebAttPathForDatatable(DataTable dataTable, string field)
        {
            if (dataTable == null) return dataTable;

            var pathFields = new List<string> { field };
            foreach (var item in pathFields)
            {
                if (dataTable.Columns.Contains(item))
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr[item] + ""))
                        {
                            dr[item] = Path.Combine(WebAttribute, (dr[item] + "").TrimStart('/'));
                        }
                    }
                }
            }
            return dataTable;
        }



        public static DataTable AddWebAttPathForDatatable(DataTable dataTable, List<string> pathFields)
        {
            if (dataTable == null) return dataTable;

            foreach (var item in pathFields)
            {
                if (dataTable.Columns.Contains(item))
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr[item] + ""))
                        {
                            dr[item] = Path.Combine(WebAttribute, dr[item] + "".TrimStart('/'));
                        }
                    }
                }
            }
            return dataTable;
        }
        public static T AddWebAttPath<T>(T TEntity, List<string> pathFields)
        {
            if (TEntity == null) return TEntity;
            PropertyInfo[] propertys = TEntity.GetType().GetProperties();

            foreach (var pro in propertys)
            {
                var name = pro.Name;
                if (!pathFields.Contains(name)) continue;
                var value = pro.GetValue(TEntity).ToString();
                var newValue = Path.Combine(WebAttribute, value);
                pro.SetValue(TEntity, newValue);
            }

            return TEntity;
        }

        public static T AddWebAttPath<T>(T TEntity)
        {
            if (TEntity == null) return TEntity;
            var pathFields = new List<string> { "TBLJ", "SYTLJ", "CCLJ", "PATH", "DBXTP", "HDXCTP", "SYTP", "YCYSCJSJTP" };
            PropertyInfo[] propertys = TEntity.GetType().GetProperties();

            foreach (var pro in propertys)
            {
                var name = pro.Name;
                if (!pathFields.Contains(name)) continue;
                var value = pro.GetValue(TEntity).ToString();
                var newValue = Path.Combine(WebAttribute, value);
                pro.SetValue(TEntity, newValue);
            }

            return TEntity;
        }
        public static string AddWebAttPathValue(string sourcePath)
        {
            var destiString = "";
            if (!string.IsNullOrWhiteSpace(sourcePath))
            {
                destiString = Path.Combine(WebAttribute, sourcePath);
            }
            return destiString;
        }

    }
}
