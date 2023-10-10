using LearnOneProvincesVN.Domain.Request;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory
{
    public interface IAccountReponsitory
    {
        Task<IdentityResult> Register(Register model);

        Task<IdentityUser> FinByEmail(string email);
        Task<IdentityUser> FinByUserName(string UserName);

        Task<string> SignIn(SignIn signIn);
    }
}
