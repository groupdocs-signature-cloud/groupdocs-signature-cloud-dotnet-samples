using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
    // Update document with QRCode signature
    internal class UpdateQrCode
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


				// Update options
				var options = new UpdateOptions
                {
                    SignatureType = UpdateOptions.SignatureTypeEnum.QRCode,
                    Left = 200,
                    Top = 200,
                    Width = 200,
                    Height = 200,
                    IsSignature = true,
                    SignatureId = searchResult.Signatures[0].SignatureId
                };

                // Update settings
				var updateSettings = new UpdateSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "signedQRCode_one-page.docx"
                    },
					Options = new List<UpdateOptions> { options }
				};

				// Create request
				var request = new UpdateSignaturesRequest(updateSettings);

				// Call api method with request
				var response = apiInstance.UpdateSignatures(request);

				Console.WriteLine("Expected response type is UpdateResult: IsSuccess = " + (response.Succeeded.Count > 0));
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}