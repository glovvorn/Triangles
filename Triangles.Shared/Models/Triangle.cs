using Triangles.Shared.Enums;
using Triangles.Shared.Services;

namespace Triangles.Shared.Models
{
	public class Triangle
	{
		#region Constructors
		public Triangle() { }

		public Triangle(float side1, float side2, float side3)
		{
			_side1 = side1;
			_side2 = side2;
			_side3 = side3;

			calculateClassification();
		}
		#endregion

		#region Properties
		public float Side1
		{
			get
			{
				return _side1;
			}
			set
			{
				if (value == _side1 || value < 0)
				{
					return;
				}
				_side1 = value;
				calculateClassification();
			}
		}
		public float Side2
		{
			get
			{
				return _side2;
			}
			set
			{
				if (value == _side2 || value < 0)
				{
					return;
				}
				_side2 = value;
				calculateClassification();
			}
		}
		public float Side3
		{
			get
			{
				return _side3;
			}
			set
			{
				if (value == _side3 || value < 0)
				{
					return;
				}
				_side3 = value;
				calculateClassification();
			}
		}
		public TriangleTypes Type => _type; 

        public string Classification => _type.ToFriendlyString();

		#endregion

		#region 

		private float _side1;
		private float _side2;
		private float _side3;
		private TriangleTypes _type = TriangleTypes.NotTriangle;

		#endregion

		#region Private methods

		private void calculateClassification()
		{
			_type = TriangleClassifier.Classify(this);
		}

		#endregion
	}
}