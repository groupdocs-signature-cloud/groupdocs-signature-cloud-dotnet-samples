using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get document preview image
    internal class GetDocumentPreview
	{
		public static void Run()
		{
			var apiInstance = new PreviewApi(Constants.GetConfig());

			try
			{
				// Preview settings
				var previewSettings = new PreviewSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "sample2.pdf",
						Password = null,
						VersionId = null,
						StorageName = Constants.MyStorage,
					}
				};

				var request = new PreviewDocumentRequest(previewSettings);

				var response = apiInstance.PreviewDocument(request);
				Console.WriteLine("Expected response type is PreviewResult: " + response);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling PreviewApi: " + e.Message);
			}
		}
	}
}