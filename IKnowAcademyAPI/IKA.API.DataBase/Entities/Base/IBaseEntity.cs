namespace IKA.API.DataBase.Entities.Base;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    bool IsDeleted { get; set; }
}