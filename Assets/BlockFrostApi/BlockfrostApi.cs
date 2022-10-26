using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

using System.Threading.Tasks;
using UnityEngine.Networking;

using Blockfrost.ResponseTypes;
using Blockfrost.ResponseTypes.Error;

using Blockfrost.ResponseTypes.Accounts;
using Blockfrost.ResponseTypes.Addresses;
using Blockfrost.ResponseTypes.Assets;
using Blockfrost.ResponseTypes.Blocks;
using Blockfrost.ResponseTypes.Epochs;
using Blockfrost.ResponseTypes.Ledger;
using Blockfrost.ResponseTypes.Metadata;
using Blockfrost.ResponseTypes.Network;
using Blockfrost.ResponseTypes.Pools;
using Blockfrost.ResponseTypes.Scripts;
using Blockfrost.ResponseTypes.Transactions;
using Blockfrost.ResponseTypes.Utilities;




namespace Blockfrost {
    public class BlockfrostApi
    {
        public string apiKey {get; private set;}
        private string _network;

        public BlockfrostApi(string apiKey, BlockfrostNetwork network = 0)
        {
            this.apiKey = apiKey;
            this._network = networkToUrl(network);
        }

        private string networkToUrl(BlockfrostNetwork n){
            switch(n){
                case BlockfrostNetwork.Testnet: return "https://cardano-testnet.blockfrost.io/api/v0";
                case BlockfrostNetwork.Preprod: return "https://cardano-preprod.blockfrost.io/api/v0";
                case BlockfrostNetwork.Preview: return "https://cardano-preview.blockfrost.io/api/v0";
                case BlockfrostNetwork.MilkomedaMainnet: return "https://milkomeda-mainnet.blockfrost.io/api/v0";
                case BlockfrostNetwork.MilkomedaTestnet: return "https://milkomeda-testnet.blockfrost.io/api/v0";
                default: return "https://cardano-mainnet.blockfrost.io/api/v0";
            }
        }

        /*

        ///<summary></summary>
        public async Task<> (){
            string response = await Get($"/");
            return JsonConvert.DeserializeObject<>(response);
        }

        */


        /*
        // // // // 

        Accounts

        // // // // 
        */
        
        ///<summary>Obtain information about a specific stake account.</summary>
        public async Task<SpecificAccountAddress> SpecificAccountAddress(string stakeAddress) => await Get<SpecificAccountAddress>($"/accounts/{stakeAddress}");

