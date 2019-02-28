using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DouStatistics.DAL.Interfaces;

namespace DouStatistics.DAL.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DouStatisticsDbContext _context;
        private readonly DbSet<T> _dB;

        public GenericRepository()
        {
            _context = new DouStatisticsDbContext();
            _dB = _context.Set<T>();
        }
        ///<summary>
        /// Сохранить елемент в БД
        ///</summary>
        public void Create(T model)
        {
            _dB.Add(model);
            _context.SaveChanges();
        }

        ///<summary>
        /// Получить все данные таблицы БД
        ///</summary>
        public List<T> GetAll()
        {
            return _dB.AsNoTracking().ToList();
        }

        ///<summary>
        /// Получить запись в таблице БД по id
        ///</summary>
        public T Get(int id)
        {
            return _dB.Find(id);
        }

        ///<summary>
        /// Обновить запись в таблице БД
        ///</summary>
        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        ///<summary>
        /// Удалить запись из таблицы БД
        ///</summary>
        public void Delete(T model)
        {
            _dB.Remove(model);
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
