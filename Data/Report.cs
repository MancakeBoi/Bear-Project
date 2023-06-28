using System;
using System.Collections.Generic;

namespace bear_project_server.Data;

public partial class Report
{
    public string? Type { get; set; }

    public int Id { get; }

    public DateTime TimeStamp { get; }

    public string? Encounter { get; set; }

    public string? Location { get; set; }

    public int? Cubs { get; set; } = 0;

    public int? Adults { get; set; } = 0 ;

    public decimal? lat {get; set;}
    public decimal? lng {get; set;}
}
