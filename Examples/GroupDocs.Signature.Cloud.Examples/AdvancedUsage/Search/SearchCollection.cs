using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Search multiple collection of signatures with options
    internal class SearchCollection
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options to include in collection.

				// Barcode Search options.
                var barcodeOptions = new SearchBarcodeOptions
                {
                    SignatureType = SignatureTypeEnum.Barcode,
                    MatchType = SearchBarcodeOptions.MatchTypeEnum.Contains,
                    Text = "123456789012",
                    BarcodeType = "Code128",
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

                // QRCode search options.
                var qrCodeOptions = new SearchQRCodeOptions
                {
                    SignatureType = SignatureTypeEnum.QRCode,
                    MatchType = SearchQRCodeOptions.MatchTypeEnum.Contains,
                    Text = "GroupDocs.Signature Cloud",
                    QRCodeType = "Aztec",
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

                // Search settings.
				var searchSettings = new SearchSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedCollection_one-page.docx"
					},
					Options = new List<SearchOptions> { barcodeOptions, qrCodeOptions }
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