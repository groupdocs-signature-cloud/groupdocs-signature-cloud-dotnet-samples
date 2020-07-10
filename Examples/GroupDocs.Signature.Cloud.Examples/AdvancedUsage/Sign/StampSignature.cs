using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Sign document with a Stamp and options
    internal class StampSignature
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options
                var options = new SignStampOptions
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

                // Sign settings
				var signSettings = new SignSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "one-page.docx"
					},
					SaveOptions = new SaveOptions { OutputFilePath = "signedStamp_one-page.docx", SaveFormat = "docx" },
					Options = new List<SignOptions> { options }
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