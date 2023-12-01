using C_proj_MKMN.Models;
using Microsoft.AspNetCore.Identity;

namespace C_proj_MKMN.Services
{
    public class CustomPasswordValidator : IPasswordValidator<UserModel>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<UserModel> manager, UserModel user, string password)
        {
      
            int a = user.UserName.Length;
            int x = GenerateRandomNumber();
            string generatedPassword = GeneratePassword(a, x);

            if (password == generatedPassword)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Description = "Password does not meet the custom requirements." }));
            }
        }

        private int GenerateRandomNumber()
        {
         
            Random random = new Random();
            return random.Next();
        }

        private string GeneratePassword(int a, int x)
        {
           
            return (a / x).ToString();
        }
    }
}
