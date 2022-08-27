# Blockfrost API Unity

Blockfrost SDK for Unity. Only Cardano endpoints available (no ipfs or milkomeda)

## Installation

Download and import the [latest release](https://github.com/Felippo001/Blockfrost-Unity/releases) .unitypackage

##### [Download Here](https://github.com/Felippo001/Blockfrost-Unity/releases)





## Example

```csharp
using Blockfrost;
using Blockfrost.ResponseTypes.Error;

public class Example : MonoBehaviour
{

    async void Start()
    {
        // Initialize api
        var api = new BlockfrostApi(
            "<api-key>",
            false 
            // mainnet = false
            // testnet = true
        );



        // Fetch asset
        var myAsset = await api.SpecificAsset(
            "d5e6bf0500378d4f0da4e8dde6becec7621cd8cbf5cbb9b87013d4cc537061636542756432303538"
        );
        // Get image link - ipfs:// 
        var metadataImage = myAsset.onchain_metadata["image"];
        print(metadataImage);




        // Catch errors 

        try
        {
            var addressUtxos = await api.AddressUtxos("<address>");
        }
        catch (BlockfrostError e)
        {
            print(e.status_code);
            print(e.message);
        }


        try
        {
            await api.SubmitTransaction("<tx>");
        }
        catch(BlockfrostError e){}
        
    }

    
}

```

## Endpoints

All endpoints can be seen on the official Blockfrost [open api reference](https://docs.blockfrost.io/#tag/Cardano-Accounts)

## License

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


## Author

[Backi#8950](https://twitter.com/Backi_Backi)