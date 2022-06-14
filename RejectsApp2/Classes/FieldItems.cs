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

    public DataTable rejectTypesDataTable { get; }
    public DataTable productLinesDataTable { get; }
    public DataTable responsibleDataTable { get; }
    public DataTable vendorsDataTable { get; }
    public DataTable dispositionCodesDataTable { get; }

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
}