# TradeLedger

TradeLedger is a private, offline-first forex trade journal built with .NET MAUI and C#. It helps traders record positions, review risk discipline, and understand performance without relying on cloud services or spreadsheets.

## Highlights

- Create, edit, view, and permanently delete open or closed trades
- Capture currency pair, direction, entry/exit prices, lot size, stop loss, take profit, dates, notes, and strategy tag
- Live price-movement and R-multiple preview while entering a trade
- Local SQLite storage: all journal data remains on the device
- Dashboard metrics for trade count, win rate, average R, and safe realized P&L
- Reusable strategy tags with add, rename, and protected delete behaviour
- Trade list filters for all, open, and closed positions
- Warm light theme and a matching dark theme, with locally saved preferences
- Account-currency preference stored locally

## Why P&L is handled carefully

TradeLedger calculates realized P&L automatically for standard six-letter forex pairs only (for example, `EURUSD` and `USDJPY`). It uses price movement and standard lot size, then shows a dashboard total only when the trade's quote currency matches the configured account currency.

This avoids pretending that all instruments share the same pip value. Indices, metals, and cross-currency conversions require instrument-specific contract sizes or conversion data, so they are intentionally excluded from the automatic total for now.

## Tech stack

- .NET 8 MAUI
- C# and XAML
- Shell navigation
- SQLite via `sqlite-net-pcl`
- Dependency injection
- `Preferences` for device-local settings
- MVVM-ready project structure

## Project structure

```text
TradeLedger/
├── Models/          Trade, StrategyTag, TradeDirection
├── Pages/           Dashboard, trade list, detail, add/edit, tags, settings
├── Services/        SQLite database service
├── Resources/       Fonts, icons, splash screen, and shared assets
├── App.xaml         Shared theme resources and control styles
├── AppShell.xaml    Tab navigation
└── MauiProgram.cs   App startup and dependency registration
```

## Run locally

### Prerequisites

- Visual Studio 2022 with the **.NET Multi-platform App UI development** workload
- .NET 8 SDK
- Android emulator/device or Windows Machine target

### Steps

1. Clone this repository.
2. Open `TradeLedger.sln` in Visual Studio.
3. Restore NuGet packages if Visual Studio does not do so automatically.
4. Select **Build > Rebuild Solution**.
5. Choose a target such as **Windows Machine** or an Android emulator.
6. Press **F5**.

## Screens

- **Home** — discipline-focused dashboard and performance summary
- **Trades** — filterable list of open and closed trades
- **Trade Detail** — full trade record, computed stats, edit, and delete actions
- **New/Edit Trade** — validated form with live calculations
- **Tags** — reusable strategy setup management
- **Settings** — account currency and light/dark preference

## Roadmap

- Instrument-specific P&L settings for indices and metals
- Offline conversion-rate support for cross-currency account P&L
- Trade screenshots and chart annotations
- CSV import/export and local backups
- Performance charts by strategy, pair, and time period

## Privacy

Version 1 is designed for personal use. Trade data is stored locally in a SQLite database on the device; no sign-in, cloud sync, ads, or analytics are required.

---

Built as a portfolio project to demonstrate mobile-first product design, local persistence, financial-data validation, and cross-platform .NET MAUI development.
