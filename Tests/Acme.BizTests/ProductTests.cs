using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeBiz.Tests
{
	[TestClass()]
	public class ProductTests
	{
		[TestMethod()]
		public void SayHelloTest()
		{
			// Arrange - set up test
			var currentProduct = new Product
			{
				ProductName = "Saw",
				ProductId = 1,
				Description = "15-inch steel blade hand saw"
			};

			var expected = "Hello Saw (1): 15-inch steel blade hand saw";

			// Act
			var actual = currentProduct.SayHello();

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void SayHello_ParameterizedConstructor()
		{
			// Arrange - set up test
			var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

			var expected = "Hello Saw (1): 15-inch steel blade hand saw";

			// Act
			var actual = currentProduct.SayHello();

			// Assert
			Assert.AreEqual(expected, actual);
		}

	}
}