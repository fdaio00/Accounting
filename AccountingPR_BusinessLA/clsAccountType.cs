using System;
using System.Data;
using System.Threading.Tasks;

public class clsAccountType
{
    enum enMode { AddNew = 0, Update = 1 };
    private enMode _Mode;

    public int AccountTypeIDID { get; set; }
    public string AccountTypeIDNameAr { get; set; }
    public string AccountTypeIDNameEn { get; set; }

    public clsAccountType()
    {
        this.AccountTypeIDID = -1;
        this.AccountTypeIDNameAr = "";
        this.AccountTypeIDNameEn = null;
        _Mode = enMode.AddNew;
    }

    public clsAccountType(int AccountTypeIDID, string AccountTypeIDNameAr, string AccountTypeIDNameEn)
    {
        this.AccountTypeIDID = AccountTypeIDID;
        this.AccountTypeIDNameAr = AccountTypeIDNameAr;
        this.AccountTypeIDNameEn = AccountTypeIDNameEn;
        _Mode = enMode.Update;
    }

    private async Task<bool> _AddNewAccountTypeIDAsync()
    {
        this.AccountTypeIDID = await clsAccountTypeData.AddNewAccountTypeIDAsync(this.AccountTypeIDNameAr, this.AccountTypeIDNameEn);
        return (this.AccountTypeIDID > 0);
    }

    private async Task<bool> _UpdateAccountTypeIDAsync()
    {
        return await clsAccountTypeData.UpdateAccountTypeIDAsync(this.AccountTypeIDID, this.AccountTypeIDNameAr, this.AccountTypeIDNameEn);
    }

    public async Task<bool> SaveAsync()
    {
        switch (_Mode)
        {
            case enMode.Update:
                return await _UpdateAccountTypeIDAsync();
            case enMode.AddNew:
                if (await _AddNewAccountTypeIDAsync())
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
        return await clsAccountTypeData.DeleteAccountTypeIDAsync(this.AccountTypeIDID);
    }

    public static async Task<DataTable> GetAllAccountTypeIDsAsync()
    {
        return await clsAccountTypeData.GetAllAccountTypeIDsAsync();
    }

    public static clsAccountType GetAccountTypeIDByID(int AccountTypeIDID)
    {
        string AccountTypeIDNameAr = null;
        string AccountTypeIDNameEn = null;

        bool isAccountTypeIDFound = clsAccountTypeData.FindAccountTypeIDByID(AccountTypeIDID, ref AccountTypeIDNameAr, ref AccountTypeIDNameEn);

        if (isAccountTypeIDFound)
        {
            return new clsAccountType(AccountTypeIDID, AccountTypeIDNameAr, AccountTypeIDNameEn);
        }
        else
        {
            return null;
        }
    }
}
