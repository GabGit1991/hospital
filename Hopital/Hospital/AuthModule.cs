using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital
{
     class AuthModule
    {

        DaoAuth daoAuth = new DaoAuth();

        public User AuthenticateUser(string login, string password)
        {

            return daoAuth.Login(login, password);
        }



    }
}
