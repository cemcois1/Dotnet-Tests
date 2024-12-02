namespace IKA.API.DataBase.Entities.Base;

public abstract class BaseEntity: IBaseEntity
{
    public required int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}