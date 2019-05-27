using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Sign document with multiple/collection of signatures and options
	class Multiple_Collection_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options to include in collection.

				// Barcode sign options.
				var barcodeoptions = new SignBarcodeOptions();
				barcodeoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				barcodeoptions.SignatureType = SignatureTypeEnum.Barcode;

				// set signature properties
				barcodeoptions.Text = "123456789012";
				barcodeoptions.BarcodeType = "Code128";
				barcodeoptions.CodeTextAlignment = SignBarcodeOptions.CodeTextAlignmentEnum.None;

				// set signature position on a page
				barcodeoptions.Left = 100;
				barcodeoptions.Top = 100;
				barcodeoptions.Width = 300;
				barcodeoptions.Height = 100;
				barcodeoptions.LocationMeasureType = SignTextOptions.LocationMeasureTypeEnum.Pixels;
				barcodeoptions.SizeMeasureType = SignTextOptions.SizeMeasureTypeEnum.Pixels;
				barcodeoptions.Stretch = SignTextOptions.StretchEnum.None;
				barcodeoptions.RotationAngle = 0;
				barcodeoptions.HorizontalAlignment = SignTextOptions.HorizontalAlignmentEnum.None;
				barcodeoptions.VerticalAlignment = SignTextOptions.VerticalAlignmentEnum.None;
				barcodeoptions.Margin = new Padding() { All = 5 };
				barcodeoptions.MarginMeasureType = SignTextOptions.MarginMeasureTypeEnum.Pixels;

				// Set signature appearance
				barcodeoptions.ForeColor = new Color() { Web = "BlueViolet" };
				barcodeoptions.BorderColor = new Color() { Web = "DarkOrange" };
				barcodeoptions.BackgroundColor = new Color() { Web = "DarkOrange" };
				barcodeoptions.Opacity = 0.8;
				barcodeoptions.InnerMargins = new Padding() { All = 2 };
				barcodeoptions.BorderVisiblity = true;
				barcodeoptions.BorderDashStyle = SignTextOptions.BorderDashStyleEnum.Dash;
				barcodeoptions.BorderWeight = 12;

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

				// Stamp Sign options.
				var stampoptions = new SignStampOptions();
				stampoptions.DocumentType = DocumentTypeEnum.WordProcessing;
				stampoptions.SignatureType = SignatureTypeEnum.Stamp;

				// Set signature properties
				stampoptions.ImageGuid = "Signaturedocs\\signature.jpg";

				// Set signature position on a page
				stampoptions.Left = 100;
				stampoptions.Top = 100;
				stampoptions.Width = 300;
				stampoptions.Height = 200;
				stampoptions.LocationMeasureType = SignImageOptions.LocationMeasureTypeEnum.Pixels;
				stampoptions.SizeMeasureType = SignImageOptions.SizeMeasureTypeEnum.Pixels;
				stampoptions.RotationAngle = 0;
				stampoptions.HorizontalAlignment = SignImageOptions.HorizontalAlignmentEnum.None;
				stampoptions.VerticalAlignment = SignImageOptions.VerticalAlignmentEnum.None;
				stampoptions.Margin = new Padding() { All = 5 };
				stampoptions.MarginMeasureType = SignImageOptions.MarginMeasureTypeEnum.Pixels;

				// Set signature appearance
				stampoptions.BackgroundColor = new Color() { Web = "CornflowerBlue" };
				stampoptions.BackgroundColorCropType = SignStampOptions.BackgroundColorCropTypeEnum.InnerArea;
				stampoptions.BackgroundImageCropType = SignStampOptions.BackgroundImageCropTypeEnum.MiddleArea;
				stampoptions.Opacity = 0.8;

				stampoptions.OuterLines = new List<StampLine> {
					new StampLine()
					{
						 Text = "GroupDocs Cloud",
						 Font = new SignatureFont() { FontFamily = "Arial", FontSize = 12, Bold = true, Italic = true, Underline = true },
						 TextBottomIntent = 5,
						 TextColor = new Color() { Web = "Gold" },
						 TextRepeatType = StampLine.TextRepeatTypeEnum.FullTextRepeat,
						 BackgroundColor = new Color() { Web = "BlueViolet" },
						 Height = 20,
						 InnerBorder = new BorderLine() { Color = new Color() { Web = "DarkOrange" }, Style = BorderLine.StyleEnum.LongDash, Transparency = 0.5, Weight = 1.2 },
						 OuterBorder = new BorderLine() { Color = new Color() { Web = "DarkOrange" }, Style = BorderLine.StyleEnum.LongDashDot, Transparency = 0.7, Weight = 1.4 },
						 Visible = true
					 }
				 };

				stampoptions.InnerLines = new List<StampLine> {
					 new StampLine()
					 {
						 Text = "GroupDocs.Signature Cloud",
						 Font = new SignatureFont() { FontFamily = "Times New Roman", FontSize = 20, Bold = true, Italic = true, Underline = true },
						 TextBottomIntent = 3,
						 TextColor = new Color() { Web = "Gold" },
						 TextRepeatType = StampLine.TextRepeatTypeEnum.None,
						 BackgroundColor = new Color() { Web = "CornflowerBlue" },
						 Height = 30,
						 InnerBorder = new BorderLine() { Color = new Color() { Web = "OliveDrab" }, Style = BorderLine.StyleEnum.LongDash, Transparency = 0.5, Weight = 1.2 },
						 OuterBorder = new BorderLine() { Color = new Color() { Web = "GhostWhite" }, Style = BorderLine.StyleEnum.Dot, Transparency = 0.4, Weight = 1.4 },
						 Visible = true
					 }
				};

				// Set pages for signing (each of these page settings could be used singly)
				stampoptions.AllPages = false;
				stampoptions.Page = 1;
				stampoptions.PagesSetup = new PagesSetup()
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
					SaveOptions = new SaveOptions() { OutputFilePath = "Signaturedocs\\signedCollection_one-page.docx", SaveFormat = "docx" },
					Options = new List<SignOptions>() { barcodeoptions, stampoptions }
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