﻿using System;
using GroupDocs.Signature.Cloud.Sdk.Api;

namespace GroupDocs.Signature.Cloud.Examples.CSharp
{
    /// <summary>
    /// This example demonstrates how to get metered license consumption information
    /// </summary>
    public class GetLicenseConsumption
    {
        public static void Run()
        {
            var apiInstance = new LicenseApi(Constants.GetConfig());

            try
            {
                var response = apiInstance.GetConsumptionCredit();

                Console.WriteLine($"Credits: {response.Credit}");
                Console.WriteLine($"Quantity: {response.Quantity}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling LicenseApi: " + e.Message);
            }
        }
    }
}