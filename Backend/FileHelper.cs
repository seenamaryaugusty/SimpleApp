using BackendLibraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class FileHelper:IFileHelper
    {
        private const string path = @"c:\photos.xml";
        public void CleanLocal()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
