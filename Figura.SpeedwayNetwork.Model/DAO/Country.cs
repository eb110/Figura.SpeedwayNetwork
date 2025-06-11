using System;
using System.Collections.Generic;

namespace Figura.SpeedwayNetwork.Model.DAO;

public partial class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string FlagPictureUrl { get; set; } = null!;
}
