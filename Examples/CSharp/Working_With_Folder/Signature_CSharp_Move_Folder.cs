using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Move Folder
	class Move_Folder
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FolderApi(configuration);

			try
			{
				var request = new MoveFolderRequest("Signaturedocs1", "Signaturedocs\\Signaturedocs1", Common.MyStorage, Common.MyStorage);

				apiInstance.MoveFolder(request);
				Console.WriteLine("Expected response type is Void: 'Signaturedocs1' folder moved to 'Signaturedocs/Signaturedocs1'.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FolderApi: " + e.Message);
			}
		}
	}
}