using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples
{
	// Sign document with Image and options
    internal class ImageSignature
	{
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options
                var options = new SignImageOptions
                {
                    SignatureType = SignatureTypeEnum.Image,
                    ImageFilePath = "signature.jpg",
                    Left = 100,
                    Top = 100,
                    Width = 200,
                    Height = 100,
                    LocationMeasureType = SignImageOptions.LocationMeasureTypeEnum.Pixels,
                    SizeMeasureType = SignImageOptions.SizeMeasureTypeEnum.Pixels,
                    RotationAngle = 0,
                    HorizontalAlignment = SignImageOptions.HorizontalAlignmentEnum.None,
                    VerticalAlignment = SignImageOptions.VerticalAlignmentEnum.None,
                    Margin = new Padding {All = 5},
                    MarginMeasureType = SignImageOptions.MarginMeasureTypeEnum.Pixels,
                    Page = 1,
                    AllPages = true,
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
					SaveOptions = new SaveOptions { OutputFilePath = "signedImage_one-page.docx", SaveFormat = "docx" },
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