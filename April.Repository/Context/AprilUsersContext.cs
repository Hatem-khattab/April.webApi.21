using System;
using System.Collections.Generic;
using April.DomainEntites.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace April.DomainEntites;

public partial class AprilUsersContext : DbContext
{
    public AprilUsersContext()
    {
    }

    public AprilUsersContext(DbContextOptions<AprilUsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GWTC71427;Database=April.users;Trusted_Connection=True;TrustServerCertificate=True; User Id=sa;password=12345;Integrated Security=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(50);
            entity.Property(e => e.ItemUserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("itemUserID");

            entity.HasOne(d => d.ItemUser).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_UserInfo");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPhoneNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
