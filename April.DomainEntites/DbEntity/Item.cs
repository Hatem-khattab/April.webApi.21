using System;
using System.Collections.Generic;

namespace April.DomainEntites.DbEntity;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int ItemQuantity { get; set; }

    public int ItemUserId { get; set; }

    public virtual UserInfo ItemUser { get; set; } = null!;
}
