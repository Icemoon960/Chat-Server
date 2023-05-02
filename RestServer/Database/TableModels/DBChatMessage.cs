using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApi.Models.Server;
using RestServer.Database.Config;

namespace RestServer.Database.TableModels
{
    [Table("ChatMessages")]
    public class DBChatMessage : IDBChatMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MessageId { get; set; }
        [ForeignKey("ClientId")]
        public int SenderId { get; set; }
        [ForeignKey("ChatId")]
        public int DestChatId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LastEdited { get; set; } = DateTime.UtcNow;
        [Required]
        [Column("MessageText")]
        [MaxLength(ChatMessageConfiguration.MaxLength)]
        public string MessageText { get; set; }
    }
}
