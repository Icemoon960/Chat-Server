using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Database.TableModels
{
    [Table("ChatConnections")]
    public class DBChatConnection
    {
        [ForeignKey("ClientId")]
        public int ConnectedClientId;

        [ForeignKey("ChatId")]
        public int ConnectedChatId;
    }
}
