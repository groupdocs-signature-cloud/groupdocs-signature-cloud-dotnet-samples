using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Sign document with QRCode and options
    internal class QrCodeSignature
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options
                var options = new SignQRCodeOptions
                {
                    SignatureType = SignatureTypeEnum.QRCode,
                    Text = "GroupDocs.Signature Cloud",
                    QRCodeType = "Aztec",
                    Left = 100,
                    Top = 100,
                    Width = 200,
                    Height = 200,
                    LocationMeasureType = SignTextOptions.LocationMeasureTypeEnum.Pixels,
                    SizeMeasureType = SignTextOptions.SizeMeasureTypeEnum.Pixels,
                    Stretch = SignTextOptions.StretchEnum.None,
                    RotationAngle = 0,
                    HorizontalAlignment = SignTextOptions.HorizontalAlignmentEnum.None,
                    VerticalAlignment = SignTextOptions.VerticalAlignmentEnum.None,
                    Margin = new Padding {All = 5},
                    MarginMeasureType = SignTextOptions.MarginMeasureTypeEnum.Pixels,
                    Border = new BorderLine
                    {
                        Color = new Color {Web = "DarkOrange"},
                        Visible = true,
                        Style = BorderLine.StyleEnum.Dash,
                        Weight = 12
                    },
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

                // Sign settings
				var signSettings = new SignSettings
                {
					FileInfo = new FileInfo
                    {
						FilePath = "one-page.docx"
					},
					SaveOptions = new SaveOptions { OutputFilePath = "signedQRCode_one-page.docx", SaveFormat = "docx" },
					Options = new List<SignOptions> { options }
				};

				// Create request
				var request = new CreateSignaturesRequest(signSettings);

				// Call api method with request
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