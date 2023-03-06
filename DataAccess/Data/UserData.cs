using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _dataAccess;

    public UserData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<UserModel>> GetUsers() => _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) => _dataAccess.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) => _dataAccess.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) => _dataAccess.SaveData("dbo.spUser_Delete", new { Id = id });
}
