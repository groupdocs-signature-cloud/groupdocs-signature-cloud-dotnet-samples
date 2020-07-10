using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Delete File
    internal class DeleteFile
	{
		public static void Run()
		{
			var apiInstance = new FileApi(Constants.GetConfig());

			try
			{
				var request = new DeleteFileRequest("Signaturedocs1/one-page1.docx", Constants.MyStorage);

				apiInstance.DeleteFile(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs1/one-page1.docx' deleted.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FileApi: " + e.Message);
			}
		}
	}
}