using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.Getlocation
{
    public interface IGetLocation
    {

        IEnumerable<GetLocation> GetAll();
        GetLocation Get(double Lc_id);
        bool Update(GetLocation location);
        GetLocation Add(GetLocation item);
    }
}