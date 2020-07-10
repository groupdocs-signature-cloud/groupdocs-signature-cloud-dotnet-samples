using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Search digital signature with options
    internal class SearchDigital
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Search options
                var options = new SearchDigitalOptions
                {
                    SignatureType = SignatureTypeEnum.Digital,
                    AllPages = false,
                    Page = 1,
                    PagesSetup = new PagesSetup
                    {
                        EvenPages = false,
                        FirstPage = true,
                        LastPage = false,
                        OddPages = false,
                        PageNumbers = new List<int?> {1}
                    }
                };

                // Search settings
				var searchSettings = new SearchSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedDigital_sample2.pdf"
					},
					Options = new List<SearchOptions> { options }
				};

				// Create request.
				var request = new SearchSignaturesRequest(searchSettings);

				// Call api method with request.
				var response = apiInstance.SearchSignatures(request);

				Console.WriteLine("Expected response type is SearchResult: IsSuccess = " + response);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}