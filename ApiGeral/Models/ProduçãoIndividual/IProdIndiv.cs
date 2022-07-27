using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.ProduçãoIndividual
{
    internal interface IProdIndiv
    {
        IEnumerable<ProdIndiv> GetAll();
        ProdIndiv Get(int id);
        ProdIndiv Get(string data);
        bool Update(ProdIndiv prodIndiv);
        bool Add(ProdIndiv item);
    }
}
