using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Copy File
	class Copy_File
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FileApi(configuration);

			try
			{
				var request = new CopyFileRequest("Signaturedocs/one-page1.docx", "Signaturedocs/one-page-copied.docx", Common.MyStorage, Common.MyStorage);

				apiInstance.CopyFile(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs/one-page1.docx' file copied as 'Signaturedocs/one-page-copied.docx'.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FileApi: " + e.Message);
			}
		}
	}
}