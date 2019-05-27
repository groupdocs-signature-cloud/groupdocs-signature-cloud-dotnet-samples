using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Get Files List
	class Get_Files_List
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new FolderApi(configuration);

			try
			{
				var request = new GetFilesListRequest("Signaturedocs", Common.MyStorage);

				var response = apiInstance.GetFilesList(request);
				Console.WriteLine("Expected response type is FilesList: " + response.Value.Count.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling FolderApi: " + e.Message);
			}
		}
	}
}