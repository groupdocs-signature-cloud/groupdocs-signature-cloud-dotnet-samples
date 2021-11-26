using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.Info
{
	// Get document information from File with showing deleted signatures info
    internal class ShowDeletedSignatures
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
						FilePath = "sample2.pdf",
						Password = null,
						VersionId = null,
						StorageName = Constants.MyStorage,
					},
					ShowDeletedSignaturesInfo = true
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