using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.UserContact;

public class UserContact:BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}