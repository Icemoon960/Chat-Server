using ChatApi.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace RestServer.AuthenticateModels
{
    public class AuthUser : IAuthUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
