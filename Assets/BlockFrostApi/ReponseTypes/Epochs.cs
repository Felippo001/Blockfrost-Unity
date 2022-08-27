using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes.Epochs {
    public class Epoch {
        public int epoch, block_count, tx_count;
        public long start_time, end_time, first_block_time, last_block_time;
        public string output, fees, active_stake;
    }

    public class EpochProtocalParameters {
        public int epoch, min_fee_a, min_fee_b, max_block_size, max_tx_size, max_block_header_size, e_max, n_opt, protocol_major_ver, protocol_minor_ver; 
        public int? collateral_percent, max_collateral_inputs;
        public float a0, rho, tau, decentralisation_param;
        public float? price_mem, price_step;
        public string key_deposit, pool_deposit, extra_entropy, min_utxo, min_pool_cost, nonce, max_tx_ex_mem, max_tx_ex_steps, max_block_ex_mem, max_block_ex_steps, max_val_size, coins_per_utxo_size, coins_per_utxo_word; 
        public Dictionary<string, Dictionary<string, int>> cost_models;
    }

    public class StakeDistributionEntry : StakeDistributionEntryByPool {
        public string pool_id;
    }

    public class StakeDistributionEntryByPool {
        public string stake_address, amount;
    }

}


