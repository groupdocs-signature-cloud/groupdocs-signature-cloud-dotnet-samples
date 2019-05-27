using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Verify document with multiple/collection of signatures and options
	class Verify_Multiple_Collection_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options to include in collection.

				// Barcode Verify options.
				var barcodeoptions = new VerifyBarcodeOptions();
				barcodeoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				barcodeoptions.SignatureType = SignatureTypeEnum.Barcode;
				barcodeoptions.MatchType = VerifyBarcodeOptions.MatchTypeEnum.Contains;

				// set signature properties
				barcodeoptions.Text = "123456789012";
				barcodeoptions.BarcodeType = "Code128";

				// Set pages for signing (each of these page settings could be used singly)
				barcodeoptions.AllPages = false;
				barcodeoptions.Page = 1;
				barcodeoptions.PagesSetup = new PagesSetup()
				{
					EvenPages = false,
					FirstPage = true,
					LastPage = false,
					OddPages = false,
					PageNumbers = new List<int?>() { 1 }
				};

				// Text verify options.
				var textoptions = new VerifyTextOptions();
				textoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				textoptions.SignatureType = SignatureTypeEnum.Text;
				textoptions.MatchType = VerifyTextOptions.MatchTypeEnum.Contains;

				// Set signature properties
				textoptions.Text = "GroupDocs.Signature Cloud";

				// Set pages for signing (each of these page settings could be used singly)
				textoptions.AllPages = false;
				textoptions.Page = 1;
				textoptions.PagesSetup = new PagesSetup()
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
						FilePath = "Signaturedocs\\signedCollection_one-page.docx",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					Options = new List<VerifyOptions>() { barcodeoptions, textoptions }
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