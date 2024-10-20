using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using Npgsql;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class AreasRepository : Repository, IAreasRepository
{
    public AreasRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<Area> AddAsync(Area area)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            var insertAddressCommand = connection.CreateCommand();
            insertAddressCommand.CommandText = "INSERT INTO Areas (Id, Name, Url) VALUES(@Id, @Name, @Url)";

            insertAddressCommand.Parameters.AddWithValue("@Id", area.Id);
            insertAddressCommand.Parameters.AddWithValue("@Name", area.Name);
            insertAddressCommand.Parameters.AddWithValue("@Url", area.Url);
            
            await insertAddressCommand.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
        return area;
    }
}
