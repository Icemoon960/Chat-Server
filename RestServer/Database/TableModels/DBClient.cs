using ChatApi.Models.Server;
using RestServer.Database.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Database.TableModels
{
    [Table("Clients")]
    public class DBClient : IDBClient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClientId { get; set; }         
        [Required]
        [StringLength(UserConfiguration.UserNameMaxLength, MinimumLength = UserConfiguration.UserNameMinLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(UserConfiguration.PasswordMaxLength, MinimumLength = UserConfiguration.PasswordMinLength)]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        [ForeignKey("RoleId")]
        public int ClientRoleId { get; set; }
    }
}
