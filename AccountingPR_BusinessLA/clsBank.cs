using System;
using System.Threading.Tasks;
using System.Data;

public class clsBank
{
    enum enMode { AddNew = 0, Update = 1 };
    private enMode _Mode;

    public int BankID { get; set; }
    public string BankNameAr { get; set; }
    public string BankNameEn { get; set; }

    public clsBank()
    {
        this.BankID = -1;
        this.BankNameAr = "";
        this.BankNameEn = null;
        _Mode = enMode.AddNew;
    }

    public clsBank(int bankID, string bankNameAr, string bankNameEn)
    {
        this.BankID = bankID;
        this.BankNameAr = bankNameAr;
        this.BankNameEn = bankNameEn;
        _Mode = enMode.Update;
    }

    private async Task<bool> _AddNewBankAsync()
    {
        this.BankID = await clsBankData.AddNewBankAsync(this.BankNameAr, this.BankNameEn);
        return (this.BankID > 0);
    }

    private async Task<bool> _UpdateBankAsync()
    {
        return await clsBankData.UpdateBankAsync(this.BankID, this.BankNameAr, this.BankNameEn);
    }

    public async Task<bool> SaveAsync()
    {
        switch (_Mode)
        {
            case enMode.Update:
                return await _UpdateBankAsync();
            case enMode.AddNew:
                if (await _AddNewBankAsync())
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
        return await clsBankData.DeleteBankAsync(this.BankID);
    }

    public static async Task<DataTable> GetAllBanksAsync()
    {
        return await clsBankData.GetAllBanksAsync();
    }

    public static clsBank GetBankByID(int BankID)
    {
        string BankNameAr = null;
        string BankNameEn = null;

        bool isBankFound = clsBankData.FindBankByID(BankID, out BankNameAr, out BankNameEn);

        if (isBankFound)
        {
            return new clsBank(BankID, BankNameAr, BankNameEn);
        }
        else
        {
            return null;
        }
    }
}
