using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatAppProject.Models
{
    public partial class ChatAppContext : DbContext
    {
        public ChatAppContext()
        {
        }

        public ChatAppContext(DbContextOptions<ChatAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channeltable> ChannelList { get; set; }
        public virtual DbSet<Messegetable> MessegeList { get; set; }
        public virtual DbSet<Userchanneltable> UserchannelList { get; set; }
        public virtual DbSet<Usertable> UserList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=ChatApp;Username=postgres;Password=Rusheepakur17#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channeltable>(entity =>
            {
                entity.HasKey(e => e.Channelid)
                    .HasName("channeltable_pkey");

                entity.ToTable("channeltable");

                entity.Property(e => e.Channelid)
                    .HasColumnName("channelid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Channelname)
                    .IsRequired()
                    .HasColumnName("channelname")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Messegetable>(entity =>
            {
                entity.ToTable("messegetable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Messege)
                    .IsRequired()
                    .HasColumnName("messege")
                    .HasMaxLength(500);

                entity.Property(e => e.Senderid).HasColumnName("senderid");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Messegetable)
                    .HasForeignKey(d => d.Channelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_03");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Messegetable)
                    .HasForeignKey(d => d.Senderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_04");
            });

            modelBuilder.Entity<Userchanneltable>(entity =>
            {
                entity.ToTable("userchanneltable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Channelid).HasColumnName("channelid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Userchanneltable)
                    .HasForeignKey(d => d.Channelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_02");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userchanneltable)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_01");
            });

            modelBuilder.Entity<Usertable>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("usertable_pkey");

                entity.ToTable("usertable");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Passwords)
                    .IsRequired()
                    .HasColumnName("passwords")
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
