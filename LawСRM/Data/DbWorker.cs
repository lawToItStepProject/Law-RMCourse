using LawСRM.Interfaces;
using LawСRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LawСRM.Data
{
    internal class DbWorker<T> : IDbWorker<T> where T : Entity, new()
    {
        private readonly LawCRMDb _db;
        //свойство набора данных
        private readonly DbSet<T> _Set;
        public DbWorker(LawCRMDb db)
        {
            _db = db;
            _Set=db.Set<T>();
        }
        //ключевое свойство, позволяющее работать с БД, нужно перегрузить в наследника
        public virtual IQueryable<T> Items => _Set;

        //Метод извлечения одной сущности, если она найдена - вернется из БД, если не найдена - null,
        //а если будет больше чем одна запись - будет исключение (даст возможность понять, что в БД
        //есть какая-то проблема с первичным ключом
        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);
        

        public async Task<T> GetAsync(int id, CancellationToken cancellation = default)
            =>await Items.SingleOrDefaultAsync(item=> item.Id == id, cancellation)
                .ConfigureAwait(false);

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChangesAsync();
            return item;
        }

        public Task<T> AddAsync(int item, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }


        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }

}