        ///<summary>Obtain information about the reward history of a specific account.</summary>
        public async Task<AccountRewardHistoryEntry[]> AccountRewardHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountRewardHistoryEntry[]>($"/accounts/{stakeAddress}/rewards?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the history of a specific account.</summary>
        public async Task<AccountHistoryEntry[]> AccountHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountHistoryEntry[]>($"/accounts/{stakeAddress}/history?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the delegation of a specific account.</summary>
        public async Task<AccountDelegationHistoryEntry[]> AccountDelegationHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountDelegationHistoryEntry[]>($"/accounts/{stakeAddress}/delegations?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the registrations and deregistrations of a specific account.</summary>
        public async Task<AccountRegistrationHistoryEntry[]> AccountRegistrationHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountRegistrationHistoryEntry[]>($"/accounts/{stakeAddress}/registrations?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the withdrawals of a specific account.</summary>
        public async Task<AccountWithdrawalHistoryEntry[]> AccountWithdrawalHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountWithdrawalHistoryEntry[]>($"/accounts/{stakeAddress}/withdrawals?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the MIRs of a specific account.</summary>
        public async Task<AccountMIRHistoryEntry[]> AccountMIRHistory(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountMIRHistoryEntry[]>($"/accounts/{stakeAddress}/mirs?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about the addresses of a specific account.</summary>
        public async Task<AccountAssociatedAddress[]> AccountAssociatedAddresses(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AccountAssociatedAddress[]>($"/accounts/{stakeAddress}/addresses?count={count}&page={page}&order={order}");

        ///<summary>Obtain information about assets associated with addresses of a specific account. Be careful, as an account could be part of a mangled address and does not necessarily mean the addresses are owned by user as the account.</summary>
        public async Task<AssetAssociatedWithAddress[]> AssetsAssociatedWithAddress(string stakeAddress, int count = 100, int page = 1, string order = "asc") => await Get<AssetAssociatedWithAddress[]>($"/accounts/{stakeAddress}/addresses/assets?count={count}&page={page}&order={order}");

        ///<summary>Obtain summed details about all addresses associated with a given account. Be careful, as an account could be part of a mangled address and does not necessarily mean the addresses are owned by user as the account.</summary>
        public async Task<DetailedInformationAboutAccountAssociatedAddresses> DetailedInformationAboutAccountAssociatedAddresses(string stakeAddress) => await Get<DetailedInformationAboutAccountAssociatedAddresses>($"/accounts/{stakeAddress}/addresses/total");


        /*
        // // // // 

        Address

        // // // // 
        */


        ///<summary>Obtain information about a specific address.</summary>
        public async Task<SpecificAddress> SpecificAddress(string address) => await Get<SpecificAddress>($"/addresses/{address}");

        ///<summary>Obtain extended information about a specific address.</summary>
        public async Task<ExtendedInformationOfSpecificAddress> ExtendedInformationOfSpecificAddress(string address) => await Get<ExtendedInformationOfSpecificAddress>($"/addresses/{address}/extended");

        ///<summary>Obtain details about an address.</summary>
        public async Task<AddressDetails> AddressDetails(string address) => await Get<AddressDetails>($"/addresses/{address}/extended");

        ///<summary>UTXOs of the address.</summary>
        public async Task<AddressUtxo[]> AddressUtxos(string address, int count = 100, int page = 1, string order = "asc") => await Get<AddressUtxo[]>($"/addresses/{address}/utxos?count={count}&page={page}&order={order}");


        ///<summary>UTXOs of the address.</summary>
        public async Task<AddressUtxo[]> AddressUtxoOfGivenAssets(string address, string policy, string assetNameHex, int count = 100, int page = 1, string order = "asc") => await AddressUtxoOfGivenAssets(address, policy+assetNameHex, count, page, order);
        ///<summary>UTXOs of the address.</summary>
        public async Task<AddressUtxo[]> AddressUtxoOfGivenAssets(string address, string asset, int count = 100, int page = 1, string order = "asc") => await Get<AddressUtxo[]> ($"/addresses/{address}/utxos/{asset}?count={count}&page={page}&order={order}");

        ///<summary>UTXOs of the address.</summary>
        public async Task<AddressTransaction[]> AddressTransactions(string address, int count = 100, int page = 1, string order = "asc") => await Get<AddressTransaction[]>($"/addresses/{address}/transactions?count={count}&page={page}&order={order}");

    

        /*
        // // // // 

        Assets

        // // // // 
        */

        ///<summary>List of assets.</summary>
        public async Task<Asset[]> Assets(int count = 100, int page = 1, string order = "asc") => await Get<Asset[]> ($"/assets?count={count}&page={page}&order={order}");


        ///<summary>Information about a specific asset.</summary>
        public async Task<SpecificAsset> SpecificAsset(string policy, string assetNameHex) => await SpecificAsset(policy + assetNameHex);

        ///<summary>Information about a specific asset.</summary>
        public async Task<SpecificAsset> SpecificAsset(string asset) => await Get<SpecificAsset>($"/assets/{asset}");


        ///<summary>History of a specific asset</summary>
        public async Task<AssetHistory[]> AssetHistory(string asset, int count = 100, int page = 1, string order = "asc") => await Get<AssetHistory[]>($"/assets/{asset}/history?count={count}&page={page}&order={order}");


        ///<summary>List of a specific asset transactions</summary>
        public async Task<AssetTransaction[]> AssetTransactions(string asset, int count = 100, int page = 1, string order = "asc") => await Get<AssetTransaction[]>($"/assets/{asset}/transactions?count={count}&page={page}&order={order}");


        ///<summary>List of a addresses containing a specific asset</summary>
        public async Task<AssetAddress[]> AssetAddresses(string asset, int count = 100, int page = 1, string order = "asc") => await Get<AssetAddress[]>($"/assets/{asset}/addresses?count={count}&page={page}&order={order}");


        ///<summary>List of asset minted under a specific policy</summary>
        public async Task<Asset[]> AssetOfSpecificPolicy(string policy, int count = 100, int page = 1, string order = "asc") => await Get<Asset[]>($"/assets/policy/{policy}?count={count}&page={page}&order={order}");



        /*
        // // // // 

        Blocks

        // // // // 
        */


        ///<summary>Return the latest block available to the backends, also known as the tip of the blockchain.</summary>
        public async Task<Block> LatestBlock() => await Get<Block>($"/blocks/latest");

        ///<summary>Return the transactions within the latest block.</summary>
        public async Task<string[]> LatestBlockTransactions(int count = 100, int page = 1, string order = "asc") => await Get<string[]>($"/blocks/latest/txs?count={count}&page={page}&order={order}");

        ///<summary>Return the content of a requested block.</summary>
        public async Task<Block> SpecificBlock(int block) => await Get<Block>($"/blocks/{block}");

        ///<summary>Return the list of blocks following a specific block.</summary>
        public async Task<Block[]> ListOfNextBlocks(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<Block[]>($"/epochs/{epoch}/next?count={count}&page={page}&order={order}");

        ///<summary>Return the list of blocks preceding a specific block.</summary>
        public async Task<Block[]> ListOfPreviousBlocks(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<Block[]>($"/epochs/{epoch}/previous?count={count}&page={page}&order={order}");

        ///<summary>Return the content of a requested block for a specific slot.</summary>
        public async Task<Block> SpecificBlockInSlot(long slot) => await Get<Block>($"/blocks/slot/{slot}");

        ///<summary>Return the content of a requested block for a specific slot in an epoch.</summary>
        public async Task<Block> SpecificBlockInSlotInEpoch(int epoch, long slot) => await Get<Block>($"/blocks/epoch/{epoch}/slot/{slot}");

        ///<summary>Return the transactions within the block.</summary>
        public async Task<string[]> BlockTransactions(int block) => await Get<string[]>($"/blocks/{block}/txs");

        ///<summary>Return list of addresses affected in the specified block with additional information, sorted by the bech32 address, ascending.</summary>
        public async Task<AddressAffectedBySpecificBlock[]> AddressesAffectedBySpecificBlock(int block) => await Get<AddressAffectedBySpecificBlock[]>($"/blocks/{block}/addresses");


        /*
        // // // // 

        Epochs

        // // // // 
        */
        
        ///<summary>Return the information about the latest, therefore current, epoch.</summary>
        public async Task<Epoch> LatestEpoch() => await Get<Epoch>($"/epochs/latest");

        ///<summary>Return the transactions within the latest block.</summary>
        public async Task<EpochProtocalParameters> LatestEpochProtocolParameters() => await Get<EpochProtocalParameters>($"/epochs/latest/parameters");

        ///<summary>Return the content of a requested block.</summary>
        public async Task<Epoch> SpecificEpoch(int epoch) => await Get<Epoch>($"/epochs/{epoch}");
        
        ///<summary>Return the list of epochs following a specific epoch.</summary>
        public async Task<Epoch[]> ListOfNextEpochs(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<Epoch[]>($"/epochs/{epoch}/next?count={count}&page={page}&order={order}");
        
        ///<summary>Return the list of epochs preceding a specific epoch.</summary>
        public async Task<Epoch[]> ListOfPreviousEpochs(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<Epoch[]>($"/epochs/{epoch}/previous?count={count}&page={page}&order={order}");
        
        ///<summary>Return the active stake distribution for the specified epoch.</summary>
        public async Task<StakeDistributionEntry[]> StakeDistribution(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<StakeDistributionEntry[]>($"/epochs/{epoch}/stakes?count={count}&page={page}&order={order}");
        
        ///<summary>Return the active stake distribution for the epoch specified by stake pool.</summary>
        public async Task<StakeDistributionEntryByPool[]> StakeDistributionByPool(int epoch, string poolId, int count = 100, int page = 1, string order = "asc") => await Get<StakeDistributionEntryByPool[]>($"/epochs/{epoch}/stakes/{poolId}?count={count}&page={page}&order={order}");
        
        ///<summary>Return the blocks minted for the epoch specified.</summary>
        public async Task<string[]> BlockDistribution(int epoch, int count = 100, int page = 1, string order = "asc") => await Get<string[]>($"/epochs/{epoch}/blocks?count={count}&page={page}&order={order}");
        
        ///<summary>Return the block minted for the epoch specified by stake pool.</summary>
        public async Task<string[]> BlockDistributionByPool(int epoch, string poolId, int count = 100, int page = 1, string order = "asc") => await Get<string[]>($"/epochs/{epoch}/blocks/{poolId}?count={count}&page={page}&order={order}");
        
        ///<summary>Return the protocol parameters for the epoch specified.</summary>
        public async Task<EpochProtocalParameters> ProtocolParameters(int epoch) => await Get<EpochProtocalParameters>($"/epochs/{epoch}/parameters");
        


        /*
        // // // // 

        Ledger

        // // // // 
        */

        ///<summary>Return the information about blockchain genesis.</summary>
        public async Task<BlockchainGenesis> BlockchainGenesis() => await Get<BlockchainGenesis>($"/genesis");



        /*
        // // // // 

        Metadata

        // // // // 
        */

        ///<summary>List of all used transaction metadata labels.</summary>
        public async Task<TransactionMetadataLabel[]> TransactionMetadataLabels(int count = 100, int page = 1, string order = "asc") => await Get<TransactionMetadataLabel[]>($"/metadata/txs/labels?count={count}&page={page}&order={order}");

        ///<summary>Transaction metadata per label.</summary>
        public async Task<TransactionMetadataJSON[]> TransactionMetadataJSON(string label, int count = 100, int page = 1, string order = "asc"){
            var response = await Get($"/metadata/txs/labels/{label}?count={count}&page={page}&order={order}");
            var j = JArray.Parse(response);
            var list = new List<TransactionMetadataJSON>();
            foreach(var entry in j){
                list.Add(
                    new TransactionMetadataJSON() {
                        tx_hash = entry["tx_hash"].ToString(),
                        json_metadata = entry["json_metadata"]
                    }
                );
            }
            return list.ToArray();
        }

        ///<summary>Transaction metadata per label.</summary>
        public async Task<TransactionMetadataCBOR[]> TransactionMetadataLabels(string label, int count = 100, int page = 1, string order = "asc") => await Get<TransactionMetadataCBOR[]>($"/metadata/txs/labels/{label}/cbor?count={count}&page={page}&order={order}");

        


        /*
        // // // // 

        Network

        // // // // 
        */

        ///<summary>Return detailed network information.</summary>
        public async Task<Blockfrost.ResponseTypes.Network.Network> Network() => await Get<Blockfrost.ResponseTypes.Network.Network>("/network");

        /*
        // // // // 

        Pools

        // // // // 
        */

        ///<summary>List of registered stake pools.</summary>
        public async Task<string[]> StakePoolsList(int count = 100, int page = 1, string order = "asc") => await Get<string[]>($"/pools?count={count}&page={page}&order={order}");

        ///<summary>List of registered stake pools with additional information.</summary>
        public async Task<AdditionalStakePoolInformation[]> StakePoolsListAdditionalInformation(int count = 100, int page = 1, string order = "asc") => await Get<AdditionalStakePoolInformation[]>($"/pools/extended?count={count}&page={page}&order={order}");

        ///<summary>List of already retired pools.</summary>
        public async Task<RetiredPool[]> StakePoolsListRetired(int count = 100, int page = 1, string order = "asc") => await Get<RetiredPool[]>($"/pools/retired?count={count}&page={page}&order={order}");

        ///<summary>List of stake pools retiring in the upcoming epochs</summary>
        public async Task<RetiredPool[]> StakePoolsListRetiring(int count = 100, int page = 1, string order = "asc") => await Get<RetiredPool[]>($"/pools/retiring?count={count}&page={page}&order={order}");

        ///<summary>Pool information.</summary>
        public async Task<SpecificStakePool> SpecificStakePool(string poolId) => await Get<SpecificStakePool>($"/pools/{poolId}");

        ///<summary>History of stake pool parameters over epochs.</summary>
        public async Task<StakePoolHistoryEntry[]> StakePoolHistory(string poolId) => await Get<StakePoolHistoryEntry[]>($"/pools/{poolId}/history");

        ///<summary>Stake pool registration metadata.</summary>
        public async Task<StakePoolMetadata> StakePoolMetadata(string poolId) => await Get<StakePoolMetadata>($"/pools/{poolId}/metadata");

        ///<summary>Relays of a stake pool.</summary>
        public async Task<Relay[]> StakePoolRelays(string poolId) => await Get<Relay[]>($"/pools/{poolId}/relays");

        ///<summary>List of current stake pools delegators.</summary>
        public async Task<StakePoolDelegator[]> StakePoolDelegators(string poolId) => await Get<StakePoolDelegator[]>($"/pools/{poolId}/delegators");

        ///<summary>List of stake pools blocks.</summary>
        public async Task<string[]> StakePoolBlocks(string poolId) => await Get<string[]>($"/pools/{poolId}/blocks");

        ///<summary>List of certificate updates to the stake pool.</summary>
        public async Task<StakePoolUpdate[]> StakePoolUpdates(string poolId) => await Get<StakePoolUpdate[]>($"/pools/{poolId}/updates");



        /*
        // // // // 

        Scripts

        // // // // 
        */
        ///<summary></summary>


        ///<summary>List of scripts.</summary>
        public async Task<Script[]> Scripts(int count = 100, int page = 1, string order = "asc") => await Get<Script[]>($"/scripts?count={count}&page={page}&order={order}");

        ///<summary>Information about a specific script</summary>
        public async Task<SpecificScript> SpecificScript(string scriptHash) => await Get<SpecificScript>($"/scripts/{scriptHash}");

        ///<summary>JSON representation of a timelock script</summary>
        public async Task<ScriptJSON> ScriptJSON(string scriptHash) => await Get<ScriptJSON>($"/scripts/{scriptHash}/json");
        
        ///<summary>CBOR representation of a plutus script</summary>
        public async Task<ScriptJSON> ScriptCBOR(string scriptHash) => await Get<ScriptJSON>($"/scripts/{scriptHash}/cbor");
        
        ///<summary>List of redeemers of a specific script</summary>
        public async Task<ScriptRedeemer[]> ScriptRedeemers(string scriptHash, int count = 100, int page = 1, string order = "asc") => await Get<ScriptRedeemer[]>($"/scripts/{scriptHash}/redeemers?count={count}&page={page}&order={order}");

        ///<summary>Query JSON value of a datum by its hash</summary>
        public async Task<DatumValueJSON> DatumValueJSON(string datumHash) => await Get<DatumValueJSON>($"/scripts/datum/{datumHash}");

        ///<summary>Query JSON value of a datum by its hash</summary>
        public async Task<DatumValueCBOR> DatumValueCBOR(string datumHash) => await Get<DatumValueCBOR>($"/scripts/datum/{datumHash}/cbor");

        
        /*
        // // // // 

        Transactions

        // // // // 
        */

        ///<summary>Return content of the requested transaction.</summary>
        public async Task<SpecificTransaction> SpecificTransaction(string txHash) => await Get<SpecificTransaction>($"/txs/{txHash}");
        

        ///<summary>Return the inputs and UTXOs of the specific transaction.</summary>
        public async Task<TransactionUTXOs> TransationUTXOs(string txHash) => await Get<TransactionUTXOs>($"/txs/{txHash}/utxos");


        ///<summary>Obtain information about (de)registration of stake addresses within a transaction</summary>
        public async Task<TransactionStakeAddressesCertificate[]> TransactionStakeAddressesCertificates(string txHash) => await Get<TransactionStakeAddressesCertificate[]>($"/txs/{txHash}/stakes");


        ///<summary>Obtain information about delegation certificates of a specific transaction.</summary>
        public async Task<TransactionDelegationCertificate[]> TransactionDelegationCertificates(string txHash) => await Get<TransactionDelegationCertificate[]>($"/txs/{txHash}/delegations");


        ///<summary>Obtain information about withdrawals of a specific transaction.</summary>
        public async Task<TransactionWithdrawal[]> TransactionWithdrawals(string txHash) => await Get<TransactionWithdrawal[]>($"/txs/{txHash}/withdrawals");


        ///<summary>Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.</summary>
        public async Task<TransactionMIR[]> TransactionMIRs(string txHash) => await Get<TransactionMIR[]>($"/txs/{txHash}/mirs");
        

        ///<summary>Obtain information about stake pool registration and update certificates of a specific transaction.</summary>
        public async Task<TransactionStakePoolRegistrationAndUpdateCertificate[]> TransactionStakePoolRegistrationAndUpdateCertificates(string txHash){
            string response = await Get($"/txs/{txHash}/pool_updates");
            var j = JArray.Parse(response);
            var list = new List<TransactionStakePoolRegistrationAndUpdateCertificate>();
            foreach(var entry in j){
                list.Add(
                    new TransactionStakePoolRegistrationAndUpdateCertificate() {
                        active_epoch = entry["active_epoch"].Value<int>(),
                        pool_id = entry["pool_id"].Value<string>(),
                        cert_index = entry["cert_index"].Value<int>(),
                        vrf_key = entry["vrf_key"].Value<string>(),
                        pledge = entry["pledge"].Value<string>(),
                        fixed_cost = entry["fixed_cost"].Value<string>(),
                        reward_account = entry["reward_account"].Value<string>(),
                        margin_cost = entry["margin_cost"].Value<float>(),
                        owners = entry["owners"].Select(x => x.Value<string>()).ToArray(),
                        metadata = entry["metadata"],
                        relays = entry["relays"].Select(x => new Relay() {
                            dns = x["dns"].Value<string>(),
                            dns_srv = x["dns_srv"].Value<string>(),
                            ipv4 = x["ipv4"].Value<string>(),
                            ipv6 = x["ipv6"].Value<string>(),
                            port = x["port"].Value<int>()
                        }).ToArray()
                        
                    }
                );
            }
            return list.ToArray();
        }
        

        ///<summary>Obtain information about stake pool retirements within a specific transaction.</summary>
        public async Task<TransactionStakePoolRetirementCertificate[]> TransactionStakePoolRetirementCertificates(string txHash) => await Get<TransactionStakePoolRetirementCertificate[]>($"/txs/{txHash}/pool_retires");
        

        ///<summary>Obtain the transaction metadata.</summary>
        public async Task<TransactionMetadata[]> TransactionMetadata(string txHash){
            string response = await Get($"/txs/{txHash}/metadata");
            var j = JArray.Parse(response);
            var list = new List<TransactionMetadata>();
            foreach(var entry in j){
                list.Add(
                    new TransactionMetadata() {
                        label = entry["label"].ToString(),
                        json_metadata = entry["json_metadata"]
                    }
                );
            }
            
            return list.ToArray();
            
        }
        

        ///<summary>Obtain the transaction metadata in CBOR.</summary>
        public async Task<TransactionMetadataCBOR[]> TransactionMetadataCBOR(string txHash) => await Get<TransactionMetadataCBOR[]>($"/txs/{txHash}/metadata/cbor");


        ///<summary>Submit an already serialized transaction to the network.</summary>
        public async Task<string> SubmitTransaction(string tx) => await SubmitCbor("/tx/submit", tx);
        

        
        /*
        // // // // 

        Utilities

        // // // // 
        */


        ///<summary>Derive Shelley address from an xpub</summary>
        public async Task<AddressDeriveEntry[]> DeriveAddress(string xpub, int role, int index) => await Get<AddressDeriveEntry[]>($"/utils/addresses/xpub/{xpub}/{role}/{index}");

        ///<summary>Submit an already serialized transaction to evaluate how much execution units it requires.</summary>
        public async Task<JToken> SubmitTransactionExecutionUnitsEvaluation(string cbor) {
            return JToken.Parse(
                await SubmitCbor($"utils/txs/evaluate", cbor)
            );
        }

        /*
        // // // // 

        Private

        // // // // 
        */
        private string _url(string urlPath){
            return _network + urlPath;
        }
        private async Task<string> Get(string urlPath){
            string url = _url(urlPath);
            
            var www = UnityWebRequest.Get(url);
            www.SetRequestHeader("project_id", apiKey);
            Debug.Log(www.GetRequestHeader("project_id"));


            await www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.ConnectionError){
                ///Debug.LogError(www.error);
                throw new System.Exception(www.error);
            }

            string response = www.downloadHandler.text;

            try
            {
                var err = JsonConvert.DeserializeObject<BlockfrostErrorResponse>(response);
                
                if(err.status_code != -1)
                    throw new BlockfrostError(
                        new BlockfrostError(){
                            error = err.error,
                            status_code = err.status_code,
                            message = $"[{err.status_code}] " +err.message
                        }
                    );
                    
            }
            catch(BlockfrostError e){
                Debug.Log(response);
                throw e;
            }
            catch (System.Exception){}

            return response;
        }

        private async Task<T> Get<T>(string urlPath){
            var response = await Get(urlPath);

            return JsonConvert.DeserializeObject<T>(
                response
            );
        }

        private async Task<string> SubmitCbor(string urlPath, string cbor){
            string url = _url(urlPath);

            var www = UnityWebRequest.Post(url, "");
            www.SetRequestHeader("project_id", apiKey);
            www.SetRequestHeader("Content-Type", "application/cbor");
            www.uploadHandler = new UploadHandlerRaw(StringToByteArrayFastest(cbor));


            await www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.ConnectionError){
                ///Debug.LogError(www.error);
                throw new System.Exception(www.error);
            }

            byte[] StringToByteArrayFastest(string hex) {
                if (hex.Length % 2 == 1)
                    throw new System.Exception("The binary key cannot have an odd number of digits");

                byte[] arr = new byte[hex.Length >> 1];

                for (int i = 0; i < hex.Length >> 1; ++i)
                {
                    arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
                }

                return arr;
            }
            int GetHexVal(char hex) {
                int val = (int)hex;
                //For uppercase A-F letters:
                //return val - (val < 58 ? 48 : 55);
                //For lowercase a-f letters:
                //return val - (val < 58 ? 48 : 87);
                //Or the two combined, but a bit slower:
                return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
            }

            string response = www.downloadHandler.text;
            try
            {
                var err = JsonConvert.DeserializeObject<BlockfrostErrorResponse>(response);
                if(err.status_code != -1)
                    throw new BlockfrostError(
                        new BlockfrostError(){
                            error = err.error,
                            status_code = err.status_code,
                            message = $"[{err.status_code}] " +err.message
                        }
                    );
                    
            }
            catch(BlockfrostError e){
                throw e;
            }
            catch (System.Exception){}
            return response;
        }
    }

    public enum BlockfrostNetwork {
        Mainnet = 0,
        Testnet,
        Preprod,
        Preview,
        MilkomedaMainnet,
        MilkomedaTestnet
    }

}
