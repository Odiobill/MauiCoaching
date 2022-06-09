using CommunityToolkit.Mvvm.ComponentModel;

namespace Preload_Data.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _title;
    }
}
