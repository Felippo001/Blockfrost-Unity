using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Blockfrost.ResponseTypes.Metadata {
    public class TransactionMetadataLabel {
        public string label, cip10, count;
    }

    public class TransactionMetadataJSON {
        public string tx_hash;
        public JToken json_metadata;
    }

    public class TransactionMetadataCBOR {
        public string tx_hash, metadata;
    }
}
