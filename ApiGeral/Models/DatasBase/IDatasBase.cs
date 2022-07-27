using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.DatasBase
{
    internal interface IDatasBase
    {

        bool Add(DatasBase item);
        DatasBase AddPadrao(DatasBase item);
    }
}
