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
        //свойство для предоставления возможности выбирать сохранять ли сущность в БД
        public bool AutoSaveChanges { get; set; } = true;
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
            //Добавляем возможность вызывать метод сохранения записей в БД вручную
            //(полезно при необходимости пакетного добавления=повышение быстродействия)
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancellation = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancellation).ConfigureAwait(false);
            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancellation = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }
        public void Delete(int id)
        {
            //Можно получить сущность по ее идентификатору и затем удалить,
            //но если сущность большая, процесс извлечения ее из БД может занять слишком много времени
            //var item = Get(id);
            //if (item is null) return;
            //_db.Entry(item);

            //Лучше взять создать новую сущность и у нее установить id той, которую нужно удалить
            //В этом случае можно не указывать все остальные поля сущности, а только указать первичный ключ
            //При этом сущность будет удалена из БД и не придется передавать кучу данных
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                _db.SaveChanges();
            //но в этом случае можно и не узнать, что сущность была реально удалена (есть нюансы, проверить!)

        }

        public async Task DeleteAsync(int id, CancellationToken cancellation = default)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }


        
    }

}
