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
			var currentProduct = new Product { ProductName = "Saw", ProductId = 1, Description = "15-inch steel blade hand saw" };
			

			// Act


			// Assert
			Assert.Fail();
		}
	}
}