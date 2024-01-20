using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    //Создаем интерфейс для работы с БД и ограничиваем тип шаблона (должен быть класс, 
    //реализующий интерфейс сущности и должен иметь конструктор без параметров
    public interface IDbWorker<T> where T : class, IEntity, new()
    { 
        //У каждого класса, реализующего интерфейс будет свойство Items, через которое можно будет получить 
        //все, что хранится внутри
        IQueryable<T> Items { get; }
        //Метод будет возвращать сущность по идентфикатору
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancellation=default);
        //Метод для добавления сущности и возврата ее
        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken cancellation = default);
        void Update(T item);
        Task UpdateAsync(T item, CancellationToken cancellation = default);
        void Delete(int id);
        Task DeleteAsync(int id, CancellationToken cancellation = default);
    }
}
