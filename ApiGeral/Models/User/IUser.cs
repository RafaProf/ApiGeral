using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGeral.Models.User
{
    internal interface IUser
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        bool Update(User location);
        bool Add(User item);
    }
}
