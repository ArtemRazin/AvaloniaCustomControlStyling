using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaCustomControlStyling.Controls
{
    internal class CustomControl : Control
    {
        public static readonly StyledProperty<Color> BackgroundColorProperty =
            AvaloniaProperty.Register<CustomControl, Color>(nameof(BackgroundColor), Colors.Transparent);

        public Color BackgroundColor
        {
            get => GetValue(BackgroundColorProperty);
            set
            {
                SetValue(BackgroundColorProperty, value);
                Debug.Assert(false);
            }
        }

        public CustomControl()
        {
            this.GetObservable(BackgroundColorProperty)
                .Subscribe(_ => InvalidateVisual());
        }

        public override void Render(DrawingContext context)
        {
            context.DrawRectangle(
                new SolidColorBrush(BackgroundColor),
                null,
                Bounds);
        }
    }
}
