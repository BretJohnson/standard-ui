// This file is generated from IPolyBezierSegment.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Wpf.Media
{
    public class PolyBezierSegment : PathSegment, IPolyBezierSegment
    {
        public static readonly System.Windows.DependencyProperty PointsProperty = PropertyUtils.Register(nameof(Points), typeof(PointsWpf), typeof(PolyBezierSegment), PointsWpf.Default);
        
        public PointsWpf Points
        {
            get => (PointsWpf) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyBezierSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsWpf(value);
        }
    }
}
