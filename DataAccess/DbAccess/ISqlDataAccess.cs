namespace DataAccess.DbAccess;

public  interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storepRrocedure, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storepRrocedure, T parameters, string connectionId = "Default");
}