using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Copy Folder
	class Copy_Folder
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FolderApi(configuration);

			try
			{
				var request = new CopyFolderRequest("Signaturedocs", "Signaturedocs1", Common.MyStorage, Common.MyStorage);

				apiInstance.CopyFolder(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs' folder copied as 'Signaturedocs1'.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FolderApi: " + e.Message);
			}
		}
	}
}