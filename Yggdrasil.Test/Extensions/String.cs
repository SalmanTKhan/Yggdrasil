using Xunit;
using Yggdrasil.Extensions;

namespace Yggdrasil.Test.Extensions
{
	public class StringExtensionTests
	{
		[Fact]
		public void LevenshteinDistance()
		{
			Assert.Equal(0, "test1".GetLevenshteinDistance("test1"));
			Assert.Equal(1, "test2".GetLevenshteinDistance("test3"));
			Assert.Equal(4, "test4".GetLevenshteinDistance("test4 asd"));
		}

		[Fact]
		public void IsNullOrWhiteSpace()
		{
			Assert.True(((string)null).IsNullOrWhiteSpace());
			Assert.True("".IsNullOrWhiteSpace());
			Assert.True(" ".IsNullOrWhiteSpace());
			Assert.True("\t".IsNullOrWhiteSpace());
			Assert.True("\n".IsNullOrWhiteSpace());
			Assert.True("\r".IsNullOrWhiteSpace());
			Assert.True("    ".IsNullOrWhiteSpace());
			Assert.False("  a  ".IsNullOrWhiteSpace());
			Assert.False("abc".IsNullOrWhiteSpace());
		}
	}
}
