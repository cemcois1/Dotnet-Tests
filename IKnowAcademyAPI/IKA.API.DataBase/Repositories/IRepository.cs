using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Repositories;

/// <typeparam name="T1"> Type of entity
/// </typeparam>
/// <typeparam name="T2"> Type of DbContext
/// </typeparam>
internal interface IRepository<T1,T2> where T1:IBaseEntity where T2:Microsoft.EntityFrameworkCore.DbContext
{
    public T2 _DbContext { get; set; }
    public Task Add(T1 entity);
    public Task Update(T1 entity);
    public Task  Delete(T1 entity);
    public Task<T1?> GetById(int id);
}