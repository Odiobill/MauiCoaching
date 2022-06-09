using Preload_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preload_Data.ViewModels
{
    public partial class ExchangesViewModel : BaseViewModel
    {
        DatabaseService _databaseService;

        public ExchangesViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}
