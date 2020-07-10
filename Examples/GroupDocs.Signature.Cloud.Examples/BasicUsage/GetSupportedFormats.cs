using System;
using GroupDocs.Signature.Cloud.Sdk.Api;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get All Supported Formats
    internal class GetSupportedFormats
	{
		public static void Run()
		{
            var apiInstance = new InfoApi(Constants.GetConfig());

			try
			{
				// Get supported file formats
				var response = apiInstance.GetSupportedFileFormats();

				foreach (var entry in response.Formats)
				{
					Console.WriteLine($"{entry.FileFormat}: {string.Join(",", entry.Extension)}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}