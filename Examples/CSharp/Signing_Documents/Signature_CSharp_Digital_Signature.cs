using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Sign document with Digital and options
	class Digital_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options.
				var options = new SignDigitalOptions();
				options.DocumentType = DocumentTypeEnum.Pdf;
				options.SignatureType = SignatureTypeEnum.Digital;

				// set signature properties
				options.ImageGuid = "Signaturedocs\\signature.jpg";
				options.CertificateGuid = "Signaturedocs\\temp.pfx";
				options.Password = "1234567890";

				// Set signature position on a page
				options.Left = 100;
				options.Top = 100;
				options.Width = 200;
				options.Height = 200;
				options.LocationMeasureType = SignImageOptions.LocationMeasureTypeEnum.Pixels;
				options.SizeMeasureType = SignImageOptions.SizeMeasureTypeEnum.Pixels;
				options.RotationAngle = 0;
				options.HorizontalAlignment = SignImageOptions.HorizontalAlignmentEnum.None;
				options.VerticalAlignment = SignImageOptions.VerticalAlignmentEnum.None;
				options.Margin = new Padding() { All = 5 };
				options.MarginMeasureType = SignImageOptions.MarginMeasureTypeEnum.Pixels;

				// Set signature appearance
				options.Opacity = 0.8;

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

				// Sign settings.
				var signSettings = new SignSettings()
				{
					FileInfo = new Sdk.Model.FileInfo()
					{
						FilePath = "Signaturedocs\\sample2.pdf",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					SaveOptions = new SaveOptions() { OutputFilePath = "Signaturedocs\\signedDigital_sample2.pdf", SaveFormat = "pdf" },
					Options = new List<SignOptions>() { options }
				};

				// Create request.
				var request = new CreateSignaturesRequest(signSettings);

				// Call api method with request.
				var response = apiInstance.CreateSignatures(request);

				Console.WriteLine("Expected response type is SignResult: DownloadUrl=" + response.DownloadUrl);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Signature SignApi: " + e.Message);
			}
		}
	}
}