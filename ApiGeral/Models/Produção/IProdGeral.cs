using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.Produção
{
    internal interface IProdGeral
    {
        IEnumerable<ProdGeral> GetAll();
        ProdGeral Get(int id);
        ProdGeral Get(string dataInicial);
        bool Update(ProdGeral location);
        bool Add(ProdGeral item);
    }
}
