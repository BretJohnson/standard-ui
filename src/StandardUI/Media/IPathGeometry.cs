﻿using System.Collections.Generic;

namespace Microsoft.StandardUI.Media
{
    [UIModelObject]
    public interface IPathGeometry : IGeometry
    {
        IEnumerable<IPathFigure> Figures { get; set; }

        [DefaultValue(FillRule.EvenOdd)]
        FillRule FillRule { get; set; }
    }
}
