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
		public const double InchesPerMeter = 39.37;
		public readonly decimal MinimumPrice;

		#region Constructors

		public Product()
		{
			Console.WriteLine("Product instance created");
			//this.ProductVendor = new Vendor();
			this.MinimumPrice = .96m;
			this.Category = "Tools";
		}

		public Product(int productId, string productName, string description) : this()
		{
			this.ProductId = productId;
			this.ProductName = productName;
			this.Description = description;
			if (ProductName.StartsWith("Bulk"))
			{
				this.MinimumPrice = 9.99m;
			}

			Console.WriteLine("Product instance has a name: " + ProductName);
		}

		#endregion

		#region Properties

		private string productName;
		private string description;
		private int productId;
		private Vendor productVendor;
		private DateTime? availabilityDate;

		public decimal Cost { get; set; }

		public string ProductName
		{
			get
			{
				var formattedValue = productName?.Trim();
				return formattedValue;
			}
			set
			{
				if (value.Length < 3)
				{
					ValidationMessage = "Product name must be at least 3 characters";
				}
				else if (value.Length > 20)
				{
					ValidationMessage = "Product name cannot be more than 20 characters";
				}
				else
				{
					productName = value;
				}				
			}
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

		public DateTime? AvailabilityDate
		{
			get { return availabilityDate; }
			set { availabilityDate = value; }
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

		internal string Category { get; set; }
		public int SequenceNumber { get; set; } = 1;
		public string ProductCode => $"{this.Category}-{this.SequenceNumber:0000}";
		public string ValidationMessage { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Calculates the suggested retail price.
		/// Expression body method.
		/// </summary>
		/// <param name="markupPercent">Percent used to mark up the cost.</param>
		/// <returns></returns>
		public decimal CalculateSuggestedPrice(decimal markupPercent) =>
			this.Cost + (this.Cost * markupPercent / 100);
		

		public string SayHello()
		{
			//var vendor = new Vendor();
			//vendor.SendWelcomeEmail("Message from Product");

			var emailService = new EmailService();
			var confirmation = emailService.SendMessage("New Product", this.ProductName, "sales@abc.com");

			var result = LogAction("saying hello");

			return "Hello " + ProductName +
				" (" + ProductId + "): " + 
				Description + " Available on: " + 
				AvailabilityDate?.ToShortDateString();
		}

		public override string ToString() =>
			this.ProductName + " (" + this.productId + ")";

		#endregion
	}
}
