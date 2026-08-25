using SQLite;

namespace FxLedger.Models;

public class Trade
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    // e.g. "EUR/USD", "USD/JPY"
    public string CurrencyPair { get; set; } = string.Empty;

    public Direction Direction { get; set; }

    public decimal EntryPrice { get; set; }

    // Nullable because the trade may still be open
    public decimal? ExitPrice { get; set; }

    public decimal LotSize { get; set; }

    public decimal? StopLoss { get; set; }

    public decimal? TakeProfit { get; set; }

    public DateTime OpenDate { get; set; } = DateTime.Now;

    // Nullable because the trade may still be open
    public DateTime? CloseDate { get; set; }

    // Foreign-key style reference to StrategyTag.Id — nullable because tagging is optional
    public int? StrategyTagId { get; set; }

    public string? Notes { get; set; }

    // True while the trade has no ExitPrice/CloseDate set
    public bool IsOpen { get; set; } = true;
}
