using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Database.TableModels
{
    [Table("ChatMessageStates")]
    public class DBChatMessageState
    {
        [ForeignKey("MessageId")]
        public int MessageId { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ReadTime { get; set; }
    }
}
