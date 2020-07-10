using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Verify document with collection of signatures
    internal class VerifyCollection
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
                // Barcode Verify options
                var barcodeOptions = new VerifyBarcodeOptions
                {
                    SignatureType = SignatureTypeEnum.Barcode,
                    MatchType = VerifyTextOptions.MatchTypeEnum.Contains,
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

                // Text verify options
                var textOptions = new VerifyTextOptions
                {
                    SignatureType = SignatureTypeEnum.Text,
                    MatchType = VerifyTextOptions.MatchTypeEnum.Contains,
                    Text = "GroupDocs.Signature Cloud",
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

                // Verify settings
				var verifySettings = new VerifySettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedCollection_one-page.docx"
					},
					Options = new List<VerifyOptions> { barcodeOptions, textOptions }
				};

				// Create request
				var request = new VerifySignaturesRequest(verifySettings);

				// Call api method with request
				var response = apiInstance.VerifySignatures(request);

				Console.WriteLine("Expected response type is VerifyResult: IsSuccess = " + (response.IsSuccess != null && response.IsSuccess.Value));
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}