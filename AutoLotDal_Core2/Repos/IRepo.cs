using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoLotDal_Core2.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int Add(IList<T> entities);
        int Update(T entity);
        int Update(IList<T> entities);
        int Delete(T entity);
        int Delete(int id, byte[] timeStamp);
        T GetOne(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}