using Triangles.Shared.Enums;
using Triangles.Shared.Models;

namespace Triangles.Shared.Services
{
	public static class TriangleClassifier
	{
        /// <summary>
        /// Classifies a triangle as either Equilateral, Isosceles, Scalene, or Not a Triangle
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns><see cref="TriangleTypes"/></returns>
		public static TriangleTypes Classify(Triangle triangle)
		{
			//NOTE(greg): initializing to scalene
			//  if this is a triangle, is not an equilateral, and not isosceles,
			//  this triangle must be scalene
			TriangleTypes type = TriangleTypes.Scalene;

			if (IsNotTriangle(triangle))
			{
				type = TriangleTypes.NotTriangle;
			}
			else if (AllSidesAreEqual(triangle))
			{
				type = TriangleTypes.Equilateral;
			}
			else if (TwoSidesAreEqual(triangle))
			{
				type = TriangleTypes.Isosceles;
			}
			
			return type;
		}

		private static bool IsNotTriangle(Triangle triangle)
		{
			bool isNotTriangle = false;
			
			if (triangle.Side1 <= 0 || triangle.Side2 <= 0 || triangle.Side3 <= 0)
			{
				isNotTriangle = true;
			}

			//NOTE(greg): if any side of the triangle is greater than the
			//  sum of the other two sides, this is not a valid triangle
			if ((triangle.Side1 + triangle.Side2) < triangle.Side3)
			{
				isNotTriangle = true;
			}
			if ((triangle.Side1 + triangle.Side3) < triangle.Side2)
			{
				isNotTriangle = true;
			}
			if ((triangle.Side2 + triangle.Side3) < triangle.Side1)
			{
				isNotTriangle = true;
			}
			
			return isNotTriangle;
		}

		private static bool TwoSidesAreEqual(Triangle triangle)
		{
			return triangle.Side1 == triangle.Side2 || triangle.Side1 == triangle.Side3 || triangle.Side2 == triangle.Side3;
		}

		private static bool AllSidesAreEqual(Triangle triangle)
		{
			return triangle.Side1 == triangle.Side2 && triangle.Side1 == triangle.Side3 && triangle.Side2 == triangle.Side3;
		}
	}
}
