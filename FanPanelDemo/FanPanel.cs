using System;
using System.Windows;
using System.Windows.Controls;

namespace FanPanelDemo
{
    public class FanPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement element in Children)
            {
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var angle = 270D;
            var averageAngle = 90 / Children.Count;

            foreach (UIElement element in Children)
            {
                var radiusX = finalSize.Width - element.DesiredSize.Width;
                var radiusY = finalSize.Height;
                var x = radiusX + (radiusX) * Math.Cos(angle * Math.PI / 180);
                var y = radiusY + (radiusY) * Math.Sin(angle * Math.PI / 180);
                element.Arrange(new Rect(new Point(x, y), element.DesiredSize));

                angle -= averageAngle;
            }

            return finalSize;
        }
    }
}
