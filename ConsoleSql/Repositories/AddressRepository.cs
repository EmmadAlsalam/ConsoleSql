using ConsoleSql.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConsoleSql.Repositories;

internal class AddressRepository(string connectionString)
{
    private readonly string _connectionString = connectionString;


    public int Create(AdressEntity entity)
    {

        using var conn = new SqlConnection(_connectionString);
         var result = conn.ExecuteScalar<int>("IF NOT EXISTS (SELECT 1 FROM Adresses WHERE StreetName=@StreetName AND PostalCode= @PostalCode AND City=@City ) INSERT INTO Adresses OUTPUT INSERTED.Id VALUES ( @StreetName, @PostalCode,  @City) ", entity);


        return result;

    }

}
