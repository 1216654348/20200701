using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.NetCoreApi.IService;

namespace Asp.NetCoreApi.Extension
{
    public partial class BaseRepository : IRepository
    {
        public static string ConnectionString = ConfigurationHelper.Configuration["ConnectionStrings:MySqlConnectionStr"];
        public DataTable GetDataTableResult(string sql, SqlParameter[] parameters = null)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet("test");
            try
            {
                adapter.Fill(ds);
                dt = ds.Tables[0];

                if (dt != null)
                {
                    bool needConvert = false;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        Type typeName = dt.Columns[i].DataType;
                        string strTypeName = typeName.ToString();
                        if (strTypeName == "MySql.Data.Types.MySqlDateTime")
                        {
                            needConvert = true;
                        }
                        dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToUpper();
                    }
                    if (needConvert)
                    {
                        //克隆表结构
                        DataTable dtResult = new DataTable();
                        dtResult = dt.Clone();
                        foreach (DataColumn col in dtResult.Columns)
                        {
                            if (col.DataType.ToString() == "MySql.Data.Types.MySqlDateTime")
                            {
                                //修改列类型
                                col.DataType = typeof(System.DateTime);
                            }
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow rowNew = dtResult.NewRow();
                            foreach (DataColumn col in dtResult.Columns)
                            {
                                if (col.DataType.ToString() == "System.DateTime")
                                {
                                    if (row[col.ColumnName] != DBNull.Value && row[col.ColumnName] != null)
                                    {
                                        string strVal = row[col.ColumnName].ToString();
                                        if (!strVal.StartsWith("0000"))
                                        {
                                            try
                                            {
                                                rowNew[col.ColumnName] = Convert.ToDateTime(row[col.ColumnName]);
                                            }
                                            catch
                                            {
                                                rowNew[col.ColumnName] = DBNull.Value;
                                            }
                                        }
                                        else
                                            rowNew[col.ColumnName] = DBNull.Value;
                                    }
                                    else
                                        rowNew[col.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    rowNew[col.ColumnName] = row[col.ColumnName];
                                }
                            }
                            dtResult.Rows.Add(rowNew);
                        }
                        adapter.Dispose();
                        conn.Close();
                        conn.Dispose();
                        return dtResult;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                adapter.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }
        /// <summary>
        ///以事务方式 批量执行SQL语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public bool ExecuteTransactionSQLList(List<string> sqlList)
        {
            if (sqlList == null || sqlList.Count == 0)
                return false;
            MySqlConnection dbConn = new MySqlConnection();
            dbConn.ConnectionString = ConnectionString;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            MySqlTransaction transaction = dbConn.BeginTransaction();
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.Transaction = transaction;
            bool bl = false;
            try
            {
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                bl = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                dbConn.Close();
                dbConn.Dispose();
            }
            return bl;
        }
        public int Execute(string strSQL)
        {
            MySqlConnection dbConn = new MySqlConnection();
            dbConn.ConnectionString = ConnectionString;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = strSQL;
            MySqlTransaction transaction = dbConn.BeginTransaction();
            int result = -1;
            try
            {
                cmd.Transaction = transaction;
                result = cmd.ExecuteNonQuery();
                transaction.Commit();
                //return result;
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                dbConn.Close();
                dbConn.Dispose();
            }
            return result;
        }
        public object ExecuteScalar(string strSQL)
        {
            MySqlConnection dbConn = new MySqlConnection();
            dbConn.ConnectionString = ConnectionString;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = strSQL;
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            finally
            {
                dbConn.Close();
                dbConn.Dispose();
            }
            return null;
        }
        public List<string> ExecuteSingleFieldValueList(string strSQL)
        {
            MySqlConnection dbConn = new MySqlConnection();
            dbConn.ConnectionString = ConnectionString;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = strSQL;
            MySqlDataReader reader = null;
            List<string> listObjects = null;
            try
            {
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    //int rowCount = (int)reader.RowSize;
                    //listObjects = new List<string>(rowCount);
                    listObjects = new List<string>();
                    while (reader.Read())
                    {
                        string tmp = reader.GetValue(0).ToString();
                        listObjects.Add(tmp);
                    }
                    return listObjects;
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                dbConn.Close();
                dbConn.Dispose();
            }

            return listObjects;
        }
        public bool ExecuteTransaction(string strSQL)
        {
            MySqlConnection dbConn = new MySqlConnection();
            dbConn.ConnectionString = ConnectionString;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            MySqlCommand cmd = dbConn.CreateCommand();
            if (cmd == null || cmd.Connection == null)
            {
                return false;
            }
            cmd.CommandType = CommandType.Text;
            MySqlTransaction transaction = null;
            try
            {
                transaction = cmd.Connection.BeginTransaction();
                cmd.Transaction = transaction;
                int result = cmd.ExecuteNonQuery();//.ExecuteNonQuery();
                transaction.Commit();

                transaction.Dispose();
                transaction = null;
                return result > 0 ? true : false;
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
            }
            return false;
        }
        public string InsertByParamsReturnSQL(string tabName, IDictionary<string, object> fieldValueDiction, bool releaseObj = false)
        {
            if (fieldValueDiction.Count > 0)
            {
                //数据库查询
                MySqlConnection dbConn = new MySqlConnection();
                dbConn.ConnectionString = ConnectionString;
                if (dbConn.State != ConnectionState.Open)
                {
                    dbConn.Open();
                }
                MySqlCommand cmd = dbConn.CreateCommand();
                Dictionary<string, MySqlDbType> fieldTypeDiction = GetTableFieldType(tabName, cmd);
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into ");
                sb.Append(tabName);

                sb.Append("(");
                bool isFirst = true;
                foreach (string field in fieldValueDiction.Keys)
                {
                    if (!fieldTypeDiction.ContainsKey(field))
                        continue;
                    object tmpValue = fieldValueDiction[field];
                    if (tmpValue == null || string.IsNullOrEmpty(tmpValue.ToString()))
                        continue;
                    if (!isFirst)
                    {
                        sb.Append(",");
                    }
                    sb.Append("`" + field + "`");
                    isFirst = false;
                }
                sb.Append(")");

                sb.Append(" values(");
                int i = 0;
                foreach (string fieldKey in fieldValueDiction.Keys)
                {
                    if (!fieldTypeDiction.ContainsKey(fieldKey))
                        continue;
                    object tmpValue = fieldValueDiction[fieldKey];
                    if (tmpValue == null || string.IsNullOrEmpty(tmpValue.ToString()))
                        continue;
                    if (i > 0)
                    {
                        sb.Append(",");
                    }
                    string strvalue = "";
                    if (fieldTypeDiction != null && fieldTypeDiction.Count > 0)
                    {
                        MySqlDbType tmpDBType = fieldTypeDiction[fieldKey];
                        switch (tmpDBType)
                        {
                            case MySqlDbType.Bit:
                            case MySqlDbType.Int16:
                            case MySqlDbType.Int32:
                            case MySqlDbType.Int64:
                            case MySqlDbType.Decimal:
                            case MySqlDbType.Double:

                                strvalue = tmpValue.ToString();
                                break;
                            case MySqlDbType.DateTime:
                                if (DateTime.TryParse(tmpValue.ToString(), out var dt))
                                {
                                    strvalue = $"'{ dt.ToString("yyyy-MM-dd HH:mm:ss")}'";
                                }
                                break;
                            case MySqlDbType.Timestamp:
                                if (DateTime.TryParse(tmpValue.ToString(), out var datetime))
                                {
                                    strvalue = $"'{ datetime.ToString("yyyy-MM-dd HH:mm:ss")}'";
                                }
                                break;
                            default:
                                strvalue = "'" + tmpValue.ToString() + "'";
                                break;
                        }
                    }
                    else
                        strvalue = "'" + tmpValue.ToString() + "'";
                    i++;
                    sb.Append(strvalue);
                }
                sb.Append(" )");
                string sql = sb.ToString();
                sb.Clear();
                dbConn.Close();
                dbConn.Dispose();
                //清空释放内存对象
                if (releaseObj)
                {
                    fieldValueDiction.Clear();
                    fieldValueDiction = null;
                }
                return sql;
            }
            return "";
        }
        public string UpdateByParamsReturnSQL(string tabName, IDictionary<string, object> fieldValueDiction, bool releaseObj = false, string useField = "")
        {
            if (fieldValueDiction.Count > 0)
            {
                //数据库查询
                MySqlConnection dbConn = new MySqlConnection();
                dbConn.ConnectionString = ConnectionString;
                if (dbConn.State != ConnectionState.Open)
                {
                    dbConn.Open();
                }
                MySqlCommand cmd = dbConn.CreateCommand();
                Dictionary<string, MySqlDbType> fieldTypeDiction = GetTableFieldType(tabName, cmd);
                StringBuilder sb = new StringBuilder();
                sb.Append("update ");
                sb.Append(tabName);
                sb.Append(" set ");
                int i = 0;
                string keyFieldName = "";
                object keyFieldValue = null;

                if (string.IsNullOrEmpty(useField))
                {
                    //查询获取数据库表的主键
                    string selectsql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where table_name='" + tabName + "' AND COLUMN_KEY='PRI'";
                    keyFieldName = ExecuteScalar(selectsql).ToString();
                }
                else
                {
                    keyFieldName = useField;
                }

                foreach (string fieldKey in fieldValueDiction.Keys)
                {
                    if (!fieldTypeDiction.ContainsKey(fieldKey))
                        continue;
                    if (keyFieldName.ToUpper() == fieldKey.ToUpper())
                    {
                        keyFieldValue = fieldValueDiction[fieldKey];
                        continue;
                    }
                    object tmpValue = fieldValueDiction[fieldKey];

                    if (i > 0)
                    {
                        sb.Append(",");
                    }
                    i++;
                    sb.Append("`" + fieldKey + "`");
                    sb.Append("=");

                    string strvalue = "";
                    if (fieldTypeDiction != null && fieldTypeDiction.Count > 0)
                    {
                        MySqlDbType tmpDBType = fieldTypeDiction[fieldKey];
                        switch (tmpDBType)
                        {
                            case MySqlDbType.Bit:
                            case MySqlDbType.Int16:
                            case MySqlDbType.Int32:
                            case MySqlDbType.Int64:
                            case MySqlDbType.Decimal:
                            case MySqlDbType.Double:
                                if (tmpValue == null)
                                {
                                    strvalue = "null";
                                }
                                else
                                    strvalue = tmpValue.ToString();
                                break;
                            case MySqlDbType.DateTime:
                                if (tmpValue == null) strvalue = "null";
                                else
                                {
                                    var isDatetime = DateTime.TryParse(tmpValue.ToString(), out var tmpValueTime);
                                    if (isDatetime) strvalue = "'" + tmpValueTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                                    else strvalue = "'" + tmpValue.ToString() + "'";
                                }
                                break;
                            default:
                                if (tmpValue == null)
                                {
                                    strvalue = "null";
                                }
                                else
                                    strvalue = "'" + tmpValue.ToString() + "'";
                                break;
                        }
                    }
                    else
                    {
                        if (tmpValue == null)
                        {
                            strvalue = "null";
                        }
                        else
                            strvalue = "'" + tmpValue.ToString() + "'";
                    }
                    sb.Append(strvalue);
                }
                sb.Append(" where ");
                sb.Append("`" + keyFieldName + "`");
                sb.Append(" = ");

                if (fieldTypeDiction != null && fieldTypeDiction.Count > 0)
                {
                    MySqlDbType tmpDBType = fieldTypeDiction[keyFieldName];
                    switch (tmpDBType)
                    {
                        case MySqlDbType.Bit:
                        case MySqlDbType.Int16:
                        case MySqlDbType.Int32:
                        case MySqlDbType.Int64:
                        case MySqlDbType.Decimal:
                        case MySqlDbType.Double:
                            sb.Append(keyFieldValue);
                            break;
                        default:
                            sb.Append("'");
                            sb.Append(keyFieldValue);
                            sb.Append("'");
                            break;
                    }
                }
                else
                {
                    sb.Append("'");
                    sb.Append(keyFieldValue);
                    sb.Append("'");
                }
                string sql = sb.ToString();
                sb.Clear();
                dbConn.Close();
                dbConn.Dispose();
                //清空释放内存对象
                if (releaseObj)
                {
                    fieldValueDiction.Clear();
                    fieldValueDiction = null;
                }
                return sql;
            }
            return "";
        }
        private Dictionary<string, MySqlDbType> GetTableFieldType(string tabName, MySqlCommand cmd)
        {
            string sql = "show full columns from " + tabName;
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
            }
            finally
            {
                da.Dispose();
            }
            int count = dt.Rows.Count;
            if (count > 0)
            {
                Dictionary<string, MySqlDbType> result = new Dictionary<string, MySqlDbType>(count, StringComparer.OrdinalIgnoreCase);
                string strtype;
                string strfieldname;
                MySqlDbType fieldType = MySqlDbType.VarChar;
                for (int i = 0; i < count; i++)
                {
                    DataRow drow = dt.Rows[i];
                    if (drow["Type"] == null || drow["Field"] == null || string.IsNullOrEmpty(drow["Type"].ToString()) || string.IsNullOrEmpty(drow["Field"].ToString()))
                    {
                        i++;
                        continue;
                    }
                    string[] strsplit = drow["Type"].ToString().Split('(');
                    strtype = strsplit[0].ToLower();
                    strfieldname = drow["Field"].ToString();
                    try
                    {
                        switch (strtype)
                        {
                            case "tinyint":
                            case "bit":
                                fieldType = MySqlDbType.Bit;
                                break;
                            case "smallint":
                                fieldType = MySqlDbType.Int16;
                                break;
                            case "mediumint":
                            case "int":
                            case "integer":
                                fieldType = MySqlDbType.Int32;
                                break;
                            case "bigint":
                                fieldType = MySqlDbType.Int64;
                                break;
                            case "real":
                            case "double":
                                fieldType = MySqlDbType.Double;
                                break;
                            case "float":
                                fieldType = MySqlDbType.Float;
                                break;
                            case "decimal":
                            case "numeric":
                                fieldType = MySqlDbType.Decimal;
                                break;
                            case "char":
                            case "varchar":
                                fieldType = MySqlDbType.String;
                                break;
                            case "date":
                                fieldType = MySqlDbType.Date;
                                break;
                            case "time":
                                fieldType = MySqlDbType.Time;
                                break;
                            case "year":
                                fieldType = MySqlDbType.Year;
                                break;
                            case "timestamp":
                                fieldType = MySqlDbType.Timestamp;
                                break;
                            case "datetime":
                                fieldType = MySqlDbType.DateTime;
                                break;
                            case "tinyblob":
                                fieldType = MySqlDbType.TinyBlob;
                                break;
                            case "blob":
                                fieldType = MySqlDbType.Blob;
                                break;
                            case "mediumblob":
                                fieldType = MySqlDbType.MediumBlob;
                                break;
                            case "longblob":
                                fieldType = MySqlDbType.LongBlob;
                                break;
                            case "tinytext":
                                fieldType = MySqlDbType.TinyText;
                                break;
                            case "text":
                                fieldType = MySqlDbType.Text;
                                break;
                            case "mediumtext":
                                fieldType = MySqlDbType.MediumText;
                                break;
                            case "longtext":
                                fieldType = MySqlDbType.LongText;
                                break;
                            case "enum":
                                fieldType = MySqlDbType.Enum;
                                break;
                            case "set":
                                fieldType = MySqlDbType.Set;
                                break;
                            case "binary":
                                fieldType = MySqlDbType.Binary;
                                break;
                            case "varbinary":
                                fieldType = MySqlDbType.VarBinary;
                                break;
                            case "point":
                            case "linestring":
                            case "polygon":
                            case "geometry":
                            case "multipoint":
                            case "multilinestring":
                            case "multipolygon":
                            case "geometrycollection":
                                fieldType = MySqlDbType.Geometry;
                                break;
                            default:
                                fieldType = MySqlDbType.VarChar;
                                break;
                        }
                    }
                    catch (ArgumentException)
                    {
                        i++;
                        continue;
                    }
                    result.Add(strfieldname, fieldType);
                }
                return result;
            }
            return null;
        }
    }
}
