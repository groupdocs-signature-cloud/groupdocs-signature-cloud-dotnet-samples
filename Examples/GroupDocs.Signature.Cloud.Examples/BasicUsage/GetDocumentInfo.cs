using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get document information from File
    internal class GetDocumentInfo
	{
		public static void Run()
		{
			var apiInstance = new InfoApi(Constants.GetConfig());

			try
			{
				// Info settings.
				var infoSettings = new InfoSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "Pdf01_pages.pdf",
						Password = null,
						VersionId = null,
						StorageName = Constants.MyStorage,
					}
				};

				var request = new GetInfoRequest(infoSettings);

				var response = apiInstance.GetInfo(request);
				Console.WriteLine("Expected response type is InfoResult: " + response);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}