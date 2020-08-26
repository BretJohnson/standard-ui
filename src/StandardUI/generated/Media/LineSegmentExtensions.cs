// This file is generated from ILineSegment.cs. Update the source file to change its contents.

namespace System.StandardUI.Media
{
    public static class LineSegmentExtensions
    {
        public static T Point<T>(this T lineSegment, Point value) where T : ILineSegment
        {
            lineSegment.Point = value;
            return lineSegment;
        }
    }
}
