using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Client;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	// Sign document with a Stamp and options
	class Stamp_Signature
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new SignApi(configuration);

			try
			{
				// Sign options.
				var options = new SignStampOptions();
				options.DocumentType = DocumentTypeEnum.WordProcessing;
				options.SignatureType = SignatureTypeEnum.Stamp;

				// Set signature properties
				options.ImageGuid = "Signaturedocs\\signature.jpg";

				// Set signature position on a page
				options.Left = 100;
				options.Top = 100;
				options.Width = 300;
				options.Height = 200;
				options.LocationMeasureType = SignImageOptions.LocationMeasureTypeEnum.Pixels;
				options.SizeMeasureType = SignImageOptions.SizeMeasureTypeEnum.Pixels;
				options.RotationAngle = 0;
				options.HorizontalAlignment = SignImageOptions.HorizontalAlignmentEnum.None;
				options.VerticalAlignment = SignImageOptions.VerticalAlignmentEnum.None;
				options.Margin = new Padding() { All = 5 };
				options.MarginMeasureType = SignImageOptions.MarginMeasureTypeEnum.Pixels;

				// Set signature appearance
				options.BackgroundColor = new Color() { Web = "CornflowerBlue" };
				options.BackgroundColorCropType = SignStampOptions.BackgroundColorCropTypeEnum.InnerArea;
				options.BackgroundImageCropType = SignStampOptions.BackgroundImageCropTypeEnum.MiddleArea;
				options.Opacity = 0.8;

				options.OuterLines = new List<StampLine> {
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

				options.InnerLines = new List<StampLine> {
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
					SaveOptions = new SaveOptions() { OutputFilePath = "Signaturedocs\\signedStamp_one-page.docx", SaveFormat = "docx" },
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