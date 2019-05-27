using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Search multiple/ collection of signatures with options
	class Search_Multiple_Collection_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options to include in collection.

				// Barcode Search options.
				var barcodeoptions = new SearchBarcodeOptions();
				barcodeoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				barcodeoptions.SignatureType = SignatureTypeEnum.Barcode;
				barcodeoptions.MatchType = SearchBarcodeOptions.MatchTypeEnum.Contains;

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

				// QRCode search options.
				var qrcodeoptions = new SearchQRCodeOptions();
				qrcodeoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				qrcodeoptions.SignatureType = SignatureTypeEnum.QRCode;
				qrcodeoptions.MatchType = SearchQRCodeOptions.MatchTypeEnum.Contains;

				// set signature properties
				qrcodeoptions.Text = "GroupDocs.Signature Cloud";
				qrcodeoptions.QRCodeType = "Aztec";

				// Set pages for signing (each of these page settings could be used singly)
				qrcodeoptions.AllPages = false;
				qrcodeoptions.Page = 1;
				qrcodeoptions.PagesSetup = new PagesSetup()
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
						FilePath = "Signaturedocs\\signedCollection_one-page.docx",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					Options = new List<SearchOptions>() { barcodeoptions, qrcodeoptions }
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