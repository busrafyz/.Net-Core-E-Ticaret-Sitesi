using CoreFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFood.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context context = new Context();

        public List<T> TList()
        {
            return context.Set<T>().ToList();
        }

        public void TAdd(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void TDelete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }
        public void TUpdate(T t)
        {
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
        public void TGet(int id)
        {
            context.Set<T>().Find(id);
        }

        public List<T> TList(string p)
        {
            return context.Set<T>().Include(p).ToList();
        }
    }
}
