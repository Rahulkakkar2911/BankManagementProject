using System;

namespace BankLibrary{
    class BankException:ApplicationException{
        public BankException(string msg):base(msg){
            //to which base?
        }
    }
}