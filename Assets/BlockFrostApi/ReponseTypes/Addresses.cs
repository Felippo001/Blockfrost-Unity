using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Blockfrost.ResponseTypes;

namespace Blockfrost.ResponseTypes.Addresses {

    public class SpecificAddress{
        public string address, stake_address, type;
        public bool script;
        public Amount[] amount;
    }

    public class ExtendedInformationOfSpecificAddress : SpecificAddress {
        public class ExtendedAmount : Amount {
            public int? decimals;
            public bool has_nft_onchain_metadata;
        }

        public new ExtendedAmount[] amount;
    }

    public class AddressDetails {
        public string address;
        public int tx_count;
        public Amount[] received_sum, sent_sum;
    }

    public class AddressUtxo {
        public string tx_hash, block, data_hash, inline_datum, reference_script_hash;
        public int output_index;
        public Amount[] amount;
    }


    public class AddressTransaction {
        public string tx_hash;
        public int tx_index, block_height;
        public long block_time;
    }
}
