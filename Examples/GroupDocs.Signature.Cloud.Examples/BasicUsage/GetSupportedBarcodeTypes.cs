using System;
using GroupDocs.Signature.Cloud.Sdk.Api;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get All Supported barcode types
	internal class GetSupportedBarcodeTypes
	{
		public static void Run()
		{
            var apiInstance = new InfoApi(Constants.GetConfig());

			try
			{
				// Get supported barcode types
				var response = apiInstance.GetSupportedBarcodes();

				foreach (var entry in response.BarcodeTypes)
					Console.WriteLine($"{entry.Name}");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}