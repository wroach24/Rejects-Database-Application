using System.Data;
using System.Windows.Forms;
using static RejectsApp2.Commands;

public class FieldItems
{
    public FieldItems()
    {
        rejectTypesDataTable = GetValuesForForm("SELECT * FROM Reject_Type");
        productLinesDataTable = GetValuesForForm("SELECT * FROM Product_Lines");
        responsibleDataTable = GetValuesForForm("SELECT * FROM Responsible");
        vendorsDataTable = GetValuesForForm("SELECT * FROM Vendors");
        dispositionCodesDataTable = GetValuesForForm("SELECT * FROM Disposition_Codes ");
    }

    public FieldItems(char RejectListTag)
    {
        RecentRejectDataTable =
            GetValuesForReport("SELECT Reject_Number FROM Rejects ORDER BY Date_Rejected DESC LIMIT 1000");
    }

    public DataTable rejectTypesDataTable { get; }
    public DataTable productLinesDataTable { get; }
    public DataTable responsibleDataTable { get; }
    public DataTable vendorsDataTable { get; }
    public DataTable dispositionCodesDataTable { get; }
    public DataTable RecentRejectDataTable { get; }

    public void FillMenus(ComboBox reject, ComboBox productLines, ComboBox responsible, ComboBox vendors)
    {
        FillOutDropMenu(rejectTypesDataTable, reject);
        FillOutDropMenu(productLinesDataTable, productLines);
        FillOutDropMenu(responsibleDataTable, responsible);
        FillOutDropMenu(vendorsDataTable, vendors);
    }

    public void FillDispositionMenu(ComboBox disposition)
    {
        FillOutDropMenu(dispositionCodesDataTable, disposition, 'x');
    }

    public void FillRecentRejects(ComboBox rejectList)
    {
        FillOutDropMenu(RecentRejectDataTable, rejectList);
    }
}