using System;
using System.Collections.Generic;

namespace BankLibrary{
    public interface IBankRepository{
        public void NewAccount(SBAccount acc);
        public List<SBAccount> GetAllAccounts();
        public SBAccount GetAccountDetails(int acc_no);
        public bool DepositAmount(int acc_no, decimal amt);
        public bool WithdrawAmount(int acc_no, decimal amt);
        public List<SBTransaction> GetTransactions(int acc_no);

    }
}