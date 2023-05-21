﻿using Yggdrasil.Geometry;
using Xunit;

namespace Yggdrasil.Tests.Geometry
{
	public class Vector2Tests
	{
		[Fact]
		public void Operators()
		{
			var vector1 = new Vector2(10, 10);
			var vector2 = new Vector2(10, 10);

			var vector3 = vector1 + vector2;
			Assert.Equal(new Vector2(20, 20), vector3);

			vector3 -= vector2;
			Assert.Equal(new Vector2(10, 10), vector3);

			vector3 -= vector2;
			Assert.Equal(new Vector2(0, 0), vector3);

			vector3 *= 100;
			Assert.Equal(new Vector2(0, 0), vector3);

			vector3 += new Vector2(50, 50);
			Assert.Equal(new Vector2(50, 50), vector3);

			vector3 *= 2;
			Assert.Equal(new Vector2(100, 100), vector3);

			vector3 /= 4;
			Assert.Equal(new Vector2(25, 25), vector3);
		}
	}
}
