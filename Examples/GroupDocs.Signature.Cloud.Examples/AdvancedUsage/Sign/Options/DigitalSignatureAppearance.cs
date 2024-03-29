using System;
using System.Collections.Generic;
using GroupDocs.Signature.Cloud.Sdk.Api;
using GroupDocs.Signature.Cloud.Sdk.Model;
using GroupDocs.Signature.Cloud.Sdk.Model.Requests;
using static GroupDocs.Signature.Cloud.Sdk.Model.OptionsBase;

namespace GroupDocs.Signature.Cloud.Examples.Options
{
	// Sign document with Digital and options
    internal class DigitalSignatureAppearance
    {
		public static void Run()
		{
			var apiInstance = new SignApi(Constants.GetConfig());

			try
			{
				// Sign options
                var options = new SignDigitalOptions
                {
                    SignatureType = SignatureTypeEnum.Digital,
                    ImageFilePath = "signature.jpg",
                    CertificateFilePath = "temp.pfx",
                    Password = "1234567890",
                    Page = 1,
                    PagesSetup = new PagesSetup
                    {
                        EvenPages = false,
                        FirstPage = true,
                        LastPage = false,
                        OddPages = false,
                        PageNumbers = new List<int?> {1}
                    },
                    Appearance = new PdfDigitalSignatureAppearance()
                    {
                        AppearanceType = SignatureAppearance.AppearanceTypeEnum.PdfTextSticker,
                        Background = new Color { Web = "Green" },
                        ContactInfoLabel = "info@groupdocs.cloud"
                    }
                };

                // Sign settings.
				var signSettings = new SignSettings
                {
					FileInfo = new Sdk.Model.FileInfo
                    {
						FilePath = "sample2.pdf"
					},
					SaveOptions = new SaveOptions { OutputFilePath = "signedDigital_appearance_sample2.pdf", SaveFormat = "pdf" },
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