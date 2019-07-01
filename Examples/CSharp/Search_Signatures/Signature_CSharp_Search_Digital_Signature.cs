using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Search digital signature with options
	class Search_Digital_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Search options.
				var options = new SearchDigitalOptions();
				options.DocumentType = DocumentTypeEnum.Pdf;
				options.SignatureType = SignatureTypeEnum.Digital;

				// Set pages for signing (each of these page settings could be used singly)
				options.AllPages = false;
				options.Page = 1;
				options.PagesSetup = new PagesSetup()
				{
					EvenPages = false,
					FirstPage = true,
					LastPage = false,
					OddPages = false,
					PageNumbers = new List<int?>() { 1 }
				};

				// Search settings.
				var SearchSettings = new SearchSettings()
				{
					FileInfo = new Sdk.Model.FileInfo()
					{
						FilePath = "Signaturedocs\\signedDigital_sample2.pdf",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					Options = new List<SearchOptions>() { options }
				};

				// Create request.
				var request = new SearchSignaturesRequest(SearchSettings);

				// Call api method with request.
				var response = apiInstance.SearchSignatures(request);

				Console.WriteLine("Expected response type is SearchResult: IsSuccess = " + response.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}