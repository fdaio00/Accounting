using System;
using System.Data;
using System.Threading.Tasks;

public class clsAccountType
{
    enum enMode { AddNew = 0, Update = 1 };
    private enMode _Mode;

    public int AccountTypeID { get; set; }
    public string AccountTypeNameAr { get; set; }
    public string AccountTypeNameEn { get; set; }

    public clsAccountType()
    {
        this.AccountTypeID = -1;
        this.AccountTypeNameAr = "";
        this.AccountTypeNameEn = null;
        _Mode = enMode.AddNew;
    }

    public clsAccountType(int accountTypeID, string accountTypeNameAr, string accountTypeNameEn)
    {
        this.AccountTypeID = accountTypeID;
        this.AccountTypeNameAr = accountTypeNameAr;
        this.AccountTypeNameEn = accountTypeNameEn;
        _Mode = enMode.Update;
    }

    private async Task<bool> _AddNewAccountTypeAsync()
    {
        this.AccountTypeID = await clsAccountTypeData.AddNewAccountTypeAsync(this.AccountTypeNameAr, this.AccountTypeNameEn);
        return (this.AccountTypeID > 0);
    }

    private async Task<bool> _UpdateAccountTypeAsync()
    {
        return await clsAccountTypeData.UpdateAccountTypeAsync(this.AccountTypeID, this.AccountTypeNameAr, this.AccountTypeNameEn);
    }

    public async Task<bool> SaveAsync()
    {
        switch (_Mode)
        {
            case enMode.Update:
                return await _UpdateAccountTypeAsync();
            case enMode.AddNew:
                if (await _AddNewAccountTypeAsync())
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
        return await clsAccountTypeData.DeleteAccountTypeAsync(this.AccountTypeID);
    }

    public static async Task<DataTable> GetAllAccountTypesAsync()
    {
        return await clsAccountTypeData.GetAllAccountTypesAsync();
    }

    public static clsAccountType GetAccountTypeByID(int AccountTypeID)
    {
        string AccountTypeNameAr = null;
        string AccountTypeNameEn = null;

        bool isAccountTypeFound = clsAccountTypeData.FindAccountTypeByID(AccountTypeID, ref AccountTypeNameAr, ref AccountTypeNameEn);

        if (isAccountTypeFound)
        {
            return new clsAccountType(AccountTypeID, AccountTypeNameAr, AccountTypeNameEn);
        }
        else
        {
            return null;
        }
    }
}
