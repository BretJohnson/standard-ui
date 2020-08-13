// This file is generated from ITransformGroup.cs. Update the source file to change its contents.

using System.Collections.Generic;
using Microsoft.StandardUI.Media;
using System.Windows;

namespace Microsoft.StandardUI.Wpf.Media
{
    public class TransformGroup : Transform, ITransformGroup
    {
        public static readonly System.Windows.DependencyProperty ChildrenProperty = PropertyUtils.Create(nameof(Children), typeof(IEnumerable<ITransform>), typeof(IEnumerable<ITransform>), null);
        
        public IEnumerable<ITransform> Children
        {
            get => (IEnumerable<ITransform>) GetValue(ChildrenProperty);
        }
    }
}