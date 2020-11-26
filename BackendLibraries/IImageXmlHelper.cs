using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibraries
{
    public interface IXmlHelper
    {
        string[] GetSearchArray();

        bool LoadXmlDataToLocal(string searchWord);
    }
}
