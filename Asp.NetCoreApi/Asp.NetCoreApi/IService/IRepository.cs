using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreApi.IService
{
    public interface IRepository
    {
        //#region
        //DbSet<TDBSet> Current<TDBSet>() where TDBSet : class;
        ////IQueryable And();
        //EntityEntry Add(object entity);
        //EntityEntry Update(object entity);
        //object Find(Type entityType, params object[] keyValues);
        //EntityEntry Remove(object entity);
        //int SaveChanges();
        //void RemoveRange(IEnumerable<object> entities);
        //EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //DatabaseFacade Database { get; }
        //IModel Model { get; }
        //PageModelDto GetPageData<TEntity>(int pageIndex, int pageSize) where TEntity : class;
        //PageModelDto GetPageData<TEntity>(int pageIndex, int pageSize, string ordering) where TEntity : class;
        //PageModelDto GetPageData<TEntity, TResult>(Expression<Func<TEntity, bool>> whereLambda, string ordering, int pageIndex, int pageSize, Expression<Func<TEntity, TResult>> selector) where TEntity : class;
        //#endregion


        DataTable GetDataTableResult(string sql, SqlParameter[] parameters = null);
        bool ExecuteTransactionSQLList(List<string> sqlList);
        int Execute(string strSQL);
        object ExecuteScalar(string strSQL);
        List<string> ExecuteSingleFieldValueList(string strSQL);
        bool ExecuteTransaction(string strSQL);
        string InsertByParamsReturnSQL(string tabName, IDictionary<string, object> fieldValueDiction, bool releaseObj = false);
        string UpdateByParamsReturnSQL(string tabName, IDictionary<string, object> fieldValueDiction, bool releaseObj = false, string useField = "");
    }
}
