using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Database.TableModels.PushNotifications
{
    [Table("ChatRequestNotifications")]
    public class ChatRequestNotification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

    }
}
