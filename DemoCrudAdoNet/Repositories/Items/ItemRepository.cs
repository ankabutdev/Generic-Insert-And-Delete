using DemoCrudAdoNet.Entities.Items;
using DemoCrudAdoNet.Interfaces.Items;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DemoCrudAdoNet.Repositories.Items;

public class ItemRepository : BaseRepository, IItemRepository
{
    public async Task<bool> CreateAsync(Item entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = @"INSERT INTO Items (item_id, item_brand) VALUES (@item_id, @item_brand);";

            var command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@item_id", entity.ItemId);
            command.Parameters.AddWithValue("@item_brand", entity.ItemBrand);

            var result = Convert.ToInt32(await command.ExecuteNonQueryAsync());

            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<bool> DeleteAsync(Expression<Func<Item, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Item> SelectAll(Expression<Func<Item, bool>> expression = null)
    {
        throw new NotImplementedException();
    }

    public Task<Item> SelectAsync(Expression<Func<Item, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Item entity)
    {
        throw new NotImplementedException();
    }
}
