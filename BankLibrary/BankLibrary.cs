using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public enum TransactionType
    {
        Withdraw,
        Deposit
    }
    public class SBAccount 
    {

        public static List<SBAccount> accounts = new List<SBAccount>();

        public int AccountNumber{get;set;}
        public string CustomerName{get;set;}
        public string CustomerAddress{get;set;}
        public decimal CurrentBalance{get;set;}

        public SBAccount(int acc_no, string c_name, string c_address, decimal init_acc_val = 0){
        
            //Handle Exceptions
            AccountNumber = acc_no;
            CustomerName = c_name;
            CustomerAddress = c_address;
            CurrentBalance = init_acc_val;
        }


    }
    public class SBTransaction 
    {
        public static List<SBTransaction> Transactions = new List<SBTransaction>();
        public static int GetTransactionId = 0;
        public int TransactionId;
        public DateTime TransactionDate{get;set;}
        public int AccountNumber{get;set;}
        public decimal Amount{get;set;}
        public TransactionType Ttype{get;set;}
        public SBTransaction(int acc_no, decimal amnt, string type_in_string){

            //Current Date and Time:
            TransactionDate = DateTime.Now;
            //Initial Setting
            Amount = amnt;
            //Trancaction Type:
            type_in_string = type_in_string.ToLower();
            if(type_in_string == "withdraw"){
                Ttype = TransactionType.Withdraw;
            }
            else{
                Ttype = TransactionType.Deposit;
            }
            
            //To Which Account It Belongs -> 
            AccountNumber = acc_no;
            //getting the transaction ID from variable (intialised with 0);
            TransactionId = GetTransactionId;
            //getting the next transaction ID;
            GetNextID();
        }
        private void GetNextID(){
            ++GetTransactionId;
        }

    }



}
