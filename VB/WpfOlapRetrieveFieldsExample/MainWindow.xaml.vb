Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace WpfOlapRetrieveFieldsExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Specifies the Olap connection settings.
            pivotGridControl1.OlapDataProvider = OlapDataProvider.Adomd
            pivotGridControl1.OlapConnectionString = "Provider=MSOLAP;" & ControlChars.CrLf & _
"                Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll; " & ControlChars.CrLf & _
"                Initial catalog=Adventure Works DW Standard Edition;" & ControlChars.CrLf & _
"                Cube name=Adventure Works;" & ControlChars.CrLf & _
"                Query Timeout=100;"

            ' Retrieves fields.
            pivotGridControl1.RetrieveFields(FieldArea.ColumnArea, False)

            ' Adds some fields from the Field List to the specified area to create a report.
            pivotGridControl1.Fields("[Customer].[Country].[Country]").Area = FieldArea.RowArea
            pivotGridControl1.Fields("[Customer].[Country].[Country]").Visible = True
            pivotGridControl1.Fields("[Customer].[City].[City]").Area = FieldArea.RowArea
            pivotGridControl1.Fields("[Customer].[City].[City]").Visible = True
            pivotGridControl1.Fields("[Date].[Fiscal].[Fiscal Year]").Area = FieldArea.ColumnArea
            pivotGridControl1.Fields("[Date].[Fiscal].[Fiscal Year]").Visible = True
            pivotGridControl1.Fields("[Measures].[Internet Sales Amount]").Visible = True

            ' Sets the Customization Forms style to Excel2007 with additional capabilities.
            pivotGridControl1.FieldListStyle = FieldListStyle.Excel2007

            ' Invokes the Field List.
            pivotGridControl1.ShowFieldList()
        End Sub
    End Class
End Namespace
