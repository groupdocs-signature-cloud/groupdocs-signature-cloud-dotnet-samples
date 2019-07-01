using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Get document information from File
	class DocumentInfo_File
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new InfoApi(configuration);

			try
			{
				// Info settings.
				var infoSettings = new InfoSettings()
				{
					FileInfo = new Sdk.Model.FileInfo()
					{
						FilePath = "Signaturedocs\\one-page.docx",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					}
				};

				var request = new GetInfoRequest(infoSettings);

				var response = apiInstance.GetInfo(request);
				Console.WriteLine("Expected response type is InfoResult: " + response.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature InfoApi: " + e.Message);
			}
		}
	}
}