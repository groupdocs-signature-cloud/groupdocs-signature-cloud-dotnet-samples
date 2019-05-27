using System;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
	class RunExamples
	{
		static void Main(string[] args)
		{
			//// ***********************************************************
			////          GroupDocs.Signature Cloud API Examples
			//// ***********************************************************

			//TODO: Get your AppSID and AppKey at https://dashboard.groupdocs.cloud (free registration is required).
			Common.MyAppSid = "XXXXX-XXXXX-XXXXX-XXXXX";
			Common.MyAppKey = "XXXXXXXXXX";
			Common.MyStorage = "XXXXX";

			//// Uploading sample test files from local to storage under folder 'Signaturedocs'
			//Common.UploadSampleTestFiles();

			//// ***********************************************************
			///// ***** WORKING WITH STORAGE *****
			//// ***********************************************************

			//// Is Storage Exist
			//Storage_Exist.Run();

			//// Get Get Disc Usage
			//Get_Disc_Usage.Run();

			//// Get File Versions
			//Get_File_Versions.Run();

			//// Is Object Exists
			//Object_Exists.Run();


			//// ***********************************************************
			//// ***** WORKING WITH FOLDER *****
			//// ***********************************************************

			//// Create Folder
			//Create_Folder.Run();

			//// Copy Folder
			//Copy_Folder.Run();

			//// Move Folder
			//Move_Folder.Run();

			//// Delete Folder
			//Delete_Folder.Run();

			//// Get Files List
			//Get_Files_List.Run();


			//// ***********************************************************
			//// ***** WORKING WITH FILES *****
			//// ***********************************************************

			//// Upload File
			//Upload_File.Run();

			//// Copy File
			//Copy_File.Run();

			//// Move File
			//Move_File.Run();

			//// Delete File
			//Delete_File.Run();

			//// Download_File
			//Download_File.Run();


			//// ***********************************************************
			//// ***** WORKING WITH SUPPORTED FORMATS *****
			//// ***********************************************************

			// Get All Supported Formats
			Get_All_Supported_Formats.Run();


			//// ***********************************************************
			//// ***** WORKING WITH SUPPORTED BARCODES *****
			//// ***********************************************************

			//// Get All Supported Barcodes
			//Get_All_Supported_Barcodes.Run();


			//// ***********************************************************
			//// ***** WORKING WITH SUPPORTED QRCODES *****
			//// ***********************************************************

			//// Get All Supported QRCodes
			//Get_All_Supported_QRCodes.Run();


			//// ***********************************************************
			/////// ***** WORKING WITH DOCUMENT INFORMATION *****
			//// ***********************************************************

			//// Get document information from File
			//DocumentInfo_File.Run();

			//// ***********************************************************
			//// ***** WORKING WITH SIGNING DOCUMENTS *****
			//// ***********************************************************

			//// Sign document with text and options
			//Text_Signature.Run();

			//// Sign document with barcode and options
			//Barcode_Signature.Run();

			//// Sign document with qrcode and options
			//QRCode_Signature.Run();

			//// Sign document with image and options
			//Image_Signature.Run();

			//// Sign document with Digital and options
			//Digital_Signature.Run();

			//// Sign document with a Stamp and options
			//Stamp_Signature.Run();

			//// Sign document with multiple/collection of signatures and options
			//Multiple_Collection_Signature.Run();


			//// ***********************************************************
			//// ***** WORKING WITH VEIFY DOCUMENT SIGNATURES *****
			//// ***********************************************************

			//// Verify document with text signature and options
			//Verify_Text_Signature.Run();

			//// Verify document with qrcode signature and options
			//Verify_QRCode_Signature.Run();

			//// Verify document with barcode signature and options
			//Verify_Barcode_Signature.Run();

			//// Verify document with Digital signature and options
			//Verify_Digital_Signature.Run();

			//// Verify document with multiple/ collection of signatures and options
			//Verify_Multiple_Collection_Signature.Run();


			//// ***********************************************************
			//// ***** WORKING WITH SEARCH SIGNATURES *****
			//// ***********************************************************

			//// Search qrcode signature with options
			//Search_QRCode_Signature.Run();

			//// Search barcode signature with options
			//Search_Barcode_Signature.Run();

			//// Search digital signature with options
			//Search_Digital_Signature.Run();

			//// Search multiple/ collection of signatures with options
			//Search_Multiple_Collection_Signature.Run();

		}
	}
}