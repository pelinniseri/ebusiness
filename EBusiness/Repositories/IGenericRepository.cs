using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace EBusiness.Repositories
{
    public abstract class IGenericRepository<T> where T : class, new()
    {
        public abstract List<T> TList();
        public abstract bool TAdd(T p);

        public abstract void TDelete(T p);
        public abstract void TUpdate(T p);
        public abstract T TFind(int id);
        public abstract List<T> TList(string p);
        public abstract List<T> List(Expression<Func<T, bool>> filter);
    }
}
