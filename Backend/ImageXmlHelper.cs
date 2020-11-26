using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Xml.XLinq;
using System.Data.DLinq;
using System.IO;
using BackendLibraries;

namespace Backend
{
    public class ImageXmlHelper: IXmlHelper
    {
        private const string FLICKR_API_KEY = "b67af3f67d6c2e519ee192a00ac1e53f";
        private const string url = "http://www.flickr.com/services/rest/?method=flickr.photos.search&api_key=" + FLICKR_API_KEY + "&text=";
        private const string path = @"c:\photos.xml";

        // Gets static image Urls
        public string[] GetSearchArray()
        {
            string[] ImageUrls = new string[10];
            if (File.Exists(path))
            {
                ImageUrls = XDocument.Load(path).Descendants("url")
                  .Select(element => element.Value).ToArray();
            }
            return ImageUrls;
        }

        public bool LoadXmlDataToLocal(string searchWord)
        {
            try
            {
                var xraw = XElement.Load(url + searchWord);
                var xroot = XElement.Parse(xraw.Xml);

                // Take few xml data and convert to a concise xml and store it in local
                var photos = (from photo in xroot.Element("photos").Elements("photo")
                              select new PhotoInfo
                              {
                                  Id = (string)photo.Attribute("id"),
                                  Owner = (string)photo.Attribute("owner"),
                                  Title = (string)photo.Attribute("title"),
                                  Secret = (string)photo.Attribute("secret"),
                                  Server = (string)photo.Attribute("server"),
                                  Farm = (string)photo.Attribute("Farm"),
                              });
                //.Skip(pageIndex * columns * rows).Take(columns * rows);

                //then write results out to a file
                XDocument photosDoc = new XDocument();
                XElement photosElement = new XElement("photos", from pi in photos
                                                                select new XElement("photo",
                                                                    new XElement("url", pi.PhotoUrl(false)),
                                                                    new XElement("title", pi.Title))
                    );
                photosDoc.Add(photosElement);
                photosDoc.Save(@"c:\photos.xml");
                return true;

            }
            catch (Exception ex)
            {
                // * FutureImprovement : logging and exception handling
                return false;
            }
        }
    }
}
