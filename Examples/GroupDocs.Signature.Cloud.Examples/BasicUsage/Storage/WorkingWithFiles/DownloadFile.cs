using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Download_File
    internal class DownloadFile
	{
		public static void Run()
		{
			var apiInstance = new FileApi(Constants.GetConfig());

			try
			{
				var request = new DownloadFileRequest("one-page.docx", Constants.MyStorage);

				var response = apiInstance.DownloadFile(request);
				Console.WriteLine("Expected response type is Stream: " + response.Length);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FileApi: " + e.Message);
			}
		}
	}
}