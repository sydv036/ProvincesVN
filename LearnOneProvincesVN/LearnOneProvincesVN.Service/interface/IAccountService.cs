using LearnOneProvincesVN.Domain.Request;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service
{
    public interface IAccountService
    {
        Task<bool> Register(Register model);
        Task<string> Signin(SignIn signIn);
    }
}
