using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace HR_2024.Core.Interface
{
    public interface IbaseRep<T> where T : class
    {
        Task<T> add(T data);
       
        Task<T> update(T data);
        Task<bool> delete(T data);
       
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        // Task<List<T>> search(Expression<Func<T, bool>> sel, Expression<Func<T,bool>> math); 
        Task<T> find( Expression<Func<T, bool>> math);

        Task<List<TResult>> search<TResult>(Expression<Func<T,bool>> math=null,Expression<Func<T,TResult>> sel=null);
        // Task<List<TResult>> findall<TResult>(Expression<Func<T, bool>> fun, Expression<Func<T, TResult>> sel);

       // Task<T> findwithinclude(Expression<Func<T,bool>> math,string include);
       
        // Task<T> findwithinclude(Expression<Func<T, bool>> math, Expression<Func<T, object>> include);
        Task<T> findwithinclude(Expression<Func<T, bool>> math, Expression<Func<T, object>> include, bool asNoTracking = false);
       
    }
}
