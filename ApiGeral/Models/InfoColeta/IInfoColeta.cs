﻿using ApiGeral.Models.Getlocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.InfoColeta
{
    internal interface IInfoColeta
    {
        IEnumerable<InfoColeta> GetAll();
        InfoColeta Get(double Lc_id);
        bool Update(InfoColeta location);
        InfoColeta Add(InfoColeta item);
    }
}
