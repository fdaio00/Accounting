using System;
using System.Data;
using System.Threading.Tasks;

public class clsAccount
{
    enum enMode { AddNew = 0, Update = 1 };
    private enMode _Mode;

    public int AccountID { get; set; }
    public int AccountParentNo { get; set; }
    public string AccountNameAr { get; set; }
    public string AccountNameEn { get; set; }
    public int AccountType { get; set; }
    public int AccountReport { get; set; }
    public int AccountLevel { get; set; }
    public decimal AccountDebit { get; set; }
    public decimal AccountCredit { get; set; }
    public decimal AccountBalance { get; set; }

    public clsAccount()
    {
        this.AccountID = -1;
        this.AccountParentNo = 0;
        this.AccountNameAr = "";
        this.AccountNameEn = null;
        this.AccountType = 0;
        this.AccountReport = 0;
        this.AccountLevel = 0;
        this.AccountDebit = 0;
        this.AccountCredit = 0;
        this.AccountBalance = 0;
        _Mode = enMode.AddNew;
    }

    public clsAccount(
        int accountID,
        int accountParentNo,
        string accountNameAr,
        string accountNameEn,
        int accountType,
        int accountReport,
        int accountLevel,
        decimal accountDebit,
        decimal accountCredit,
        decimal accountBalance)
    {
        this.AccountID = accountID;
        this.AccountParentNo = accountParentNo;
        this.AccountNameAr = accountNameAr;
        this.AccountNameEn = accountNameEn;
        this.AccountType = accountType;
        this.AccountReport = accountReport;
        this.AccountLevel = accountLevel;
        this.AccountDebit = accountDebit;
        this.AccountCredit = accountCredit;
        this.AccountBalance = accountBalance;
        _Mode = enMode.Update;
    }

    private async Task<bool> _AddNewAccountAsync()
    {
        this.AccountID = await clsAccountData.AddNewAccountAsync(
            this.AccountParentNo,
            this.AccountNameAr,
            this.AccountNameEn,
            this.AccountType,
            this.AccountReport,
            this.AccountLevel,
            this.AccountDebit,
            this.AccountCredit,
            this.AccountBalance);
        return (this.AccountID > 0);
    }

    private async Task<bool> _UpdateAccountAsync()
    {
        return await clsAccountData.UpdateAccountAsync(
            this.AccountID,
            this.AccountParentNo,
            this.AccountNameAr,
            this.AccountNameEn,
            this.AccountType,
            this.AccountReport,
            this.AccountLevel,
            this.AccountDebit,
            this.AccountCredit,
            this.AccountBalance);
    }

    public async Task<bool> SaveAsync()
    {
        switch (_Mode)
        {
            case enMode.Update:
                return await _UpdateAccountAsync();
            case enMode.AddNew:
                if (await _AddNewAccountAsync())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            default:
                return false;
        }
    }

    public async Task<bool> DeleteAsync()
    {
        return await clsAccountData.DeleteAccountAsync(this.AccountID);
    }

    public static async Task<DataTable> GetAllAccountsAsync()
    {
        return await clsAccountData.GetAllAccountsAsync();
    }

    public static clsAccount GetAccountByID(int AccountID)
    {
        int AccountParentNo = 0;
        string AccountNameAr = null;
        string AccountNameEn = null;
        int AccountType = 0;
        int AccountReport = 0;
        int AccountLevel = 0;
        decimal AccountDebit = 0;
        decimal AccountCredit = 0;
        decimal AccountBalance = 0;

        bool isAccountFound = clsAccountData.FindAccountByID(
            AccountID,
            ref AccountParentNo,
            ref AccountNameAr,
            ref AccountNameEn,
            ref AccountType,
            ref AccountReport,
            ref AccountLevel,
            ref AccountDebit,
            ref AccountCredit,
            ref AccountBalance);

        if (isAccountFound)
        {
            return new clsAccount(
                AccountID,
                AccountParentNo,
                AccountNameAr,
                AccountNameEn,
                AccountType,
                AccountReport,
                AccountLevel,
                AccountDebit,
                AccountCredit,
                AccountBalance);
        }
        else
        {
            return null;
        }
    }
}
