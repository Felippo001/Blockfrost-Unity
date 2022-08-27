using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blockfrost.ResponseTypes;

namespace Blockfrost.ResponseTypes.Blocks {
    public class Block {
        public long time, height, slot;
        public int epoch, epoch_slot, size, tx_count, confirmations;
        public string hash, slot_leader, output, fees, block_vrf, op_cert, op_cert_counter, previous_block, next_block;
    }

    public class AddressAffectedBySpecificBlock {
        public string address;
        public TxHash[] transactions;
        public class TxHash {
            public string tx_hash;
        }
    }
}