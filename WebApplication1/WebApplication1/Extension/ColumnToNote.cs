using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.IService;

namespace WebApplication1.Extension
{
    public class ColumnToNote
    {
        private readonly IRepository _repository;
        public ColumnToNote(IRepository repository)
        {
            _repository = repository;
        }

        public DataTable DtColumnZH(DataTable dt, string DatabaseName, string TableName, List<DataTableColumn> fields = null)
        {
            var sql = $"select COLUMN_NAME,COLUMN_COMMENT from INFORMATION_SCHEMA.COLUMNS where table_name = '{TableName}' and table_schema = '{DatabaseName}'";
            var datatable = _repository.GetDataTableResult(sql);
            if (dt == null && dt.Rows.Count < 1) return dt;
            if (datatable == null && datatable.Rows.Count < 1) return dt;

            var data = datatable.Rows.Cast<DataRow>().Select(e => new DataTableColumn { COLUMN_NAME = e["COLUMN_NAME"] + "", COLUMN_COMMENT = e["COLUMN_COMMENT"] + "" }).ToList();
            if (fields != null) data.AddRange(fields);
            data = data.Where(e => !string.IsNullOrEmpty(e.COLUMN_NAME) && !string.IsNullOrEmpty(e.COLUMN_COMMENT)).ToList();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var name = dt.Columns[i].ColumnName.ToUpper();
                var comment = data.Where(e => e.COLUMN_NAME.ToUpper() == name).Count() > 0 ? data.Where(e => e.COLUMN_NAME.ToUpper() == name).FirstOrDefault().COLUMN_COMMENT : "";
                dt.Columns[i].ColumnName = string.IsNullOrEmpty(comment) ? name : comment.ToUpper();
            }
            return dt;
        }

        public DataTable DtColumnArray(DataTable dt, List<DtatableField> arr)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var name = dt.Columns[i].ColumnName.ToUpper();
                var comment = arr.Where(e => e.Column.ToUpper() == name).FirstOrDefault()?.Value;
                dt.Columns[i].ColumnName = string.IsNullOrEmpty(comment) ? name : comment.ToUpper();
            }
            return dt;
        }

        public string cleanString(string str)
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
        public string COLUMN_NAME { get; set; }
        public string COLUMN_COMMENT { get; set; }
    }
}
