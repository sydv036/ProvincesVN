using LearnOneProvincesVN.Domain.Request;
using LearnOneProvincesVN.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service.implement
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly IAccountReponsitory _accountReponsitory;

        public AccountServiceImpl(IAccountReponsitory accountReponsitory)
        {
            _accountReponsitory = accountReponsitory;
        }
        public async Task<bool> Register(Register model)
        {
            var email = await _accountReponsitory.FinByEmail(model.Email);
            var userName = await _accountReponsitory.FinByUserName(model.UserName);
            if (email == null || userName == null)
            {
                var result = await _accountReponsitory.Register(model);
                if (result.Succeeded)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<string> Signin(SignIn signIn)
        {
            var result = await _accountReponsitory.SignIn(signIn);
            if (result != null)
            {
                return result.ToString();
            }
            return null;
        }
    }
}
