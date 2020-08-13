// This file is generated from IPolyQuadraticBezierSegment.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using System.Windows;

namespace Microsoft.StandardUI.Wpf.Media
{
    public class PolyQuadraticBezierSegment : PathSegment, IPolyQuadraticBezierSegment
    {
        public static readonly System.Windows.DependencyProperty PointsProperty = PropertyUtils.Create(nameof(Points), typeof(PointsWpf), typeof(PointsWpf), PointsWpf.Default);
        
        public PointsWpf Points
        {
            get => (PointsWpf) GetValue(PointsProperty);
            set => SetValue(PointsProperty, value);
        }
        Points IPolyQuadraticBezierSegment.Points
        {
            get => Points.Points;
            set => Points = new PointsWpf(value);
        }
    }
}