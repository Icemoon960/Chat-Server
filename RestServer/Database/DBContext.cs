using Microsoft.EntityFrameworkCore;
using RestServer.AuthenticateModels;
using RestServer.Database.TableModels;
using System;

namespace RestServer.Database
{
    public class DBContext : DbContext
    {
        private DBContext() { }
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions) 
        {
            SeedDB();
        }
        public DbSet<DBChat> Chats { get; set; }
        public DbSet<DBClient> Clients { get; set; }
        public DbSet<DBChatConnection> ChatConnections { get; set; }
        public DbSet<DBChatMessage> ChatMessages { get; set; }
        //public DbSet<DBChatMessageState> ChatMessageStates { get; set; }         
        public DbSet<DBRole> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DBChatMessageState>().HasNoKey();
            modelBuilder.Entity<DBChatConnection>().HasNoKey();
        }
        private void SeedDB()
        {
            foreach (AuthRole.Ids roleId in Enum.GetValues(typeof(AuthRole.Ids)))
            {
                Roles.Add(new DBRole() { RoleId = (int)roleId, RoleName = roleId.ToString() });
            }
        }

    }
}
