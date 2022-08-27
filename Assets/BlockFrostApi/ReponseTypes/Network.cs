using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes.Network {
    public class Network {
        public Supply supply;
        public Stake stake;
        public class Supply {
            public string max, total, circulating, locked, treasury, reserves;
        }
        public class Stake {
            public string live, active;
        }
    }
}
