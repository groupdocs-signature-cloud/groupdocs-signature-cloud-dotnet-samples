using System;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Get Get Disc Usage
    internal class GetDiscUsage
	{
		public static void Run()
		{
			var apiInstance = new StorageApi(Constants.GetConfig());

			try
			{
				var request = new GetDiscUsageRequest(Constants.MyStorage);

				var response = apiInstance.GetDiscUsage(request);
				Console.WriteLine("Expected response type is DiscUsage: " + response.UsedSize);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling StorageApi: " + e.Message);
			}
		}
	}
}