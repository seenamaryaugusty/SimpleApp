using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibraries
{
    public interface ISearchModel
    {
        bool LoadSearchItemsToLocal(string searchWord);

        string[] GetSearchItems();

        void CleanLocal();
    }
}
