using System;
using BankLibrary;
using System.Collections.Generic;

namespace MenuDrivenConsoleBankApp
{
    class MenuDrivenApp
    {
        static void Main(string[] args)
        {
            BankRepository sbi = new BankRepository();
                System.Console.WriteLine("*******SBI MENU******");
                System.Console.WriteLine("1. Add A New Account");
                System.Console.WriteLine("2. Get All Accounts");
                System.Console.WriteLine("3. Get a Personal Account Information");
                System.Console.WriteLine("4. $ -> Account (Deposit)");
                System.Console.WriteLine("5. $ <- Account (Withdraw)");
                System.Console.WriteLine("6. Get Transactions From a Account\n");
                System.Console.WriteLine("7. Exit");
            //Menu Driven -> 
            while(true){
                System.Console.WriteLine();
                int choice = 0;
                try{
                    System.Console.Write("Enter Choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException){
                    System.Console.WriteLine("Enter an Integer!");
                }
                catch(Exception e){
                    System.Console.WriteLine(e.Message);
                }
                switch (choice)
                {  
                    case 1:
                        //Taking Input
                        System.Console.Write("Enter Account Number : ");
                        int Eacc_no_1 = 0;
                        string Ecust_name_1= "";
                        string Ecust_addr_1 ="";
                        decimal Eopen_val_1 = 0;
                        try
                        {
                            Eacc_no_1 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {      
                            System.Console.WriteLine("Account Number Must be an Integer!");
                            break;
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        try
                        {
                            System.Console.Write("Enter Customer Name : ");
                            Ecust_name_1 = Console.ReadLine();
                            System.Console.Write("Enter Customer Address : ");
                            Ecust_addr_1 = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        try
                        {
                            System.Console.Write("Enter Opening Amount : ");
                            Eopen_val_1 = Convert.ToDecimal(Console.ReadLine());    
                            if(Eopen_val_1 < 0)
                                throw new ValidationException("Opening Account Value Cant be Less Than 0!"); 
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        //Creating Account
                        sbi.NewAccount(new SBAccount(Eacc_no_1,Ecust_name_1,Ecust_addr_1,Eopen_val_1));
                        break;
                    case 2:
                        //Display All Accounts
                        Console.WriteLine();
                        List<SBAccount> accs_2 = sbi.GetAllAccounts();
                        // Printing
                        foreach (var ac in accs_2)
                        {
                            Console.WriteLine("{");
                            Console.WriteLine($"   ACCOUNT_NUMBER : {ac.AccountNumber},");
                            Console.WriteLine($"   CUSTOMER_NAME : {ac.CustomerName},");
                            Console.WriteLine($"   CUSTOMER_ADDRESS : {ac.CustomerAddress},");
                            Console.WriteLine($"   CURRENT_BALANCE : {ac.CurrentBalance}");
                            Console.WriteLine("}");
                        }
                        break;
                    case 3:
                        int Eacc_no_3 = 0;
                        try
                        {
                            System.Console.Write("Enter Account Number: ");
                            Eacc_no_3 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {      
                            System.Console.WriteLine("Account Number Must be an Integer!");
                            break;
                        }                        
                        SBAccount? Personalacc_3 = sbi.GetAccountDetails(Eacc_no_3);
                        
                        if(Personalacc_3 != null){
                            Console.WriteLine("{");
                            Console.WriteLine($"   ACCOUNT_NUMBER : {Personalacc_3.AccountNumber},");
                            Console.WriteLine($"   CUSTOMER_NAME : {Personalacc_3.CustomerName},");
                            Console.WriteLine($"   CUSTOMER_ADDRESS : {Personalacc_3.CustomerAddress},");
                            Console.WriteLine($"   CURRENT_BALANCE : {Personalacc_3.CurrentBalance}");
                            Console.WriteLine("}");
                        }
                        else{
                            System.Console.WriteLine("Please check the account number you entered!, Account Not Found!");
                        }
                        break;
                    case 4:
                        //Handle Exceptions
                        int Eacc_no_4 = 0;
                        int Eamt_4 = 0;
                        bool status_4 = false;
                        try
                        {
                            System.Console.WriteLine("Enter the Account Number for Deposit $: ");
                            Eacc_no_4 = Convert.ToInt32(Console.ReadLine());
                            System.Console.WriteLine("Enter Money to Be Deposited $: ");
                            Eamt_4 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("Account Number and Amount Should Be floating point!");
                            break;
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                        }
                        try{
                            status_4 = sbi.DepositAmount(Eacc_no_4, Eamt_4);
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        if(status_4){
                            System.Console.WriteLine("Deposited Successfully!");
                        }
                        else{
                            System.Console.WriteLine("Error Occured While Finding the Account or While the Transaction!");
                        }
                        break;
                    case 5:
                        //Handle Exceptions
                        int Eacc_no_5 = 0;
                        int Eamt_5 = 0;
                        bool status_5 = false;
                        try{
                            System.Console.WriteLine("Enter the Account Number for Withdraw $: ");
                            Eacc_no_5 = Convert.ToInt32(Console.ReadLine());
                            System.Console.WriteLine("Enter Money to Be Withdrawl $: ");
                            Eamt_5 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch(FormatException){
                            System.Console.WriteLine("Account Number should be a Number and Amount Should Be Floating Point!");
                            break;
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        try{
                            status_5 = sbi.WithdrawAmount(Eacc_no_5, Eamt_5);
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                            break;    
                        }
                        if(status_5){
                            System.Console.WriteLine("Withdraw Successfully!");
                            //DEV purpose only remove it on PRODUCTION!!!!!
                        }
                        else{
                            System.Console.WriteLine("Error Occured While Finding the Account or While the Transaction!");
                        }
                        break;
                    case 6:
                        //Handle Exceptions
                        int Eacc_no_6 = 0;
                        try{
                            System.Console.WriteLine("Enter the Account Number for Listing All Transactions $: ");
                            Eacc_no_6 = Convert.ToInt32(Console.ReadLine());    
                        }
                        catch(FormatException){
                            System.Console.WriteLine("Account Number Should be Number");
                            break;
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                            break;
                        }
                        List<SBTransaction> P_trans_6 = new List<SBTransaction>();
                        P_trans_6 = sbi.GetTransactions(Eacc_no_6);
                        if((Convert.ToBoolean(P_trans_6.Count))){
                           System.Console.WriteLine($"******** Transactions of {Eacc_no_6} ********"); 
                            foreach (var trnsc in P_trans_6)
                            {
                                Console.WriteLine("{");
                                Console.WriteLine($"   TRANSACTION_ID : {trnsc.TransactionId},");
                                Console.WriteLine($"   TRANSACTION_DATE : {trnsc.TransactionDate.ToShortDateString()}");
                                Console.WriteLine($"   TRANSACTION_TIME : {trnsc.TransactionDate.ToString("h:mm tt")}");
                                Console.WriteLine($"   ACCOUNT_NUMBER : {trnsc.AccountNumber},");
                                Console.WriteLine($"   AMOUNT : {trnsc.Amount},");
                                Console.WriteLine($"   TRANSACTION_TYPE : {trnsc.Ttype}");
                                Console.WriteLine("}");
                            }
                        }
                        else
                            System.Console.WriteLine("No Transactions found! or Try to Look for Different Account Number!");
                        break;
                    case 7:
                        return;
                    default:
                        System.Console.WriteLine("Enter valid option!");
                        break;
                }



            }
        
        }
    }
}
