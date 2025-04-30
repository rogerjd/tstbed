namespace tstbed.Http;

public static class HttpClientTst
{
    //    [HttpGet("ClientReq")]
    public static void Test()
    {
        Utils.WriteTopic("HttpClient tester");

        //GetClientReq();
        btnHttpGetClicked();

    }

    //this works
    static void btnHttpGetClicked()
    {
        HttpClient client = new HttpClient();
        //            var response = client.GetAsync("https://www.google.com").Result; sync
        var response = client.GetAsync("https://www.google.com").Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
        //MessageBox.Query("Response", content, "Ok");

        //        passwordLabel.Text = response.StatusCode.ToString() + " " + ((int)response.StatusCode); //ok
        //passwordLabel.Text = $"{response.StatusCode.ToString()}  {((int)response.StatusCode)}"; //ok        
    }
    //this I could not get to work, must be wrong way, see above
    static async void GetClientReq()
    {
        // Initialize HttpClient
        using HttpClient hc = new HttpClient();

        // Set base address or headers if needed
        hc.BaseAddress = new Uri("https://www.nypost.com");

        try
        {

            Console.WriteLine("Make request");
            // Make a GET request
            HttpResponseMessage response = await hc.GetAsync("/2024/11/11/us-news/trump-border-czar-tom-homan-vows-sanctuary-city-crackdown/"); //.ConfigureAwait(false); //used with base address
            response.EnsureSuccessStatusCode(); // Throw if the status code is not successful

            // Read response content
            string content = await response.Content.ReadAsStringAsync(); //.ConfigureAwait(false);
            Console.WriteLine("Response: " + content);
        }
        catch (Exception e)
        {
            Console.WriteLine("Request error: " + e.Message);
        }
    }
}

/*
It sounds like Visual Studio Code (VSC) or .NET SDK is running into an issue either with the installation of .NET SDK version 8.0.10 or with resolving the correct version for your project. Here are a few steps you can take to troubleshoot this:

1. * *Confirm Installed SDKs**:
Open a terminal and type:
```bash
dotnet --list-sdks
```
This command lists all installed .NET SDK versions on your machine. Make sure that version `8.0.10` (or the version your project is targeting) appears in the list.

2. **Check Project Target Framework**:
Open your project file (e.g., `.csproj`) and check that the `<TargetFramework>` matches a version installed on your system. If your project targets `.NET 8.0`, the `<TargetFramework>` should be:
```xml
<TargetFramework> net8.0</TargetFramework>
```

3. **Update SDK in Global JSON (if applicable)**:
If your project has a `global.json` file in the root directory, it may specify a .NET SDK version to use. Open `global.json` and ensure that the `version` matches an SDK installed on your system. For example:
```json
{
"sdk": {
"version": "8.0.10"
}
}
```

4. * *Install the Missing SDK**:
If you confirm that `.NET 8.0.10` isn’t installed, download it directly from the [.NET downloads page] (https://dotnet.microsoft.com/download/dotnet). After installing, restart Visual Studio Code to recognize the new SDK.

5. * *Restart VSC and Check Extensions**:
Sometimes the .NET SDK extensions in VSC might cache SDK versions or have issues resolving them. Restart Visual Studio Code after any installation changes. Also, ensure that the **C# for Visual Studio Code** extension is updated to the latest version.

6. **Clear and Reinstall .NET SDK** (if issues persist):
If you keep seeing the error, it may help to uninstall and reinstall the .NET SDK. 

After these steps, try building the project again. Let me know if the error persists, or if there are more details about it!
*/

/*
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting HTTP request...");

        // Call your async HTTP method
        await RunHttpClient();

        Console.WriteLine("Finished.");
    }

    public static async Task RunHttpClient()
    {
        // Initialize HttpClient
        using var hc = new HttpClient { BaseAddress = new Uri("https://www.nypost.com") };

        try
        {
            Console.WriteLine("Sending request...");
            // Perform a GET request
            HttpResponseMessage response = await hc.GetAsync("/");
            
            // Check for success status code
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Request completed successfully!");

            // Read the content of the response
            string content = await response.Content.ReadAsStringAsync();

            // Print the response content to the console
            Console.WriteLine("Response content:");
            Console.WriteLine(content);
        }
        catch (HttpRequestException httpEx)
        {
            // Handle HTTP-related exceptions
            Console.WriteLine($"HTTP error occurred: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
*/