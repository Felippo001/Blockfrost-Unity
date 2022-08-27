// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Blockfrost.ResponseTypes.Error;

// namespace Blockfrost.Examples {
//     public class TestingScript : MonoBehaviour
//     {
//         const string stakeAddress = "stake1uxldf85fzgu8m9rc75xcpzzs6melwq78x5gzdhxwzc9sh2g5t88q2";
        
//         const string poolId = "pool19f6guwy97mmnxg9dz65rxyj8hq07qxud886hamyu4fgfz7dj9gl";
        
//         // Start is called before the first frame update
//         async void Start()
//         {
//             var api = new BlockfrostApi(
//                 "mainnetDyVaXg1GvWd1yoXqUIHFgMGyOzOJIrjh"
//             );
            
//             var x = await api.ScriptJSON("ef76f6f0b3558ea0aaad6af5c9a5f3e5bf20b393314de747662e8ce9");
//             print(x.json["type"]);
//         }

        

//         public async void TestAccount(BlockfrostApi api){
            
//             await api.SpecificAccountAddress(stakeAddress);

//             await api.AccountRewardHistory(stakeAddress);

//             await api.AccountHistory(stakeAddress);

//             await api.AccountDelegationHistory(stakeAddress);

//             await api.AccountRegistrationHistory(stakeAddress);

//             await api.AccountWithdrawalHistory(stakeAddress);

//             await api.AccountMIRHistory(stakeAddress);

//             await api.AccountAssociatedAddresses(stakeAddress);

//             await api.AssetsAssociatedWithAddress(stakeAddress);

//             await api.DetailedInformationAboutAccountAssociatedAddresses(stakeAddress);
            
//         }

//         public async void TestAddresses(BlockfrostApi api){

//             await api.SpecificAddress(address);

//             await api.ExtendedInformationOfSpecificAddress(address);

//             await api.AddressDetails(address);

//             await api.AddressUtxos(address);

//             await api.AddressUtxoOfGivenAssets(address, asset);

//             await api.AddressTransactions(address);

            
//         }

//         public async void TestAssets(BlockfrostApi api){

//             await api.SpecificAddress(address);

//             await api.ExtendedInformationOfSpecificAddress(address);

//             await api.AddressDetails(address);

//             await api.AddressUtxos(address);

//             await api.AddressUtxoOfGivenAssets(address, asset);

//             await api.AddressTransactions(address);

            
//         }
//     }

    
// }
