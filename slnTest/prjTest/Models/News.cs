using System;
using System.Collections.Generic;

namespace prjTest.Models;

public partial class News
{
    public Guid newsId { get; set; }

    public string title { get; set; } = null!;

    public string content { get; set; } = null!;

    public DateTime startDateTime { get; set; }

    public DateTime endDateTime { get; set; }

    public DateTime updateDateTime { get; set; }

    public int updateEmployeeId { get; set; }

    public int click { get; set; }

    public int insertEmployeeId { get; set; }

    public DateTime insertDateTime { get; set; }

    public bool enable { get; set; }
}
