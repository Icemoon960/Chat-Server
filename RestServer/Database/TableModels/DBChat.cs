using ChatApi.Models.Server;
using RestServer.Contracts;
using RestServer.Database.Config;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Database.TableModels
{
    [Table("Chats")]
    public class DBChat : IDBChat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ChatId { get; set; }
        [ForeignKey("ClientId")]
        public int CreatorId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; }
        [Required]
        [MaxLength(ChatConfiguration.NameLength)]
        public string ChatName { get; set; }
    }
}
