using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes.Ledger {
    public class BlockchainGenesis {
        public float active_slots_coefficient;
        public string max_lovelace_supply;
        public int update_quorum, slot_length, max_kes_evolutions, security_param;
        public long network_magic, epoch_length, system_start, slots_per_kes_period;
    }
}
