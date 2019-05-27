using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Delete Folder
	class Delete_Folder
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FolderApi(configuration);

			try
			{
				var request = new DeleteFolderRequest("Signaturedocs/Signaturedocs1", Common.MyStorage, true);

				apiInstance.DeleteFolder(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs/Signaturedocs1' folder deleted recusrsively.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FolderApi: " + e.Message);
			}
		}
	}
}