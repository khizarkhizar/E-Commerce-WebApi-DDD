using Domain.Base;
using Domain.Items;
using System;
using System.Collections.Generic;

namespace Domain.Categories;

public partial class CtgrNme : BaseEntity<int>
{

    public string CtgrName { get; private set; } = null!;

    public string? SubCtgr { get; private set; }

    public virtual ICollection<Item> Items { get; private set; } = new List<Item>();
}
