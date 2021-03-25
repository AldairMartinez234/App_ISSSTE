using App_ISSSTE.Models;
using App_ISSSTE.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App_ISSSTE.Helpers
{
    class LoginService
    {
        ApiService<Users> _restClient = new ApiService<Users>();

        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.LoginAsync(username, password);

            return check;
        }
    }
}
