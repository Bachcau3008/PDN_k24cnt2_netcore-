using System;
using System.Collections.Generic;

namespace PhamDinhNguye_exam.Models;

public partial class PdnEmployee
{
    public int Id { get; set; }

    public string PdnName { get; set; } = null!;

    public string PdnGender { get; set; }

    public DateOnly PdnBirthDay { get; set; }

    public string PdnEmail { get; set; }

    public string PdnPhone { get; set; }

    public bool PdnActive { get; set; }
}
