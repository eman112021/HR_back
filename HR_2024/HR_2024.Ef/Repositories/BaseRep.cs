using HR_2024.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Ef.Repositories
{
    public class BaseRep<T> : IbaseRep<T> where T : class
    {
        public readonly AppCon _appCon;
        public BaseRep(AppCon appCon)
        { 
            _appCon = appCon;
        }
        public async Task<T> add(T data)
        {
            try
            {
                await _appCon.Set<T>().AddAsync(data);
            
                return data;
            }
            
            catch (Exception ex) { return null; }

        }

        public async Task<T> update(T data)
        {
            // throw new NotImplementedException();
            try
            {
               // var result=  _appCon.Set<T>().Update(data);
            var result = _appCon.Update(data);
            return data;
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> delete(T data)
        {
            try
            {
                _appCon.Set<T>().Remove(data);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<T> Get(int id)
        {
            try
            {

                // throw new NotImplementedException();
                var result = _appCon.Set<T>().Find(id);
                
                return result;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<List<T>> GetAll()
        {
            
            return await _appCon.Set<T>().ToListAsync();
        }

        // public async Task<List<T>> search<Tresult>(Expression<Func<T, bool>> sel, Expression<Func<T, bool>> math)
       public async  Task<List<TResult>> search<TResult>(Expression<Func<T, bool>> math = null, Expression<Func<T, TResult>> sel = null)
       {
             //  throw new NotImplementedException();
            //  return await  _appCon.Set<T>().Where(math).Select(sel).ToListAsync();
            

            List<TResult> test;
            IQueryable<T> query = _appCon.Set<T>();
            if (math != null)
            {
                query = query.Where(math);
            }

            if (sel != null)
            {
                //query =( IQueryable < T > ) query.Select(sel);
                var query_test = query.Select(sel);
                // return await query.Select(sel).ToListAsync();
                return await query_test.ToListAsync();

            }
            else
            {
                return await query.Cast<TResult>().ToListAsync();
            }

        }

        public async Task<T> find(Expression<Func<T, bool>> math)
        {
            return await _appCon.Set<T>().AsNoTracking().SingleOrDefaultAsync(math);
        }

        //  public async Task<T> findwithinclude(Expression<Func<T, bool>> math, string include)
       
             public async Task<T> findwithinclude(Expression<Func<T, bool>> math, Expression<Func<T, object>> include, bool asNoTracking = false)
   // public async Task<T> findwithinclude(Expression<Func<T, bool>> math, Expression<Func<T, object>> include)
        {
            IQueryable<T> query= _appCon.Set<T>();
            //query = query.Where(math);
            if (include != null)
            //{
                query=  query.Include(include);
            //}
            if (asNoTracking)
                query = query.AsNoTracking();

            query = query.Where(math);
             var x= await query.FirstOrDefaultAsync();
            return x;

        }



    }
}
