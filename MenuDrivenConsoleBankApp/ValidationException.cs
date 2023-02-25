using System;

namespace BankLibrary{
    class ValidationException:ApplicationException{
        public ValidationException(string msg):base(msg){
            //to which base?
        }
    }
}