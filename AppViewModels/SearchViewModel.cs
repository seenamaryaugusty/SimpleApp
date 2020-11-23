using ModelLibraries;
using System.Windows.Input;
using AppModels;
using System.Collections.ObjectModel;

namespace AppViewModels
{
    public class SearchViewModel : BindableBase
    {
        private string searchWord = null;
        public ICommand Search { get; set; }
        public ISearchModel model { get; set; }


        public SearchViewModel() : this(new ImageSearchModel()) // Datacontext being set in the view for now, therefore parameterless constructor is used
        { }
        public SearchViewModel(ISearchModel model) //for testing purpose
        {
            this.model = model;
            this.model.CleanLocal();
            this.Search = new RelayCommand<object>(this.SearchHandler);
        }

        public ObservableCollection<string> SearchItems
        {
            get
            {
                var results = new ObservableCollection<string>(this.model.GetSearchItems());
                return results;
            }
        }

        private void SearchHandler(object searchWord)
        {
            this.searchWord = searchWord.ToString();
            if (this.model.LoadSearchItemsToLocal(searchWord.ToString()))
            {
                NotifyPropertyChanged(nameof(this.SearchItems));

            }
        }
    }
}
