﻿using ModelLibraries;
using BackendLibraries;
using Backend;

namespace AppModels
{
    public class ImageSearchModel:ISearchModel
    {
        private IImageXmlHelper imageXmlHelper;
        private IFileHelper fileHelper;
        public ImageSearchModel():this(new ImageXmlHelper(),new FileHelper())
        {
        }

        public ImageSearchModel(IImageXmlHelper imageXmlHelper,IFileHelper fileHelper)
        {
            this.imageXmlHelper = imageXmlHelper;
            this.fileHelper = fileHelper;
        }
        public string[] GetSearchItems()
        {
            return this.imageXmlHelper.GetStaticImageUrls();
        }

        public void CleanLocal()
        {
            this.fileHelper.CleanLocal();
        }
        public bool LoadSearchItemsToLocal(string searchWord)
        {
            this.CleanLocal();
            return this.imageXmlHelper.LoadImagesToLocal(searchWord);
        }
    }
}
