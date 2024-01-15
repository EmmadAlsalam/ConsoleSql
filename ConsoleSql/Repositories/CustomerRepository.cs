using ConsoleSql.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConsoleSql.Repositories;

internal class CustomerRepository(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public int Create(CustomersEntity entity)
    {
        using var conn = new SqlConnection(_connectionString);
        var result = conn.ExecuteScalar<int>(@"
    IF NOT EXISTS (SELECT 1 FROM Customars WHERE Email = @Email)
    BEGIN
        INSERT INTO Customars (FirstName, LastName, Email, PhoneNumder, AddressId)
        OUTPUT INSERTED.Id
        VALUES (@FirstName, @LastName, @Email, @PhoneNumder, @AddressId)
    END
    ELSE
    BEGIN
        SELECT Id FROM Customars WHERE Email = @Email
    END",
    entity);


        return result;

    }


}
