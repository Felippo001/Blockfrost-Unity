using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Blockfrost.ResponseTypes.Scripts {

    public class Script {
        public string script_hash;
    }

    public class SpecificScript : Script {
        public string type;
        public int serialised_size;
    }

    public class ScriptJSON {
        public JToken json;
    }

    public class ScriptCBOR {
        public string cbor;
    }

    public class ScriptRedeemer {
        public string tx_hash, purpose, redeemer_data_hash, datum_hash, unit_mem, unit_steps, fee;
        public int tx_index;
    }

    public class DatumValueJSON {
        public JToken json_value;
    }

    public class DatumValueCBOR {
        public string cbor;
    }

}
