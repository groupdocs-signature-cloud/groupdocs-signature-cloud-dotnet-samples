using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Verify document with qrcode signature and options
	class Verify_QRCode_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Verify options.
				var options = new VerifyQRCodeOptions();
				options.DocumentType = DocumentTypeEnum.WordProcessing;
				options.SignatureType = SignatureTypeEnum.QRCode;
				options.MatchType = VerifyQRCodeOptions.MatchTypeEnum.Contains;

				// set signature properties
				options.Text = "GroupDocs.Signature Cloud";
				options.QRCodeType = "Aztec";

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

				// Verify settings.
				var verifySettings = new VerifySettings()
				{
					FileInfo = new Sdk.Model.FileInfo()
					{
						FilePath = "Signaturedocs\\signedQRCode_one-page.docx",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					Options = new List<VerifyOptions>() { options }
				};

				// Create request.
				var request = new VerifySignaturesRequest(verifySettings);

				// Call api method with request.
				var response = apiInstance.VerifySignatures(request);

				Console.WriteLine("Expected response type is VerifyResult: IsSuccess = " + response.IsSuccess.Value);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}