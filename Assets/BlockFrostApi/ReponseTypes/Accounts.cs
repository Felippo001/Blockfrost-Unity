using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blockfrost.ResponseTypes;

namespace Blockfrost.ResponseTypes.Accounts {
    public class SpecificAccountAddress 
    {
        public string stake_address, controlled_amount, rewards_sum, withdrawals_sum, reserves_sum, treasury_sum, withdrawable_amount, pool_id;
        public bool active;
        public int active_epoch;
    }

    public class AccountRewardHistoryEntry {
        public int epoch;
        public string amount, pool_id, type;
    }

    public class AccountHistoryEntry {
        public string amount, pool_id;
        public int active_epoch;
    }

    public class AccountDelegationHistoryEntry {
        public int active_epoch;
        public string tx_hash, amount, pool_id;
    }

    public class AccountRegistrationHistoryEntry {
        public string tx_hash, action;
    }

    public class AccountWithdrawalHistoryEntry {
        public string tx_hash, amount;
    }

    public class AccountMIRHistoryEntry {
        public string tx_hash, amount;
    }

    public class AccountAssociatedAddress {
        public string address;
    }

    public class AssetAssociatedWithAddress : Amount {}

    public class DetailedInformationAboutAccountAssociatedAddresses {
        public string stake_address;
        public int tx_count;
        public Amount[] received_sum, sent_sum;
    }
}
