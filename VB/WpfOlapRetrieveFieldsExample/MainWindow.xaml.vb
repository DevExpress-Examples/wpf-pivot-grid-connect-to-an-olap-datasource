Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace WpfOlapRetrieveFieldsExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            ' Specifies the Olap connection settings.
            Me.pivotGridControl1.OlapDataProvider = OlapDataProvider.Adomd
            Me.pivotGridControl1.OlapConnectionString = "Provider=MSOLAP;" & Microsoft.VisualBasic.Constants.vbCrLf & "                Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll; " & Microsoft.VisualBasic.Constants.vbCrLf & "                Initial catalog=Adventure Works DW Standard Edition;" & Microsoft.VisualBasic.Constants.vbCrLf & "                Cube name=Adventure Works;" & Microsoft.VisualBasic.Constants.vbCrLf & "                Query Timeout=100;"
            ' Retrieves fields.
            Me.pivotGridControl1.RetrieveFields(FieldArea.ColumnArea, False)
            ' Adds some fields from the Field List to the specified area to create a report.
            Me.pivotGridControl1.Fields("[Customer].[Country].[Country]").Area = FieldArea.RowArea
            Me.pivotGridControl1.Fields("[Customer].[Country].[Country]").Visible = True
            Me.pivotGridControl1.Fields("[Customer].[City].[City]").Area = FieldArea.RowArea
            Me.pivotGridControl1.Fields("[Customer].[City].[City]").Visible = True
            Me.pivotGridControl1.Fields("[Date].[Fiscal].[Fiscal Year]").Area = FieldArea.ColumnArea
            Me.pivotGridControl1.Fields("[Date].[Fiscal].[Fiscal Year]").Visible = True
            Me.pivotGridControl1.Fields("[Measures].[Internet Sales Amount]").Visible = True
            ' Sets the Customization Forms style to Excel2007 with additional capabilities.
            Me.pivotGridControl1.FieldListStyle = FieldListStyle.Excel2007
            ' Invokes the Field List.
            Me.pivotGridControl1.ShowFieldList()
        End Sub
    End Class
End Namespace
