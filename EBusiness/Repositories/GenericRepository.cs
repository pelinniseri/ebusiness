using EBusiness.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EBusiness.Repositories;
namespace EBusiness.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class, new()
    {
        
        Context c = new Context();

        public override List<T> TList()
        {
            return c.Set<T>().ToList();
        }

        public override bool TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
            return true;
        }

        public override void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public override void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public override T TFind(int id)
        {
           return  c.Set<T>().Find(id);

        }
        public override List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
        public override List<T> List(Expression<Func<T,bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
