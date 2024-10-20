using Data.Repositories.Classes.Base;
using Data.Repositories.Interfaces.Derived;
using Domain;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Derived;
public sealed class AddressesRepository : Repository, IAddressesRepository
{
    public AddressesRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<Address> AddAsync(Address address)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            var insertAddressCommand = connection.CreateCommand();
            insertAddressCommand.CommandText = "INSERT INTO Addresses (City,Street,Building,Raw) VALUES(@City,@Street,@Building,@Raw)";

            insertAddressCommand.Parameters.AddWithValue("@City", address.City);
            insertAddressCommand.Parameters.AddWithValue("@Street", address.Street);
            insertAddressCommand.Parameters.AddWithValue("@Building", address.Building);
            insertAddressCommand.Parameters.AddWithValue("@Raw", address.Raw);

            await insertAddressCommand.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
        return address;
    }
}
