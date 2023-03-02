using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storepRrocedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await dbConnection.QueryAsync<T>(storepRrocedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storepRrocedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString(connectionId));

        await dbConnection.ExecuteAsync(storepRrocedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
