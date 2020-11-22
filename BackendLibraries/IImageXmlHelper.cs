using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibraries
{
    public interface IImageXmlHelper
    {
        string[] GetStaticImageUrls();

        bool LoadImagesToLocal(string searchWord);
    }
}
