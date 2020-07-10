using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Verify document with barcode signature
    internal class VerifyBarcode
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Verify options.
                var options = new VerifyBarcodeOptions
                {
                    SignatureType = SignatureTypeEnum.Barcode,
                    MatchType = VerifyTextOptions.MatchTypeEnum.Contains,
                    Text = "123456789012",
                    BarcodeType = "Code128",
                    Page = 1,
                    AllPages = true
                };

                // Verify settings
				var verifySettings = new VerifySettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedBarcode_one-page.docx"
					},
					Options = new List<VerifyOptions> { options }
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