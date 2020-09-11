# .NET Standard UI

.NET Standard UI enables building UI, especially controls, that runs across multiple UI frameworks - WPF, UWP, WinUI, Xamarin.Forms, .NET MAUI, Uno, Avalonia, and more. A .NET Standard UI control is a single .NET Standard assembly, that works on all supported UI frameworks.

.NET Standard UI is similar in some ways to [XAML Standard](https://github.com/microsoft/xaml-standard), but this is a binary standard, not just aligned naming conventions. A binary standard is much more useful, at it allows writing shared code. The standard objects can be used
from XAML or from code.

The standard includes APIs needed to create controls that use drawn UI - shapes APIs (for the drawing), visual states, layout (e.g. Grid and StackPanel), core input event handling, and core accessibility support. It may grow in the future, but that's the initial scope.

API names most closely match UWP/WinUI, but should be familiar to WPF and Xamarin.Forms develepers as they are pretty similar.

# Architecture and APIs

The API is interface based. For instance, an ellipse is `Microsoft.StandardUI.Shapes.IEllipse`. Users of the API always use the interface.

In terms of implementation, UI platforms can implement the interface directly OR it can be implemented by a wrapper object (which typically lives in this repo). Having both options available provides maximum flexibility.

For new UI platforms, like WinUI3 and .NET MAUI, ideally they have their native
`Ellipse` object implement `IEllipse` directly. That helps enforce API naming consistency and is slightly more efficient.

Or the interface can be implemented via a wrapper, which requires no changes to the underlying UI platform at all. That's a good choice for platforms like WPF.

The API interfaces are all defined [here](src/StandardUI). Implementations for the different UI frameworks are created through a mix of [code generation](src/StandardUI.CodeGenerator) from those interfaces and hand coding.

This project is an evolution of my [XGraphics](https://github.com/BretJohnson/XGraphics) project, taking it beyond just shapes.

# Current APIs

### Shapes and Drawing

_Shapes:_
[IShape](src/StandardUI/Shapes/IShape.cs),
[IEllipse](src/StandardUI/Shapes/IEllipse.cs),
[ILine](src/StandardUI/Shapes/ILine.cs),
[IPath](src/StandardUI/Shapes/IPath.cs),
[IPolygon](src/StandardUI/Shapes/IPolygon.cs),
[IPolyline](src/StandardUI/Shapes/IPolyline.cs),
[IRectangle](src/StandardUI/Shapes/IRectangle.cs)

_Geometries:_
[IGeometry](src/StandardUI/Media/IGeometry.cs),
[IArcSegement](src/StandardUI/Media/IArcSegement.cs),
[IBezierSegment](src/StandardUI/Media/IBezierSegment.cs),
[ILineSegment](src/StandardUI/Media/ILineSegment.cs),
[IPathFigure](src/StandardUI/Media/IPathFigure.cs),
[IPathGeometry](src/StandardUI/Media/IPathGeometry.cs),
[IPathSegment](src/StandardUI/Media/IPathSegment.cs),
[IPolyBezierSegment](src/StandardUI/Media/IPolyBezierSegment.cs)
[IPolyQuadraticBezierSegment](src/StandardUI/Media/IPolyQuadraticBezierSegment.cs)
[IQuadraticBezierSegment](src/StandardUI/Media/IQuadraticBezierSegment.cs)

_Transforms:_
[ITransform](src/StandardUI/Media/ITransform.cs),
[IRotateTransform](src/StandardUI/Media/IRotateTransform.cs),
[IScaleTransform](src/StandardUI/Media/IScaleTransform.cs),
[ITransformGroup](src/StandardUI/Media/ITransformGroup.cs),
[ITranslateTransform](src/StandardUI/Media/ITranslateTransform.cs)

_Brushes and Strokes:_
[BrushMappingMode](src/StandardUI/Media/BrushMappingMode.cs),
[FillMode](src/StandardUI/Media/FillMode.cs),
[GradientStreamMethod](src/StandardUI/Media/GradientStreamMethod.cs),
[IGradientBrush](src/StandardUI/Media/IGradientBrush.cs),
[ILinearGradientBrush](src/StandardUI/Media/ILinearGradientBrush.cs),
[IRadialGradientBrush](src/StandardUI/Media/IRadialGradientBrush.cs),
[ISolidColorBrush](src/StandardUI/Media/ISolidColorBrush.cs),
[PenLineCap](src/StandardUI/Media/PenLineCap.cs),
[PenLineJoin](src/StandardUI/Media/PenLineJoin.cs),
[SweepDirection](src/StandardUI/Media/SweepDirection.cs)

All of these APIs are nearly identical to UWP, WPF, and Xamarin.Forms 4.8 (which added shape and brush support).

Shapes are [IUIElements](src/StandardUI/IUIElement.cs) that can be used as children to build the visual representation of a control, often as part of a control template. That's the same model used by UWP/WPF/Forms.

Geometries, transforms, and brushes all help support the drawing.

### Layout

[IPanel](src/StandardUI/Controls/IPanel.cs),
[IStackPanel](src/StandardUI/Controls/IStackPanel.cs),
[IGrid](src/StandardUI/Controls/IGrid.cs),
[ICanvas](src/StandardUI/Controls/ICanvas.cs)

### Text

[ITextBlock](src/StandardUI/Controls/ITextBlock.cs),
[FontStyle](src/StandardUI/Text/FontStyle.cs),
[FontWeight](src/StandardUI/Text/FontWeight.cs),
[FontWeights](src/StandardUI/Text/FontWeights.cs)

### Control hierarchy

[IUIElement](src/StandardUI/IUIElement.cs),
[IUIElementCollection](src/StandardUI/Controls/IUIElementCollection.cs),
[IControl](src/StandardUI/Controls/IControl.cs),
[IUserControl](src/StandardUI/Controls/IUserControl.cs)


