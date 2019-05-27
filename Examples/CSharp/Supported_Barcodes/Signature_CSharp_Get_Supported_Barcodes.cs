using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Get All Supported Barcodes
	class Get_All_Supported_Barcodes
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);

			var apiInstance = new InfoApi(configuration);

			try
			{
				// Get supported file barcodes
				var response = apiInstance.GetSupportedBarcodes();

				foreach (var entry in response.BarcodeTypes)
				{
					Console.WriteLine(string.Format("{0}", entry.Name));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}