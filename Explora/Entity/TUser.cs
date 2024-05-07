using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TUser
{
    public int UserId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string UrlAvatar { get; set; } = null!;

    public byte? EmailConfirm { get; set; }

    public string? EmailConfirmToken { get; set; }

    public string? ResetPasswordToken { get; set; }

    public virtual ICollection<TBillRoom> TBillRooms { get; set; } = new List<TBillRoom>();

    public virtual ICollection<THotel> THotels { get; set; } = new List<THotel>();

    public virtual ICollection<TOrderBu> TOrderBus { get; set; } = new List<TOrderBu>();

    public virtual ICollection<TOrderPlane> TOrderPlanes { get; set; } = new List<TOrderPlane>();

    public virtual ICollection<TRoleUser> TRoleUsers { get; set; } = new List<TRoleUser>();
}
