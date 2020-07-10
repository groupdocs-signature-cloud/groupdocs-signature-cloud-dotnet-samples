using System;
using GroupDocs.Signature.Cloud.Sdk.Api;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get All Supported QRCodes
    internal class GetSupportedQrCodeTypes
	{
		public static void Run()
		{
            var apiInstance = new InfoApi(Constants.GetConfig());

			try
			{
				// Get supported QR code types
				var response = apiInstance.GetSupportedQRCodes();

				foreach (var entry in response.QRCodeTypes)
				{
					Console.WriteLine($"{entry.Name}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}