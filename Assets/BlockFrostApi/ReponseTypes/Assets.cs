using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blockfrost.ResponseTypes;
using Newtonsoft.Json.Linq;


namespace Blockfrost.ResponseTypes.Assets {

    public class Asset {
        public string asset, quantity;
    }

    public class SpecificAsset : Asset {
        public string policy, asset_name, fingerprint, initial_mint_tx_hash;
        public int mint_or_burn_count;
        public JToken onchain_metadata, metadata;
    }

    public class AssetHistory {
        public string tx_hash, amount, action;
    }

    public class AssetTransaction {
        public string tx_hash;
        public int tx_index, block_height;
        public long block_time;
    }

    public class AssetAddress {
        public string address, quantity;
    }



}



