using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangles.Shared.Constants;
using Triangles.Shared.Enums;
using Triangles.Shared.Models;

namespace UnitTestProject1
{
	[TestClass]
	public class TriangleTest
	{
		private Triangle triangle1;
		private Triangle triangle2;
		private Triangle triangle3;
		private Triangle triangle4;
		private Triangle triangle5;
		private Triangle triangle6;
		private Triangle triangle7;
		private Triangle triangle8;

		[TestInitialize]
		public void TestInitialize()
		{
			//Equilateral
			triangle1 = new Triangle(3, 3.0f, 3.00f);

			//Isosceles
			triangle2 = new Triangle(3.0f, 3.0f, 3.0f);
			//NOTE(greg): this should update the triangle type
			triangle2.Side1 = 4.0f;

			//Isosceles
			triangle3 = new Triangle(2.5f, 2.5f, 3.0f);

			//Scalene
			triangle4 = new Triangle(2.5f, 4.5f, 3.0f);

			//Equilateral
			triangle5 = new Triangle(2.5f, 4.5f, 3.0f);
			//NOTE(greg): this should update the triangle type
			triangle5.Side1 = 4.5f;
			triangle5.Side3 = 4.5f;

			//Not a triangle
			triangle6 = new Triangle();

			//Not a triangle
			triangle7 = new Triangle(0, 3, 4);

			//Not a triangle
			triangle8 = new Triangle(4, 6, 11);
		}

        [TestMethod]
        public void TestTrianglesNotAllowingNegativeSides()
        {
            triangle1.Side1 = -1;
            triangle1.Side2 = -5.3f;
            triangle1.Side3 = -.1f;

            Assert.AreNotEqual(-1, triangle1.Side1);
            Assert.AreNotEqual(-5.3f, triangle1.Side2);
            Assert.AreNotEqual(-.1f, triangle1.Side3);
        }

		[TestMethod]
		public void TestEquilateral()
		{
			Assert.AreEqual(TriangleTypes.Equilateral, triangle1.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle2.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle3.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle4.Type);
			Assert.AreEqual(TriangleTypes.Equilateral, triangle5.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle6.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle7.Type);
			Assert.AreNotEqual(TriangleTypes.Equilateral, triangle8.Type);

			Assert.AreEqual(TriangleNames.Equilateral, TriangleTypes.Equilateral.ToFriendlyString());
		}

		[TestMethod]
		public void TestIsosceles()
		{
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle1.Type);
			Assert.AreEqual(TriangleTypes.Isosceles, triangle2.Type);
			Assert.AreEqual(TriangleTypes.Isosceles, triangle3.Type);
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle4.Type);
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle5.Type);
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle6.Type);
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle7.Type);
			Assert.AreNotEqual(TriangleTypes.Isosceles, triangle8.Type);

			Assert.AreEqual(TriangleNames.Isosceles, TriangleTypes.Isosceles.ToFriendlyString());
		}

		[TestMethod]
		public void TestScalene()
		{
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle1.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle2.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle3.Type);
			Assert.AreEqual(TriangleTypes.Scalene, triangle4.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle5.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle6.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle7.Type);
			Assert.AreNotEqual(TriangleTypes.Scalene, triangle8.Type);

			Assert.AreEqual(TriangleNames.Scalene, TriangleTypes.Scalene.ToFriendlyString());
		}

		[TestMethod]
		public void TestNotATriangle()
		{
			Assert.AreNotEqual(TriangleTypes.NotTriangle, triangle1.Type);
			Assert.AreNotEqual(TriangleTypes.NotTriangle, triangle2.Type);
			Assert.AreNotEqual(TriangleTypes.NotTriangle, triangle3.Type);
			Assert.AreNotEqual(TriangleTypes.NotTriangle, triangle4.Type);
			Assert.AreNotEqual(TriangleTypes.NotTriangle, triangle5.Type);
			Assert.AreEqual(TriangleTypes.NotTriangle, triangle6.Type);
			Assert.AreEqual(TriangleTypes.NotTriangle, triangle7.Type);
			Assert.AreEqual(TriangleTypes.NotTriangle, triangle8.Type);

			Assert.AreEqual(TriangleNames.NotTriangle, TriangleTypes.NotTriangle.ToFriendlyString());
		}
	}
}
