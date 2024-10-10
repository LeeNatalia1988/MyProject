using Castle.Components.DictionaryAdapter.Xml;
using GrpcGreeter.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace GrpcGreeter.Db
{
    public class MessageContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }
        private string _connectionString;

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var cfg = config.Build();
            _connectionString = cfg.GetConnectionString("db");
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString, builder =>
                builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null));
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.PRSeqNum).HasName("pkey");
                entity.ToTable("grpc_data");
                
                entity.Property(e => e.PRSeqNum)
                    .HasColumnName("ud_num");
                entity.Property(e => e.PacketSeqNum)
                    .HasMaxLength(128)
                    .HasColumnName("packet_seq_num");
                entity.Property(e => e.RecordSeqNum)
                    .HasMaxLength(128)
                    .HasColumnName("record_seq_num");
                entity.Property(e => e.PacketTimestamp)
                    .HasColumnName("packet_timestamp");
                entity.Property(e => e.Decimal1)
                    .HasColumnName("dec_1");
                entity.Property(e => e.Decimal2)
                    .HasColumnName("dec_2");
                entity.Property(e => e.Decimal3)
                    .HasColumnName("dec_3");
                entity.Property(e => e.Decimal4)
                    .HasColumnName("dec_4");
                entity.Property(e => e.RecordTimestamp)
                    .HasColumnName("record_timestap");
            });

            
            
        }
       
    }
}
