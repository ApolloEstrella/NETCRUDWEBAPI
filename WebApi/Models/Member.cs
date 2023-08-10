using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }
}
