using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes {
    // Subclasses

    
    public class Amount {
        public string unit, quantity;
    }
    public class Input : Output {
        //public string address, tx_hash, data_hash, inline_datum, reference_script_hash;
        //public int output_index;
        public bool collateral, reference;
        //public Amount[] amount;
    }

    public class Output {
        public string address, tx_hash, data_hash, inline_datum, reference_script_hash;
        public int output_index;
        public Amount[] amount;
    }

    public class Relay {
        public string ipv4, ipv6, dns, dns_srv;
        public int port;
    }
}
