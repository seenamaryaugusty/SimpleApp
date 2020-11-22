using ModelLibraries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using System.IO;
using BackendLibraries;
using Backend;

namespace ImageAppModels
{
    public class ImageSearchModel:IImageSearchModel
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
        public string[] GetStaticImageUrls()
        {
            return this.imageXmlHelper.GetStaticImageUrls();
        }

        public void CleanLocal()
        {
            this.fileHelper.CleanLocal();
        }
        public bool LoadImagesToLocal(string searchWord)
        {
            this.CleanLocal();
            return this.imageXmlHelper.LoadImagesToLocal(searchWord);
        }
    }
}
