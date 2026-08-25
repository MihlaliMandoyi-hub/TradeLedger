using SQLite;

namespace FxLedger.Models;

public class StrategyTag
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Hex color string, e.g. "#3DBE6C", used to visually distinguish tags in lists
    public string ColorHex { get; set; } = "#6E85A6";
}
