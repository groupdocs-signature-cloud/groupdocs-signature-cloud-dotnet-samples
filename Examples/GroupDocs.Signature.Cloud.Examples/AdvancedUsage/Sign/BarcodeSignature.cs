using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Sign document with Barcode and options
    internal class BarcodeSignature
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options.
                var options = new SignBarcodeOptions
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
					SaveOptions = new SaveOptions { OutputFilePath = "signedBarcode_one-page.docx", SaveFormat = "docx" },
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