using SQLite;
using FxLedger.Models;

namespace FxLedger.Data;

public class DatabaseService
{
    private SQLiteAsyncConnection? _connection;

    // Lazily opens the connection and ensures tables exist.
    // Every public method calls this first so callers never need to worry about init order.
    private async Task InitAsync()
    {
        if (_connection is not null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "fxledger.db3");
        _connection = new SQLiteAsyncConnection(dbPath);

        await _connection.CreateTableAsync<Trade>();
        await _connection.CreateTableAsync<StrategyTag>();
    }

    // ---------- Trade CRUD ----------

    public async Task<List<Trade>> GetTradesAsync()
    {
        await InitAsync();
        return await _connection!.Table<Trade>()
            .OrderByDescending(t => t.OpenDate)
            .ToListAsync();
    }

    public async Task<List<Trade>> GetOpenTradesAsync()
    {
        await InitAsync();
        return await _connection!.Table<Trade>()
            .Where(t => t.IsOpen)
            .OrderByDescending(t => t.OpenDate)
            .ToListAsync();
    }

    public async Task<List<Trade>> GetClosedTradesAsync()
    {
        await InitAsync();
        return await _connection!.Table<Trade>()
            .Where(t => !t.IsOpen)
            .OrderByDescending(t => t.OpenDate)
            .ToListAsync();
    }

    public async Task<Trade?> GetTradeAsync(int id)
    {
        await InitAsync();
        return await _connection!.Table<Trade>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
    }

    // Returns the new row's Id (SQLite auto-assigns it on insert)
    public async Task<int> SaveTradeAsync(Trade trade)
    {
        await InitAsync();

        if (trade.Id != 0)
        {
            await _connection!.UpdateAsync(trade);
            return trade.Id;
        }
        else
        {
            await _connection!.InsertAsync(trade);
            return trade.Id;
        }
    }

    public async Task<int> DeleteTradeAsync(Trade trade)
    {
        await InitAsync();
        return await _connection!.DeleteAsync(trade);
    }

    // ---------- StrategyTag CRUD ----------

    public async Task<List<StrategyTag>> GetStrategyTagsAsync()
    {
        await InitAsync();
        return await _connection!.Table<StrategyTag>()
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<StrategyTag?> GetStrategyTagAsync(int id)
    {
        await InitAsync();
        return await _connection!.Table<StrategyTag>()
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveStrategyTagAsync(StrategyTag tag)
    {
        await InitAsync();

        if (tag.Id != 0)
        {
            await _connection!.UpdateAsync(tag);
            return tag.Id;
        }
        else
        {
            await _connection!.InsertAsync(tag);
            return tag.Id;
        }
    }

    public async Task<int> DeleteStrategyTagAsync(StrategyTag tag)
    {
        await InitAsync();
        return await _connection!.DeleteAsync(tag);
    }
}