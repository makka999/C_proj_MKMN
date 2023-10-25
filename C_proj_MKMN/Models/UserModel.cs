
using Microsoft.AspNetCore.Identity;


namespace C_proj_MKMN.Models
{
    public class UserModel : IdentityUser
    {
        public int PasswordIndividualLength { get; set; } = 10;

    }
}
