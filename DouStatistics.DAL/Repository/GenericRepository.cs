using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DouStatistics.DAL.Interfaces;

namespace DouStatistics.DAL.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        ///<summary>
        /// Сохранить елемент в БД
        ///</summary>
        public void Create(T model)
        {
            using (var context = new DouStatisticsDbContext())
            {
                DbSet<T> dB = context.Set<T>();

                dB.Add(model);
                context.SaveChanges();
            }
        }

        ///<summary>
        /// Получить все данные таблицы БД
        ///</summary>
        public List<T> GetAll()
        {
            using (var context = new DouStatisticsDbContext())
            {
                DbSet<T> dB = context.Set<T>();

                return dB.AsNoTracking().ToList();
            }
        }

        ///<summary>
        /// Получить запись в таблице БД по id
        ///</summary>
        public T Get(int id)
        {
            using (var context = new DouStatisticsDbContext())
            {
                DbSet<T> dB = context.Set<T>();

                return dB.Find(id);
            }
        }

        ///<summary>
        /// Обновить запись в таблице БД
        ///</summary>
        public void Update(T model)
        {
            using (var context = new DouStatisticsDbContext())
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        ///<summary>
        /// Удалить запись из таблицы БД
        ///</summary>
        public void Delete(T model)
        {
            using (var context = new DouStatisticsDbContext())
            {
                DbSet<T> dB = context.Set<T>();

                dB.Remove(model);
                context.SaveChanges();
            }
        }
    }
}
