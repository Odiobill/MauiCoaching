# MauiCoaching

Hi! The Preload_Data solution is basically a new, default MAUI project with the following changes:

- The default **MainPage.xml[.cs]** files have been moved into _Views_. There is also a dedicated _ViewModel_, with some extra code, that I will explain later.
- There is an extra **ExchangesPages.xml[.cs]** view, with a dedicated _ViewModel_. It is just the default page tha VS creates when adding a new XAML item.
- The projects contains the **Community MVVM** package, already included and used by the above mentioned Views and ViewModels.
- You can find a simple service class under **Services/DatabaseService.cs**
- Inside _Resources/Raw_, there is an _ExchangesList.json_ file which contains a list of all the supported exchanges.
- Inside _Resources/Raw/Exchanges_ there are many json files, up to one for every exchange mentioned in the previous file. In fact, there is one less, which I moved outside the _Symbols_ directory, for reasons that I'll explain below.'
- There are two _Models_ that describe the information contained in the above mentioned json files: **Echanges.cs** and **Symbol.cs**.
- **MauiProgram.cs** is updates to include the **Community Toolkit** package and to add the above mentioned service, views and viewmodels as _singleton/transients_.


The *DatabaseService.cs* class contains an async Task for loading the list of exchanges from _ExchangesList.json_.
For each exchange, it checks if there is any information in the _OperatingMIC_ field. if not, it skips to the next one (I don't need any information for virtual exchanges without a MIC code).
If there is a string in that field, then it checks if a specific json file (within _Resources/Raw/Exchanges_), checking the _Code_ field: this way I can decide to exclude any exchange by simply deleting deleting or moving the file, as I did for _FOREX.json_: I don't want to include those symbols in the app, but at later stages I will need that file to calculate currency conversions at any date.

This task is intended to be executed on application start, but currently it is taken care from the code-behid of _MainPage.xml_, overrideing **OnAppearing()**.

I used **MainPage** just because it is the first page being loaded by _Shell_, but that's not ideal: I think it would be better if this data is loaded somewhere else, because it's not something that should be taken care by a _view_.
Unfortunately, it seems that I can't use _dependency injection_ if I try to move that i.e. to **AppShell.xml.cs**, so the first goal of the coaching would indeed be moving this code somewhere more suitable and generic.

The second goal of our first coaching would be populating the second page with the list of the exchanges that the service already loaded.
There are of course some more questions but those will be asked during the session.



