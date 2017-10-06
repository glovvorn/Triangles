using Triangles.Shared.Constants;

namespace Triangles.Shared.Enums
{
    /// <summary>
    /// Enum to determine what type of triangle we're talking about
    /// </summary>
	public enum TriangleTypes
	{
		Equilateral,
		Isosceles,
		Scalene,
		NotTriangle
	}
    
	public static class TriangleTypesExtensions
	{
        /// <summary>
        /// Method to get a display-friendly name for <see cref="TriangleTypes"/>
        /// </summary>
        public static string ToFriendlyString(this TriangleTypes type)
		{
			switch (type)
			{
				case TriangleTypes.NotTriangle:
					return TriangleNames.NotTriangle;
				default:
					return type.ToString();
			}
		}
	}
}
