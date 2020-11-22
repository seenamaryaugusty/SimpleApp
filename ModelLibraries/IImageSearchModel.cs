using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibraries
{
    public interface IImageSearchModel
    {
        bool LoadImagesToLocal(string searchWord);

        string[] GetStaticImageUrls();

        void CleanLocal();
    }
}
