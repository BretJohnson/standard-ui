// This file is generated from IShape.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Wpf.Media;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI.Wpf.Shapes
{
    public class Shape : StandardUIFrameworkElement, IShape
    {
        public static readonly System.Windows.DependencyProperty FillProperty = PropertyUtils.Register(nameof(Fill), typeof(Brush), typeof(Shape), null);
        public static readonly System.Windows.DependencyProperty StrokeProperty = PropertyUtils.Register(nameof(Stroke), typeof(Brush), typeof(Shape), null);
        public static readonly System.Windows.DependencyProperty StrokeThicknessProperty = PropertyUtils.Register(nameof(StrokeThickness), typeof(double), typeof(Shape), 1.0);
        public static readonly System.Windows.DependencyProperty StrokeMiterLimitProperty = PropertyUtils.Register(nameof(StrokeMiterLimit), typeof(double), typeof(Shape), 10.0);
        public static readonly System.Windows.DependencyProperty StrokeLineCapProperty = PropertyUtils.Register(nameof(StrokeLineCap), typeof(PenLineCap), typeof(Shape), PenLineCap.Flat);
        public static readonly System.Windows.DependencyProperty StrokeLineJoinProperty = PropertyUtils.Register(nameof(StrokeLineJoin), typeof(PenLineJoin), typeof(Shape), PenLineJoin.Miter);
        
        public Brush? Fill
        {
            get => (Brush?) GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
        IBrush? IShape.Fill
        {
            get => Fill;
            set => Fill = (Brush?) value;
        }
        
        public Brush? Stroke
        {
            get => (Brush?) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        IBrush? IShape.Stroke
        {
            get => Stroke;
            set => Stroke = (Brush?) value;
        }
        
        public double StrokeThickness
        {
            get => (double) GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }
        
        public double StrokeMiterLimit
        {
            get => (double) GetValue(StrokeMiterLimitProperty);
            set => SetValue(StrokeMiterLimitProperty, value);
        }
        
        public PenLineCap StrokeLineCap
        {
            get => (PenLineCap) GetValue(StrokeLineCapProperty);
            set => SetValue(StrokeLineCapProperty, value);
        }
        
        public PenLineJoin StrokeLineJoin
        {
            get => (PenLineJoin) GetValue(StrokeLineJoinProperty);
            set => SetValue(StrokeLineJoinProperty, value);
        }
    }
}
