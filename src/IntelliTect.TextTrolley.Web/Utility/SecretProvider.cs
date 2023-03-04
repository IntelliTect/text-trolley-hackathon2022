using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace IntelliTect.TextTrolley.Web.Utility;

public class SecretProvider {


    SecretClient _Client;

    public SecretProvider() {

        var keyVaultName = "text-trolley-keyvault";
        
        var kvUri = "https://" + keyVaultName + ".vault.azure.net";

        _Client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

    }

    public async Task<string> GetSecret(string secretName)
    {
        var secret = await _Client.GetSecretAsync(secretName);

        return secret.Value.Value;
    }


}