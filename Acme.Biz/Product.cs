using Acme.Common;
using static Acme.Common.LoggingService;
using System;

namespace Acme.Biz
{
	/// <summary>
	/// Manages products carried in inventory.
	/// </summary>
	public class Product
    {
		#region Constructors
		public Product()
		{
			Console.WriteLine("Product instance created");
			//this.ProductVendor = new Vendor();
		}

		public Product(int productId, string productName, string description) : this()
		{
			this.ProductId = productId;
			this.ProductName = productName;
			this.Description = description;

			Console.WriteLine("Product instance has a name: " + ProductName);
		}
		#endregion

		#region Properties
		private string productName;
		private string description;
		private int productId;
		private Vendor productVendor;

		public string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public int ProductId
		{
			get { return productId; }
			set { productId = value; }
		}		

		public Vendor ProductVendor
		{
			get
			{
				// Lazy loading approach
				if (productVendor == null)
				{
					productVendor = new Vendor();
				}

				return productVendor;
			}
			set { productVendor = value; }
		}

		#endregion

		#region Methods
		public string SayHello()
		{
			//var vendor = new Vendor();
			//vendor.SendWelcomeEmail("Message from Product");

			var emailService = new EmailService();
			var confirmation = emailService.SendMessage("New Product", this.ProductName, "sales@abc.com");

			var result = LogAction("saying hello");

			return "Hello " + ProductName +
				" (" + ProductId + "): " + Description;
		} 
		#endregion
	}
}
