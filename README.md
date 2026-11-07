# HackatonSimpleAPP — repo demonstracyjne SupplyGuard

To repozytorium jest **celem skanowania** na demo projektu SupplyGuard. Zawiera szkielet aplikacji „AgentShop”
(.NET 10 + mały frontend npm) oraz konfiguracje serwerów MCP, które SupplyGuard analizuje:

- **Radar** czyta manifesty zależności (`Directory.Packages.props`, `src/AgentShop/AgentShop.csproj`, `web/package.json`)
  i sprawdza commity w repozytoriach źródłowych paczek.
- **Strażnik** czyta konfiguracje MCP (`.vscode/mcp.json`, `.mcp.json`) i ocenia opisy narzędzi serwerów.

## ⚠️ Ostrzeżenie

- Konfiguracja MCP w tym repo **celowo wskazuje na zatruty serwer demo** (`invoice-tools`) oraz serwer z „rug pull”
  (`weather`). **Nie używaj tej konfiguracji z własnym agentem AI** (VS Code, Claude Code, Cursor itp.).
- Ładunek zatrutego serwera jest nieszkodliwy — to wyłącznie znacznik (canary token) do wykrycia przez SupplyGuard.
- Wpisy stdio (`filesystem`, `crm-db`, `notes`) służą **wyłącznie do analizy statycznej**. Nie uruchamiaj ich —
  część paczek jest fikcyjna (`@fabrikam/*`, `@contoso/*`), a wartość `CRM_API_KEY` to placeholder, nie sekret.
- Adresy `http://localhost:5098/...` wskazują lokalną instancję SupplyGuard (profil `http`); w wersji docelowej
  zostaną podmienione na adres wdrożenia.

## Budowanie

```
dotnet build
```

Wersje paczek są celowo starsze niż najnowsze — to materiał do analizy, nie wzorzec do naśladowania.

## Testy

```
dotnet test                                   # xunit, tests/AgentShop.Tests
(cd web && npm ci && npm test)                # node:test
(cd scripts && python3 -m venv .venv && .venv/bin/pip install -r requirements.txt && .venv/bin/pytest)
```
