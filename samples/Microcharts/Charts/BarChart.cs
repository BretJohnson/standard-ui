﻿// Copyright (c) Aloïs DENIEL. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Linq;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;
using static Microsoft.StandardUI.FactoryStatics;

namespace Microcharts
{
    /// <summary>
    /// ![chart](../images/Bar.png)
    ///
    /// A bar chart.
    /// </summary>
    public class BarChart : PointChart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microcharts.BarChart"/> class.
        /// </summary>
        public BarChart()
        {
            PointSize = 0;
        }

        /// <summary>
        /// Gets or sets the bar background area alpha.
        /// </summary>
        /// <value>The bar area alpha.</value>
        public byte BarAreaAlpha { get; set; } = 32;

        /// <summary>
        /// Draws the content of the chart onto the specified canvas.
        /// </summary>
        /// <param name="canvas">The output canvas.</param>
        /// <param name="width">The width of the chart.</param>
        /// <param name="height">The height of the chart.</param>
        public override void DrawContent(ICanvas canvas, int width, int height)
        {
            if (Entries != null)
            {
                var labels = Entries.Select(x => x.Label).ToArray();
                var labelSizes = MeasureLabels(labels);
                var footerHeight = CalculateFooterHeaderHeight(labelSizes, LabelOrientation);

                var valueLabels = Entries.Select(x => x.ValueLabel).ToArray();
                var valueLabelSizes = MeasureLabels(valueLabels);
                var headerHeight = CalculateFooterHeaderHeight(valueLabelSizes, ValueLabelOrientation);

                var itemSize = CalculateItemSize(width, height, footerHeight, headerHeight);
                var origin = CalculateYOrigin((float) itemSize.Height, headerHeight);
                var points = CalculatePoints(itemSize, origin, headerHeight);

                DrawBarAreas(canvas, points, itemSize, headerHeight);
                DrawBars(canvas, points, itemSize, origin, headerHeight);
                DrawPoints(canvas, points);
                DrawHeader(canvas, valueLabels, valueLabelSizes, points, itemSize, height, headerHeight);
                DrawFooter(canvas, labels, labelSizes, points, itemSize, height, footerHeight);
            }
        }

        /// <summary>
        /// Draws the value bars.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="points">The points.</param>
        /// <param name="itemSize">The item size.</param>
        /// <param name="origin">The origin.</param>
        /// <param name="headerHeight">The Header height.</param>
        protected void DrawBars(ICanvas canvas, Point[] points, Size itemSize, double origin, double headerHeight)
        {
            const float MinBarHeight = 4;
            if (points.Length > 0)
            {
                for (int i = 0; i < Entries.Count(); i++)
                {
                    var entry = Entries.ElementAt(i);
                    var point = points[i];

                    var x = point.X - (itemSize.Width / 2);
                    var y = Math.Min(origin, point.Y);
                    var height = Math.Max(MinBarHeight, Math.Abs(origin - point.Y));
                    if (height < MinBarHeight)
                    {
                        height = MinBarHeight;
                        if (y + height > Margin + itemSize.Height)
                        {
                            y = headerHeight + itemSize.Height - height;
                        }
                    }

                    var barRect = Rectangle() .Width(itemSize.Width) .Height(height) .Fill(SolidColorBrush() .Color(entry.Color));
                    canvas.Add(x, y, barRect);
                }
            }
        }

        /// <summary>
        /// Draws the bar background areas.
        /// </summary>
        /// <param name="canvas">The output canvas.</param>
        /// <param name="points">The entry points.</param>
        /// <param name="itemSize">The item size.</param>
        /// <param name="headerHeight">The header height.</param>
        protected void DrawBarAreas(ICanvas canvas, Point[] points, Size itemSize, double headerHeight)
        {
            if (points.Length > 0 && PointAreaAlpha > 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    var entry = Entries.ElementAt(i);
                    var point = points[i];

                    var color = entry.Color.WithA((byte)(this.BarAreaAlpha * this.AnimationProgress));
                    var brush = SolidColorBrush(). Color(color);

                    var max = entry.Value > 0 ? headerHeight : headerHeight + itemSize.Height;
                    var height = Math.Abs(max - point.Y);
                    var y = Math.Min(max, point.Y);

                    var barArea = Rectangle() .Width(itemSize.Width) .Height(height) .Fill(brush);
                    canvas.Add(point.X - (itemSize.Width / 2), y, barArea);
                }
            }
        }
    }
}
