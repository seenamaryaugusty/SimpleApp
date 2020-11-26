using ModelLibraries;
using BackendLibraries;
using Backend;

namespace AppModels
{
    public class SearchModel:ISearchModel
    {
        private IXmlHelper xmlHelper;
        private IFileHelper fileHelper;
        public SearchModel():this(new ImageXmlHelper(),new FileHelper())
        {
        }

        public SearchModel(IXmlHelper xmlHelper,IFileHelper fileHelper)
        {
            this.xmlHelper = xmlHelper;
            this.fileHelper = fileHelper;
        }
        public string[] GetSearchItems()
        {
            return this.xmlHelper.GetSearchArray();
        }

        public void CleanLocal()
        {
            this.fileHelper.CleanLocal();
        }
        public bool LoadSearchItemsToLocal(string searchWord)
        {
            this.CleanLocal();
            return this.xmlHelper.LoadXmlDataToLocal(searchWord);
        }
    }
}
