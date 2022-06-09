using Preload_Data.Models;
using Preload_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preload_Data.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        DatabaseService _databaseService;

        public MainViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Symbol>> LoadExchanges()
        {
            return await _databaseService.LoadExchangesAsync();
        }
    }
}
