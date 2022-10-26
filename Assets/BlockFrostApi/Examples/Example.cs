using UnityEngine;
using Blockfrost.ResponseTypes.Error;
using Blockfrost;

namespace Blockfrost.Examples {
    public class Example : MonoBehaviour
    {

        async void Start()
        {
            var api = new BlockfrostApi(
                "<api-key>",
                BlockfrostNetwork.Mainnet 
                // BlockfrostNetwork.Preview 
                // BlockfrostNetwork.Preprod
                // ... 
            );

            var myAsset = await api.SpecificAsset(
                "d5e6bf0500378d4f0da4e8dde6becec7621cd8cbf5cbb9b87013d4cc537061636542756432303538"
            );
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

}
