using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes.Pools {


    public class AdditionalStakePoolInformation {
        public string pool_id, active_stake, live_stake;
    }

    public class RetiredPool {
        public string pool_id;
        public int epoch;
    }

    public class SpecificStakePool {
        public string pool_id, hex, vrf_key, live_stake, active_stake, declared_pledge, live_pledge, fixed_cost, reward_account;
        public string[] owners, registration, retirement;
        public int blocks_minted, blocks_epoch, live_delegators;
        public float live_size, live_saturation, active_size, margin_cost;
    }

    public class StakePoolHistoryEntry {
        public int epoch, blocks, delegators_count;
        public float active_size;
        public string active_stake, rewards, fees;
    }

    public class StakePoolMetadata {
        public string pool_id, hex, url, hash, ticker, name, description, homepage;
    }

    public class StakePoolDelegator {
        public string address, live_stake;
    }

    public class StakePoolUpdate {
        public string tx_hash, action;
        public int cert_index;
    }
}