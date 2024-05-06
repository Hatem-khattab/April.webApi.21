using System;
using System.Collections.Generic;

namespace April.DomainEntites.DbEntity;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPhoneNumber { get; set; } = null!;

    public int UserAge { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
