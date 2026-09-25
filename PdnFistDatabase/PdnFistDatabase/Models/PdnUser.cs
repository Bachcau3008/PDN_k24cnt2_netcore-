using System;
using System.Collections.Generic;

namespace PdnFirstDatabase.Models;

public partial class PdnUser
{
    public int PdnId { get; set; }

    public string PdnUsername { get; set; } = null!;

    public string PdnPassword { get; set; } = null!;

    public string? PdnFullName { get; set; }

    public string? PdnEmail { get; set; }

    public string? PdnPhone { get; set; }
}
