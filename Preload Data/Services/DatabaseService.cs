using Preload_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Preload_Data.Services
{
    public class DatabaseService
    {
        List<Symbol> _symbols = new();

        public async Task<List<Symbol>> LoadExchangesAsync()
        {
            if (_symbols.Count > 0)
            {
                return _symbols;
            }

            using Stream stream = await FileSystem.OpenAppPackageFileAsync("ExchangesList.json");
            using StreamReader reader = new(stream);
            string content = await reader.ReadToEndAsync();
            List<Exchange> exchanges = JsonSerializer.Deserialize<List<Exchange>>(content);
            foreach (Exchange exchange in exchanges)
            {
                if (exchange.OperatingMIC?.Length > 0)
                {
                    string fileName = $"Exchanges/{exchange.Code}.json";
                    bool exists = await FileSystem.AppPackageFileExistsAsync(fileName);
                    if (exists)
                    {
                        using Stream exchangeStream = await FileSystem.OpenAppPackageFileAsync(fileName);
                        using StreamReader exchangeReader = new(exchangeStream);
                        content = await exchangeReader.ReadToEndAsync();
                        AddSymbols(JsonSerializer.Deserialize<List<Symbol>>(content));
                    }
                }
            }

            return _symbols;
        }

        void AddSymbols(List<Symbol> symbols)
        {
            _symbols.AddRange(symbols);
        }
    }
}
