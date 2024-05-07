using System;
using System.Collections.Generic;
using Explora.Entity;
using Microsoft.EntityFrameworkCore;

namespace Explora.data;

public partial class ExploraContext : DbContext
{
    public ExploraContext()
    {
    }

    public ExploraContext(DbContextOptions<ExploraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAirline> TAirlines { get; set; }

    public virtual DbSet<TBillRoom> TBillRooms { get; set; }

    public virtual DbSet<TBu> TBus { get; set; }

    public virtual DbSet<TBusTicket> TBusTickets { get; set; }

    public virtual DbSet<THotel> THotels { get; set; }

    public virtual DbSet<TNhaXe> TNhaXes { get; set; }

    public virtual DbSet<TOrderBu> TOrderBus { get; set; }

    public virtual DbSet<TOrderPlane> TOrderPlanes { get; set; }

    public virtual DbSet<TPlane> TPlanes { get; set; }

    public virtual DbSet<TPlaneTicket> TPlaneTickets { get; set; }

    public virtual DbSet<TRole> TRoles { get; set; }

    public virtual DbSet<TRoleUser> TRoleUsers { get; set; }

    public virtual DbSet<TRoom> TRooms { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=Explora;User ID=sa;Password=123456aA@$;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAirline>(entity =>
        {
            entity.HasKey(e => e.IdAirline).HasName("PK__t_AIRLIN__1A34E835EF4A24B5");

            entity.ToTable("t_AIRLINE");

            entity.Property(e => e.IdAirline).HasColumnName("Id_Airline");
            entity.Property(e => e.AddressAirline)
                .HasMaxLength(50)
                .HasColumnName("Address_Airline");
            entity.Property(e => e.AirlineName)
                .HasMaxLength(50)
                .HasColumnName("Airline_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
        });

        modelBuilder.Entity<TBillRoom>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__t_BILL_R__CF6E7DA3B2C4FD7C");

            entity.ToTable("t_BILL_ROOM");

            entity.Property(e => e.BillId).HasColumnName("Bill_Id");
            entity.Property(e => e.BuyTime)
                .HasColumnType("date")
                .HasColumnName("Buy_Time");
            entity.Property(e => e.EndTime)
                .HasColumnType("date")
                .HasColumnName("End_Time");
            entity.Property(e => e.GuessEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Guess_Email");
            entity.Property(e => e.GuessName)
                .HasMaxLength(50)
                .HasColumnName("Guess_Name");
            entity.Property(e => e.IdRoom).HasColumnName("Id_Room");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.StartTime)
                .HasColumnType("date")
                .HasColumnName("Start_Time");
            entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.TBillRooms)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HD_DAT_PHONG_1");

            entity.HasOne(d => d.User).WithMany(p => p.TBillRooms)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HD_DAT_PHONG_2");
        });

        modelBuilder.Entity<TBu>(entity =>
        {
            entity.HasKey(e => e.IdBus).HasName("PK__t_BUS__5153DBEA80EDF0AB");

            entity.ToTable("t_BUS");

            entity.Property(e => e.IdBus).HasColumnName("Id_Bus");
            entity.Property(e => e.BusName)
                .HasMaxLength(50)
                .HasColumnName("Bus_Name");
            entity.Property(e => e.EmptySlot).HasColumnName("Empty_Slot");
            entity.Property(e => e.EndPoint)
                .HasMaxLength(15)
                .HasColumnName("End_Point");
            entity.Property(e => e.IdNhaXe).HasColumnName("Id_Nha_Xe");
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.StartPoint)
                .HasMaxLength(15)
                .HasColumnName("Start_Point");
            entity.Property(e => e.StartTime)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Time");

            entity.HasOne(d => d.IdNhaXeNavigation).WithMany(p => p.TBus)
                .HasForeignKey(d => d.IdNhaXe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHUYEN_XE_1");
        });

        modelBuilder.Entity<TBusTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__t_BUS_TI__ED7260B9D8FC8ECF");

            entity.ToTable("t_BUS_TICKET");

            entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");
            entity.Property(e => e.GuessEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Guess_Email");
            entity.Property(e => e.GuessName)
                .HasMaxLength(50)
                .HasColumnName("Guess_Name");
            entity.Property(e => e.IdBus).HasColumnName("Id_Bus");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.TBusTickets)
                .HasForeignKey(d => d.IdBus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VE_XE_1");

            entity.HasOne(d => d.Order).WithMany(p => p.TBusTickets)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VE_XE_2");
        });

        modelBuilder.Entity<THotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK__t_HOTEL__40D3513541647B00");

            entity.ToTable("t_HOTEL");

            entity.Property(e => e.IdHotel).HasColumnName("Id_Hotel");
            entity.Property(e => e.AddressHotel)
                .HasMaxLength(50)
                .HasColumnName("Address_Hotel");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(50)
                .HasColumnName("Hotel_Name");
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.THotels)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HOTEL1");
        });

        modelBuilder.Entity<TNhaXe>(entity =>
        {
            entity.HasKey(e => e.IdNhaXe).HasName("PK__t_NHA_XE__134CAC8BF689C283");

            entity.ToTable("t_NHA_XE");

            entity.Property(e => e.IdNhaXe).HasColumnName("Id_Nha_Xe");
            entity.Property(e => e.AddressNhaXe)
                .HasMaxLength(50)
                .HasColumnName("Address_Nha_Xe");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.NhaXeName)
                .HasMaxLength(50)
                .HasColumnName("Nha_xe_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
        });

        modelBuilder.Entity<TOrderBu>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__t_ORDER___F1E4607BDF472D37");

            entity.ToTable("t_ORDER_BUS");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.BuyTime)
                .HasColumnType("date")
                .HasColumnName("Buy_Time");
            entity.Property(e => e.IdBus).HasColumnName("Id_Bus");
            entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.TOrderBus)
                .HasForeignKey(d => d.IdBus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_VE_XE_2");

            entity.HasOne(d => d.User).WithMany(p => p.TOrderBus)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_VE_XE_1");
        });

        modelBuilder.Entity<TOrderPlane>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__t_ORDER___F1E4607B24E41548");

            entity.ToTable("t_ORDER_PLANE");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.BuyTime)
                .HasColumnType("date")
                .HasColumnName("Buy_Time");
            entity.Property(e => e.IdPlane).HasColumnName("Id_Plane");
            entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdPlaneNavigation).WithMany(p => p.TOrderPlanes)
                .HasForeignKey(d => d.IdPlane)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_VE_MAY_BAY_2");

            entity.HasOne(d => d.User).WithMany(p => p.TOrderPlanes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_VE_MAY_BAY_1");
        });

        modelBuilder.Entity<TPlane>(entity =>
        {
            entity.HasKey(e => e.IdPlane).HasName("PK__t_PLANE__7507AF44DDC90AC3");

            entity.ToTable("t_PLANE");

            entity.Property(e => e.IdPlane).HasColumnName("Id_Plane");
            entity.Property(e => e.EmptySlot).HasColumnName("Empty_Slot");
            entity.Property(e => e.EndPoint)
                .HasMaxLength(15)
                .HasColumnName("End_Point");
            entity.Property(e => e.IdAirline).HasColumnName("Id_Airline");
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.PlaneName)
                .HasMaxLength(50)
                .HasColumnName("Plane_Name");
            entity.Property(e => e.StartPoint)
                .HasMaxLength(15)
                .HasColumnName("Start_Point");
            entity.Property(e => e.StartTime)
                .HasColumnType("smalldatetime")
                .HasColumnName("Start_Time");

            entity.HasOne(d => d.IdAirlineNavigation).WithMany(p => p.TPlanes)
                .HasForeignKey(d => d.IdAirline)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHUYEN_BAY_1");
        });

        modelBuilder.Entity<TPlaneTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__t_PLANE___ED7260B913D230EA");

            entity.ToTable("t_PLANE_TICKET");

            entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.ExpiredTime)
                .HasColumnType("date")
                .HasColumnName("Expired_Time");
            entity.Property(e => e.GuessEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Guess_Email");
            entity.Property(e => e.GuessName)
                .HasMaxLength(50)
                .HasColumnName("Guess_Name");
            entity.Property(e => e.IdPlane).HasColumnName("Id_Plane");
            entity.Property(e => e.Nationality).HasMaxLength(20);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PasspostNumber)
                .HasMaxLength(8)
                .HasColumnName("Passpost_Number");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");

            entity.HasOne(d => d.IdPlaneNavigation).WithMany(p => p.TPlaneTickets)
                .HasForeignKey(d => d.IdPlane)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VE_MAY_BAY_1");

            entity.HasOne(d => d.Order).WithMany(p => p.TPlaneTickets)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VE_MAY_BAY_2");
        });

        modelBuilder.Entity<TRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__t_ROLE__D80AB4BBB9095A9F");

            entity.ToTable("t_ROLE");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("Role_Name");
            entity.Property(e => e.StatusRole)
                .HasMaxLength(5)
                .HasColumnName("Status_Role");
        });

        modelBuilder.Entity<TRoleUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_ROLE_U__3214EC07C069346D");

            entity.ToTable("t_ROLE_USER");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Role).WithMany(p => p.TRoleUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_USER_1");

            entity.HasOne(d => d.User).WithMany(p => p.TRoleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_USER_2");
        });

        modelBuilder.Entity<TRoom>(entity =>
        {
            entity.HasKey(e => e.IdRoom).HasName("PK__t_ROOM__34AD920B654455D7");

            entity.ToTable("t_ROOM");

            entity.Property(e => e.IdRoom).HasColumnName("Id_Room");
            entity.Property(e => e.EmptySlot).HasColumnName("Empty_Slot");
            entity.Property(e => e.IdHotel).HasColumnName("Id_Hotel");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .HasColumnName("Image_Url");
            entity.Property(e => e.IsDelete).HasColumnName("Is_Delete");
            entity.Property(e => e.TypeRoom)
                .HasMaxLength(10)
                .HasColumnName("Type_Room");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.TRooms)
                .HasForeignKey(d => d.IdHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHONG_1");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__t_USER__206D9170F8ABE9EF");

            entity.ToTable("t_USER");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailConfirm)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Email_Confirm");
            entity.Property(e => e.EmailConfirmToken)
                .HasMaxLength(100)
                .HasColumnName("Email_Confirm_Token");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Password_User");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ResetPasswordToken)
                .HasMaxLength(100)
                .HasColumnName("Reset_Password_Token");
            entity.Property(e => e.UrlAvatar)
                .HasMaxLength(300)
                .HasColumnName("Url_Avatar");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
