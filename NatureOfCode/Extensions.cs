using System;

namespace NatureOfCode
{
	/// <summary>
	/// Convert to Radians.
	/// </summary>
	/// <returns>The value in radians</returns>
	public static class Extensions
	{
		public static double ToRadians(this double val)
		{
			return (Math.PI / 180) * val;
		}
	}
}