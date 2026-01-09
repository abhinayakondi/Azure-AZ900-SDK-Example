using Azure;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //string subscriptionId = "17be4470-448d-460b-97b3-4e0fd4fc1c10";
        string resourceGroupName = "my-sdk-rg";
        //AzureLocation location = AzureLocation.WestUS2;
        string location = "westus";

        // Authenticate with Azure
        var credential = new DefaultAzureCredential();

        // Initialize Azure ARM client
        var client = new ArmClient(credential);

        // Create and get access to the resource group
        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);

        Console.WriteLine($"Resource group created successfully!");
    }
}