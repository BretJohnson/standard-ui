// This file is generated from ITargetPropertyPath.cs. Update the source file to change its contents.

using Microsoft.StandardUI;

namespace Microsoft.StandardUI.Wpf
{
    public class TargetPropertyPath : StandardUIDependencyObject, ITargetPropertyPath
    {
        public static readonly System.Windows.DependencyProperty PropertyProperty = PropertyUtils.Register(nameof(Property), typeof(PropertyPath), typeof(TargetPropertyPath), null);
        public static readonly System.Windows.DependencyProperty TargetProperty = PropertyUtils.Register(nameof(Target), typeof(object), typeof(TargetPropertyPath), null);
        
        public PropertyPath Property
        {
            get => (PropertyPath) GetValue(PropertyProperty);
            set => SetValue(PropertyProperty, value);
        }
        IPropertyPath ITargetPropertyPath.Property
        {
            get => Property;
            set => Property = (PropertyPath) value;
        }
        
        public object Target
        {
            get => (object) GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }
    }
}
