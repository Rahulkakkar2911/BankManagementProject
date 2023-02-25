using System;
using System.Collections.Generic;

namespace BankLibrary{

    public class BankRepository : IBankRepository{
        public void NewAccount(SBAccount acc){
            SBAccount.accounts.Add(acc);
            System.Console.WriteLine("Account Added Successfully");
        }
        public List<SBAccount> GetAllAccounts(){
            return SBAccount.accounts;
        }
        public SBAccount GetAccountDetails(int acc_no){
            List<SBAccount> accounts_copy = GetAllAccounts();
            SBAccount temp = null;
            bool AccFound = false;
            foreach (var item in accounts_copy)
            {
                if(item.AccountNumber == acc_no){
                    AccFound = true;
                    temp = item;
                    break;
                }
            }
            if(AccFound){
                return temp;
            }
            else{
                return null;
            }

        }
        public bool DepositAmount(int acc_no, decimal amt){
            List<SBAccount> accounts_copy = GetAllAccounts();
            bool AccFound = false;
            bool DepositedStatus = false;
            foreach (var item in accounts_copy)
            {
                if(item.AccountNumber == acc_no){
                    AccFound = true;
                    //Handle Exception of -ve ammount;
                    if(amt < 0){
                        throw new BankException("Amount Can't Be Negative!");
                    }
                    item.CurrentBalance += amt;                     
                    DepositedStatus = true;
                    break;
                }
            }
            if(AccFound && DepositedStatus){
                SBTransaction.Transactions.Add(new SBTransaction(acc_no, amt, "deposit"));
            }
            return DepositedStatus;
        }
        public bool WithdrawAmount(int acc_no, decimal amt){
            List<SBAccount> accounts_copy = GetAllAccounts();
            bool AccFound = false;
            bool WithdrawStatus = false;
            foreach (var item in accounts_copy)
            {
                if(item.AccountNumber == acc_no){
                    AccFound = true;
                    //Handle Exception of -ve ammount;
                    if(amt < 0){
                        throw new BankException("Amount Can't Be Negative!");
                    }
                    if(item.CurrentBalance < amt){
                        throw new BankException("Insufficient Balance!");
                    }
                    item.CurrentBalance -= amt;                     
                    WithdrawStatus = true;
                    break;
                }
            }
            if(AccFound && WithdrawStatus){
                SBTransaction.Transactions.Add(new SBTransaction(acc_no, amt, "withdraw"));
            }
            return WithdrawStatus;
        }
        public List<SBTransaction> GetTransactions(int acc_no){
            List<SBTransaction> trans_of_a_Person = new List<SBTransaction>();
            List<SBTransaction> transactions_copy = SBTransaction.Transactions;
    
            foreach (var item in transactions_copy)
            {
                if(item.AccountNumber == acc_no){
                    trans_of_a_Person.Add(item);
                }
            }
            return trans_of_a_Person;
        }
    }
}