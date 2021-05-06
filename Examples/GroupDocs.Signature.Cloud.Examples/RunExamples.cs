using System;

namespace GroupDocs.Signature.Cloud.Examples
{
	public class RunExamples
	{
		public static void Main(string[] args)
		{
            //// ***********************************************************
            ////          GroupDocs.Signature Cloud API Examples
            //// ***********************************************************

            //TODO: Get your ClientId and ClientSecret at https://dashboard.groupdocs.cloud (free registration is required).
            Constants.MyClientId = "XXXX-XXXX-XXXX-XXXX";
            Constants.MyClientSecret = "XXXXXXXXXXXXXXXX";
            Constants.MyStorage = "First Storage";

            try
            {
                // Uploading sample test files from local disk to cloud storage
                Constants.UploadSampleTestFiles();

                #region Basic usage
                GetDocumentInfo.Run();
                GetSupportedBarcodeTypes.Run();
                GetSupportedFormats.Run();
                GetSupportedQrCodeTypes.Run();
                GetDocumentPreview.Run();
                #endregion

                #region AdvancedUsage
                BarcodeSignature.Run();
                CollectionSignature.Run();
                DigitalSignature.Run();
                ImageSignature.Run();
                QrCodeSignature.Run();
                StampSignature.Run();
                TextSignature.Run();

                SearchBarcode.Run();
                SearchCollection.Run();
                SearchDigital.Run();
                SearchQrCode.Run();

                VerifyBarcode.Run();
                VerifyCollection.Run();
                VerifyDigital.Run();
                VerifyQrCode.Run();
                VerifyText.Run();

                UpdateBarcode.Run();
                UpdateQrCode.Run();

                DeleteBarcode.Run();
                DeleteQrCode.Run();

                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
	}
}