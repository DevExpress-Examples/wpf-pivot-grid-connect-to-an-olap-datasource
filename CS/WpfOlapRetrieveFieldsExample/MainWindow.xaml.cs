using System.Windows;
using DevExpress.Xpf.PivotGrid;

namespace WpfOlapRetrieveFieldsExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Specifies the Olap connection settings.
            pivotGridControl1.OlapDataProvider = OlapDataProvider.Adomd;
            pivotGridControl1.OlapConnectionString = 
                @"Provider=MSOLAP;
                Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll; 
                Initial catalog=Adventure Works DW Standard Edition;
                Cube name=Adventure Works;
                Query Timeout=100;";
            
            // Retrieves fields.
            pivotGridControl1.RetrieveFields(FieldArea.ColumnArea, false);

            // Adds some fields from the Field List to the specified area to create a report.
            pivotGridControl1.Fields["[Customer].[Country].[Country]"].Area = FieldArea.RowArea;
            pivotGridControl1.Fields["[Customer].[Country].[Country]"].Visible = true;
            pivotGridControl1.Fields["[Customer].[City].[City]"].Area = FieldArea.RowArea;
            pivotGridControl1.Fields["[Customer].[City].[City]"].Visible = true;
            pivotGridControl1.Fields["[Date].[Fiscal].[Fiscal Year]"].Area = FieldArea.ColumnArea;
            pivotGridControl1.Fields["[Date].[Fiscal].[Fiscal Year]"].Visible = true;
            pivotGridControl1.Fields["[Measures].[Internet Sales Amount]"].Visible = true;

            // Sets the Customization Forms style to Excel2007 with additional capabilities.
            pivotGridControl1.FieldListStyle = FieldListStyle.Excel2007;

            // Invokes the Field List.
            pivotGridControl1.ShowFieldList();
        }
    }
}
