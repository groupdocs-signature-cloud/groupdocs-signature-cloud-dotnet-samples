using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Sign document with text and options
	class Text_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options.
				var options = new SignTextOptions();
				options.DocumentType = DocumentTypeEnum.WordProcessing;
				options.SignatureType = SignatureTypeEnum.Text;

				// Set signature properties
				options.Text = "GroupDocs.Signature Cloud";

				// Set signature position on a page
				options.Left = 100;
				options.Top = 100;
				options.Width = 100;
				options.Height = 100;
				options.LocationMeasureType = SignTextOptions.LocationMeasureTypeEnum.Pixels;
				options.SizeMeasureType = SignTextOptions.SizeMeasureTypeEnum.Pixels;
				options.Stretch = SignTextOptions.StretchEnum.None;
				options.RotationAngle = 0;
				options.HorizontalAlignment = SignTextOptions.HorizontalAlignmentEnum.None;
				options.VerticalAlignment = SignTextOptions.VerticalAlignmentEnum.None;
				options.Margin = new Padding() { All = 5 };
				options.MarginMeasureType = SignTextOptions.MarginMeasureTypeEnum.Pixels;

				// Set signature appearance
				options.Font = new SignatureFont()
				{ FontFamily = "Arial", FontSize = 12, Bold = true, Italic = false, Underline = false };
				options.ForeColor = new Color() { Web = "BlueViolet" };
				options.BorderColor = new Color() { Web = "DarkOrange" };
				options.BackgroundColor = new Color() { Web = "DarkOrange" };
				options.BorderVisiblity = true;
				options.BorderDashStyle = SignTextOptions.BorderDashStyleEnum.Dash;

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
						FilePath = "Signaturedocs\\one-page.docx",
						Password = null,
						VersionId = null,
						StorageName = Common.MyStorage,
					},
					SaveOptions = new SaveOptions() { OutputFilePath = "Signaturedocs\\signedText_one-page.docx", SaveFormat = "docx" },
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