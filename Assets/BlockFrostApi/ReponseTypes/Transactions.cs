using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Blockfrost.ResponseTypes;

namespace Blockfrost.ResponseTypes.Transactions {

    public class SpecificTransaction {
        public string hash, block;
        public long block_height, block_time, slot;
        public int index;
        public Amount[] output_amount;
        public string fees, deposit;
        public int size;
        public bool invalid_before;
        public string invalid_hereafter;
        public int  utxo_count, withdrawal_count, mir_cert_count, delegation_count, stake_cert_count, 
                    pool_update_count, pool_retire_count, asset_mint_or_burn_count, redeemer_count;
        public bool valid_contract;
    }

    public class TransactionUTXOs {
        public string hash;
        public Input[] inputs;
        public Output[] outputs;
    }

    public class TransactionStakeAddressesCertificate {
        public int cert_index;
        public string address;
        public bool registration;
    }

    public class TransactionDelegationCertificate {
        public int index, cert_index, active_epoch;
        public string address, pool_id;
    }
    
    public class TransactionWithdrawal {
        public string address, amount;
    }

    public class TransactionMIR {
        public string pot, address, amount;
        public int cert_index;
    }

    public class TransactionStakePoolRegistrationAndUpdateCertificate {
        public int cert_index, active_epoch;
        public string pool_id, vrf_key, pledge, fixed_cost, reward_account;
        public float margin_cost;
        public string[] owners;
        public JToken metadata;
        public Relay[] relays;
        
    }

    public class TransactionStakePoolRetirementCertificate {
        public int cert_index, retiring_epoch;
        public string pool_id;
    }

    

    public class TransactionMetadata {
        public string label;
        public JToken json_metadata;

    }

    // public class TransactionMetadataCBOR {
    //     public string label, cbor_metadata, metadata;
    // }

    public class TransactionRedeemer {
        public int tx_index;
        public string purpose, script_hash, redeemer_data_hash, datum_hash, unit_mem, unit_steps, fee;
    }









    


}
