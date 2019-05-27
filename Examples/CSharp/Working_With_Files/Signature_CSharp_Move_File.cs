using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Move File
	class Move_File
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FileApi(configuration);

			try
			{
				var request = new MoveFileRequest("Signaturedocs/one-page1.docx", "Signaturedocs1/one-page1.docx", Common.MyStorage, Common.MyStorage);

				apiInstance.MoveFile(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs/one-page1.docx' file moved to 'Signaturedocs1/one-page1.docx'.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FileApi: " + e.Message);
			}
		}
	}
}