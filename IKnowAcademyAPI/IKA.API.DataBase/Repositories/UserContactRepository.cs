using IKA.API.DataBase.DbContext;
using IKA.API.DataBase.Entities.UserContact;

namespace IKA.API.DataBase.Repositories;

public sealed class UserContactRepository:IRepository<UserContact,AppDbContext>
{
    public AppDbContext _DbContext { get; set; }
    public Task Add(UserContact? entity)
    {
        _DbContext.Users.Add(entity);
        return _DbContext.SaveChangesAsync();
    }

    public Task Update(UserContact? entity)
    {
        _DbContext.Users.Update(entity);
        return _DbContext.SaveChangesAsync();
    }

    public Task Delete(UserContact? entity)
    {
        _DbContext.Users.Remove(entity);
        return _DbContext.SaveChangesAsync();
    }

    public async Task<UserContact?> GetById(int id)
    {
        return await _DbContext.Users.FindAsync(id);
    }
}