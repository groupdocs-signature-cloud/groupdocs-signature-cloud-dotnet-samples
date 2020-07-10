using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Delete QR Code signature
    internal class DeleteQrCode
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
                // Search QRCode signature to get ID
                var searchQrCodeOptions = new SearchQRCodeOptions
                {
                    SignatureType = SignatureTypeEnum.QRCode,
                    MatchType = SearchQRCodeOptions.MatchTypeEnum.Contains,
                    Text = "GroupDocs.Signature Cloud",
                    QRCodeType = "Aztec",
                    AllPages = true
                };

                // Search settings
                var searchSettings = new SearchSettings
                {
                    FileInfo = new FileInfo
                    {
                        FilePath = "signedQRCode_one-page.docx",
                    },
                    Options = new List<SearchOptions> { searchQrCodeOptions }
                };

                // Call api method with request.
                var searchResult = apiInstance.SearchSignatures(new SearchSignaturesRequest(searchSettings));


				// Delete options
				var options = new DeleteOptions
                {
                    SignatureType = DeleteOptions.SignatureTypeEnum.QRCode,
                    SignatureId = searchResult.Signatures[0].SignatureId
                };

                // Delete settings
				var deleteSettings = new DeleteSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedQRCode_one-page.docx"
                    },
					Options = new List<DeleteOptions> { options }
				};

				// Create request
				var request = new DeleteSignaturesRequest(deleteSettings);

				// Call api method with request
				var response = apiInstance.DeleteSignatures(request);

				Console.WriteLine("Expected response type is DeleteResult: IsSuccess = " + (response.Succeeded.Count > 0));
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}