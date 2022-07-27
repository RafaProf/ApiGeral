using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.Login
{
    internal interface ILogin
    {
        bool Add(Login item);
        Login AddPadrao(Login item);
    }
}
