using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockfrost.ResponseTypes.Error {
    
    public class BlockfrostError : System.Exception{
        public int status_code = -1;
        public string error = null, message = null;
    
        public BlockfrostError(BlockfrostError b) : base(b.message){
            this.status_code = b.status_code;
            this.error = b.error;
            this.message = b.message;
        } 

        public BlockfrostError(){}
    }

    public class BlockfrostErrorResponse{
        public int status_code = -1;
        public string error = null, message = null;
    
    }

}
