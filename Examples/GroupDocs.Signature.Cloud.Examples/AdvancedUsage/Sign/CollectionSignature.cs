using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Sign document with multiple/collection of signatures and options
    internal class CollectionSignature
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
                // Barcode sign options.
                var barcodeOptions = new SignBarcodeOptions
                {
                    SignatureType = SignatureTypeEnum.Barcode,
                    Text = "123456789012",
                    BarcodeType = "Code128",
                    CodeTextAlignment = SignBarcodeOptions.CodeTextAlignmentEnum.None,
                    Left = 100,
                    Top = 100,
                    Width = 300,
                    Height = 100,
                    LocationMeasureType = SignTextOptions.LocationMeasureTypeEnum.Pixels,
                    SizeMeasureType = SignTextOptions.SizeMeasureTypeEnum.Pixels,
                    Stretch = SignTextOptions.StretchEnum.None,
                    RotationAngle = 0,
                    HorizontalAlignment = SignTextOptions.HorizontalAlignmentEnum.None,
                    VerticalAlignment = SignTextOptions.VerticalAlignmentEnum.None,
                    Margin = new Padding {All = 5},
                    MarginMeasureType = SignTextOptions.MarginMeasureTypeEnum.Pixels,
                    ForeColor = new Color {Web = "BlueViolet"},
                    Border = new BorderLine
                    {
                        Color = new Color {Web = "DarkOrange"},
                        Visible = true,
                        Style = BorderLine.StyleEnum.Dash,
                        Weight = 12
                    },
                    BackgroundColor = new Color {Web = "DarkOrange"},
                    InnerMargins = new Padding {All = 2},
                    AllPages = false,
                    Page = 1,
                    PagesSetup = new PagesSetup
                    {
                        EvenPages = false,
                        FirstPage = true,
                        LastPage = false,
                        OddPages = false,
                        PageNumbers = new List<int?> {1}
                    }
                };

                // Stamp Sign options.
                var stampOptions = new SignStampOptions
                {
                    SignatureType = SignatureTypeEnum.Stamp,
                    ImageFilePath = "signature.jpg",
                    Left = 100,
                    Top = 100,
                    Width = 300,
                    Height = 200,
                    LocationMeasureType = SignImageOptions.LocationMeasureTypeEnum.Pixels,
                    SizeMeasureType = SignImageOptions.SizeMeasureTypeEnum.Pixels,
                    RotationAngle = 0,
                    HorizontalAlignment = SignImageOptions.HorizontalAlignmentEnum.None,
                    VerticalAlignment = SignImageOptions.VerticalAlignmentEnum.None,
                    Margin = new Padding {All = 5},
                    MarginMeasureType = SignImageOptions.MarginMeasureTypeEnum.Pixels,
                    BackgroundColor = new Color {Web = "CornflowerBlue"},
                    BackgroundColorCropType = SignStampOptions.BackgroundColorCropTypeEnum.InnerArea,
                    BackgroundImageCropType = SignStampOptions.BackgroundImageCropTypeEnum.MiddleArea,
                    OuterLines =
                        new List<StampLine>
                        {
                            new StampLine
                            {
                                Text = "GroupDocs Cloud",
                                Font =
                                    new SignatureFont
                                    {
                                        FontFamily = "Arial",
                                        FontSize = 12,
                                        Bold = true,
                                        Italic = true,
                                        Underline = true
                                    },
                                TextBottomIntent = 5,
                                TextColor = new Color {Web = "Gold"},
                                TextRepeatType = StampLine.TextRepeatTypeEnum.FullTextRepeat,
                                BackgroundColor = new Color {Web = "BlueViolet"},
                                Height = 20,
                                InnerBorder =
                                    new BorderLine
                                    {
                                        Color = new Color {Web = "DarkOrange"},
                                        Style = BorderLine.StyleEnum.LongDash,
                                        Transparency = 0.5,
                                        Weight = 1.2
                                    },
                                OuterBorder = new BorderLine
                                {
                                    Color = new Color {Web = "DarkOrange"},
                                    Style = BorderLine.StyleEnum.LongDashDot,
                                    Transparency = 0.7,
                                    Weight = 1.4
                                },
                                Visible = true
                            }
                        },
                    InnerLines = new List<StampLine>
                    {
                        new StampLine
                        {
                            Text = "GroupDocs.Signature Cloud",
                            Font =
                                new SignatureFont
                                {
                                    FontFamily = "Times New Roman",
                                    FontSize = 20,
                                    Bold = true,
                                    Italic = true,
                                    Underline = true
                                },
                            TextBottomIntent = 3,
                            TextColor = new Color {Web = "Gold"},
                            TextRepeatType = StampLine.TextRepeatTypeEnum.None,
                            BackgroundColor = new Color {Web = "CornflowerBlue"},
                            Height = 30,
                            InnerBorder =
                                new BorderLine
                                {
                                    Color = new Color {Web = "OliveDrab"},
                                    Style = BorderLine.StyleEnum.LongDash,
                                    Transparency = 0.5,
                                    Weight = 1.2
                                },
                            OuterBorder = new BorderLine
                            {
                                Color = new Color {Web = "GhostWhite"},
                                Style = BorderLine.StyleEnum.Dot,
                                Transparency = 0.4,
                                Weight = 1.4
                            },
                            Visible = true
                        }
                    },
                    AllPages = false,
                    Page = 1,
                    PagesSetup = new PagesSetup
                    {
                        EvenPages = false,
                        FirstPage = true,
                        LastPage = false,
                        OddPages = false,
                        PageNumbers = new List<int?> {1}
                    }
                };

                // Sign settings.
				var signSettings = new SignSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "one-page.docx"
					},
					SaveOptions = new SaveOptions { OutputFilePath = "signedCollection_one-page.docx", SaveFormat = "docx" },
					Options = new List<SignOptions> { barcodeOptions, stampOptions }
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