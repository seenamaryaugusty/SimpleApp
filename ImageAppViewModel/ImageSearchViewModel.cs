using ModelLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageAppModels;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Xml.Linq;

namespace ImageAppViewModels
{
    public class ImageSearchViewModel : BindableBase
    {
        private string searchWord = null;
        public ICommand SearchImage { get; set; }
        public IImageSearchModel model { get; set; }

        public ImageSearchViewModel() : this(new ImageSearchModel()) // Datacontext being set in the view for now, therefore parameterless constructor is used
        { }
        public ImageSearchViewModel(IImageSearchModel model) //for testing purpose
        {
            this.model = model;
            this.model.CleanLocal();
            this.SearchImage = new RelayCommand<object>(this.SearchImageHandler);
        }

        public ObservableCollection<string> Images
        {
            get
            {
                var results = new ObservableCollection<string>(this.model.GetStaticImageUrls());
                return results;
            }
        }

        private void SearchImageHandler(object searchWord)
        {
            this.searchWord = searchWord.ToString();
            if (this.model.LoadImagesToLocal(searchWord.ToString()))
            {
                NotifyPropertyChanged(nameof(this.Images));

            }
        }
    }
}
