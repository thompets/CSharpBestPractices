using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Biz.Tests
{
	[TestClass()]
	public class ProductTests
	{
		[TestMethod()]
		public void SayHelloTest()
		{
			// Arrange - set up test
			var currentProduct = new Product();
			currentProduct.ProductName = "Saw";
			currentProduct.ProductId = 1;
			currentProduct.Description = "15-inch steel blade hand saw";
			currentProduct.ProductVendor.CompanyName = "ABC Corp";			

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

		[TestMethod]
		public void SayHello_ObjectInitializer()
		{
			// Arrange
			var currentProduct = new Product
			{
				ProductId = 1,
				ProductName = "Saw",
				Description = "15-inch steel blade hand saw"
			};

			var expected = "Hello Saw (1): 15-inch steel blade hand saw";

			// Act
			var actual = currentProduct.SayHello();

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Product_Null()
		{
			// Arrange
			Product currentProdcut = null;
			var companyName = currentProdcut?.ProductVendor?.CompanyName;

			string expected = null;

			// Act
			var actual = companyName;

			// Assert
			Assert.AreEqual(expected, actual);
		}

	}
}