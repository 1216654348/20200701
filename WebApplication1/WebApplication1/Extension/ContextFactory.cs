using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.IService;

namespace WebApplication1.Extension
{
    /// <summary>
    /// lzjcContext良渚上下文对象
    /// </summary>
    public partial class BaseRepository : LZModel.lzjcContext, IRepository
    {
        public BaseRepository()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ////var loggerFactory = new LoggerFactory();
                ////loggerFactory.AddProvider(new EFLoggerProvider());
                ////optionsBuilder.UseLoggerFactory(loggerFactory);
                optionsBuilder.UseMySql(ConfigurationHelper.Configuration["ConnectionStrings:MySqlConnectionStr"]);
            }
        }

        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public override object Find(Type entityType, params object[] keyValues)
        {
            return base.Find(entityType, keyValues);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public DbSet<TDBSet> Current<TDBSet>() where TDBSet : class
        {
            return base.Set<TDBSet>();
        }

        ///// <summary>
        ///// 分页
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="whereLambda"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public PageModelDto GetPageData<TEntity>(Expression<Func<TEntity, bool>> whereLambda, int pageIndex, int pageSize) where TEntity : class
        //{
        //    IQueryable<TEntity> data = whereLambda != null ? base.Set<TEntity>().Where(whereLambda) : base.Set<TEntity>();

        //    PageModelDto pageData = new PageModelDto
        //    {
        //        Data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize),
        //        Total = data.Count()
        //    };
        //    return pageData;
        //}
        ///// <summary>
        /////  分页
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public PageModelDto GetPageData<TEntity>(int pageIndex, int pageSize) where TEntity : class
        //{
        //    IQueryable<TEntity> data = base.Set<TEntity>();

        //    PageModelDto pageData = new PageModelDto
        //    {
        //        Data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize),
        //        Total = data.Count()
        //    };
        //    return pageData;
        //}
        ///// <summary>
        ///// 分页
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="ordering">多个OrderBy用逗号隔开,属性前面带-号表示反序排序，exp:"name,-createtime"</param>
        ///// <returns></returns>
        //public PageModelDto GetPageData<TEntity>(int pageIndex, int pageSize, string ordering) where TEntity : class
        //{
        //    if (string.IsNullOrEmpty(ordering))
        //    {
        //        ordering = nameof(TEntity) + "Id";//默认以Id排序
        //    }
        //    var data = base.Set<TEntity>().AsQueryable().OrderByBatch(ordering);
        //    PageModelDto pageData = new PageModelDto
        //    {
        //        Data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize),
        //        Total = data.Count()
        //    };
        //    return pageData;
        //}

        //public PageModelDto GetPageData<TEntity, TResult>(Expression<Func<TEntity, bool>> whereLambda, string ordering, int pageIndex, int pageSize, Expression<Func<TEntity, TResult>> selector) where TEntity : class
        //{
        //    if (string.IsNullOrEmpty(ordering))
        //    {
        //        //ordering = nameof(TEntity) + "Id";//默认以Id排序
        //        var entity = typeof(TEntity).GetProperties().Where(e => e.Name == "Id");
        //        if (entity.Count() > 0)
        //            ordering = "Id";
        //    }
        //    var data = base.Set<TEntity>().Where(whereLambda).AsQueryable().OrderByBatch(ordering);
        //    PageModelDto pageData = new PageModelDto
        //    {
        //        Data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable().Select(selector),
        //        Total = data.Count()
        //    };
        //    return pageData;
        //}

    }
}
