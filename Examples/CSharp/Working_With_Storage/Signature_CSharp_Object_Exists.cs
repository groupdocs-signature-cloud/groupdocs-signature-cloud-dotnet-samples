using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Is Object Exists
	class Object_Exists
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new StorageApi(configuration);

			try
			{
				var request = new ObjectExistsRequest("Signaturedocs/one-page.docx", Common.MyStorage);

				var response = apiInstance.ObjectExists(request);
				Console.WriteLine("Expected response type is ObjectExist: " + response.Exists.Value.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling StorageApi: " + e.Message);
			}
		}
	}
}