using System;
using System.Collections.Generic;

namespace prjTest.Models;

public partial class NewsFiles
{
    public Guid newsFilesId { get; set; }

    public Guid newsId { get; set; }

    public string name { get; set; } = null!;

    public string path { get; set; } = null!;

    public string extension { get; set; } = null!;
}
