using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.ProduçãoIP
{
    internal interface IProdGeralIp
    {
        IEnumerable<ProdGeralIp> GetAll();
        ProdGeralIp Get(int id);
        ProdGeralIp Get(string dataInicial);
        bool Update(ProdGeralIp location);
        bool Add(ProdGeralIp item);
    }
}
