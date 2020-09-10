using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCoreApi.IService;

namespace Asp.NetCoreApi.Extension
{
    public class ColumnToNote
    {
        private readonly IRepository _repository;
        public ColumnToNote(IRepository repository)
        {
            _repository = repository;
        }

        public DataTable DtColumnZh(DataTable dt, string databaseName, string tableName, List<DataTableColumn> fields = null)
        {
            var sql = $"select COLUMN_NAME,COLUMN_COMMENT from INFORMATION_SCHEMA.COLUMNS where table_name = '{tableName}' and table_schema = '{databaseName}'";
            var dataTable = _repository.GetDataTableResult(sql);
            if (dt == null && dt.Rows.Count < 1) return dt;
            if (dataTable == null || dataTable.Rows.Count < 1) return dt;
            var data = dataTable.Rows.Cast<DataRow>().Select(e => new DataTableColumn { ColumnName = e["COLUMN_NAME"] + "", ColumnComment = e["COLUMN_COMMENT"] + "" }).ToList();
            if (fields != null) data.AddRange(fields);
            data = data.Where(e => !string.IsNullOrEmpty(e.ColumnName) && !string.IsNullOrEmpty(e.ColumnComment)).ToList();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var name = dt.Columns[i].ColumnName.ToUpper();
                var comment = data.Any(e => e.ColumnName.ToUpper() == name) ? data.FirstOrDefault(e => e.ColumnName.ToUpper() == name)?.ColumnComment : "";
                dt.Columns[i].ColumnName = string.IsNullOrEmpty(comment) ? name : comment.ToUpper();
            }
            return dt;
        }

        public DataTable DtColumnArray(DataTable dt, List<DtatableField> arr)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var name = dt.Columns[i].ColumnName.ToUpper();
                var comment = arr.FirstOrDefault(e => e.Column.ToUpper() == name)?.Value;
                dt.Columns[i].ColumnName = string.IsNullOrEmpty(comment) ? name : comment.ToUpper();
            }
            return dt;
        }

        public string CleanString(string str)
        {
            char[] strArr = str.ToCharArray();
            StringBuilder newStr = new StringBuilder();
            foreach (char cr in strArr)
            {
                if (cr == (char)10)//换行符
                {
                    continue;
                }
                if (cr == (char)13)//回车键
                {
                    continue;
                }
                if (cr == (char)32)//SPACE(空格)
                {
                    continue;
                }
                newStr.Append(cr.ToString());
            }
            return newStr.ToString();
        }



    }

    public class DtatableField
    {
        public string Column { get; set; }
        public string Value { get; set; }
    }


    public class DataTableColumn
    {
        public string ColumnName { get; set; }
        public string ColumnComment { get; set; }
    }
}
