<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578458/22.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T344661)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Pivot Grid for WPF - How to Connect a Pivot Grid to an OLAP Data Source

The [Pivot Grid](https://docs.devexpress.com/WPF/7228/controls-and-libraries/pivot-grid) can display data from the the OLAP server (Microsoft Analysis Services). This example shows how to specify connection settings to the server and create fields that relate to specific measures and dimensions of the cube.

To bind the Pivot Grid control to an OLAP cube, follow the steps below.

1. Specify connection settings to the server. You can do it in the [Items Source Wizard](https://docs.devexpress.com/WPF/8015/controls-and-libraries/pivot-grid/binding-to-data/olap-data-source/binding-to-olap-data-sources#bind-to-an-olap-cube-at-design-time). The following code shows the resulting XML:


   ```xaml
   <!-- xmlns:dx="http://schemas.devexpress.com/winfx/2008/xaml/core" -->
    <Window.Resources>
        <dx:PivotOlapDataSource x:Key="PivotOlapDataSource" Cube="Adventure Works" 
                                Catalog="Adventure Works DW Standard Edition" ConnectionTimeout="60" 
                                LocaleIdentifier="1033" Password="{x:Null}" Provider="MSOLAP" 
                                QueryTimeout="30" Server="http://demos.devexpress.com/Services/OLAP/msmdpump.dll" 
                                UserId="{x:Null}">
        </dx:PivotOlapDataSource>
    </Window.Resources>
   ```

1. Bind the Pivot Grid to data. Set the [PivotGridControl.OlapDataProvider](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.OlapDataProvider) to _ADOMD_ and assign the connection string to the [PivotGridControl.OlapConnectionString](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.OlapConnectionString) property.

   ```xaml   
   <!-- xmlns:dxpg="http://schemas.devexpress.com/winfx/2008/xaml/pivotgrid" -->
    <Grid>
        <dxpg:PivotGridControl Name="pivotGridControl1" RowTreeMinWidth="170"
                               OlapDataProvider="Adomd" 
                               OlapConnectionString="{Binding ConnectionString, Source={StaticResource PivotOlapDataSource}}" />
    </Grid>
   ```


1. Create fields for all the measures and dimension in the bound OLAP cube, and move these fields to the specified area to make them hidden. To do it, use the [PivotGridControl.RetrieveFields](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.RetrieveFields.overloads) method overload with the _visible_ parameter and set the field's visibility to `false`. The `RetrieveFields` method generates [DataSourceColumnBinding](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.DataSourceColumnBinding?v=22.1) objects for each Pivot Grid field in OLAP, Server, and Optimized [modes](https://docs.devexpress.com/CoreLibraries/403802/devexpress-pivot-grid-core-library/pivot-grid-modes?v=22.1).


   ```cs
   public MainWindow() {
         InitializeComponent();

         // Retrieves fields.
         pivotGridControl1.RetrieveFields(FieldArea.ColumnArea, false);
   }
   ```

1. Place the created fields within corresponding Pivot Grid Control areas and set their [PivotGridField.Visible](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridField.Visible) property to `true`.


      ```cs
   public MainWindow() {
         // ...

         // Adds some fields from the Field List to the specified area to create a report.
         pivotGridControl1.Fields["[Customer].[Country].[Country]"].Area = FieldArea.RowArea;
         pivotGridControl1.Fields["[Customer].[Country].[Country]"].Visible = true;
         pivotGridControl1.Fields["[Customer].[City].[City]"].Area = FieldArea.RowArea;
         pivotGridControl1.Fields["[Customer].[City].[City]"].Visible = true;
         pivotGridControl1.Fields["[Date].[Fiscal].[Fiscal Year]"].Area = FieldArea.ColumnArea;
         pivotGridControl1.Fields["[Date].[Fiscal].[Fiscal Year]"].Visible = true;
         pivotGridControl1.Fields["[Measures].[Internet Sales Amount]"].Visible = true;
   }
   ```

   Use the invoked [Customization Form](https://docs.devexpress.com/WPF/11751/controls-and-libraries/pivot-grid/layout/customization-form/customization-form-overview) to manage the Pivot Grid control's layout.

## Files to Review

- [MainWindow.xaml.cs](./CS/WpfOlapRetrieveFieldsExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfOlapRetrieveFieldsExample/MainWindow.xaml.vb))

## Documentation

- [Pivot Grid Data Processing Modes](https://docs.devexpress.com/CoreLibraries/403802/devexpress-pivot-grid-core-library/pivot-grid-modes?v=22.1)
- [Bind a Pivot Grid Control to an OLAP Data Source](https://docs.devexpress.com/WPF/8015/controls-and-libraries/pivot-grid/binding-to-data/olap-data-source/binding-to-olap-data-sources)
- [Bind Pivot Grid Fields to Calculated Expressions](https://docs.devexpress.com/WPF/8025/controls-and-libraries/pivot-grid/binding-to-data/unbound-fields?v=22.1) 
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-pivot-grid-connect-to-an-olap-datasource&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-pivot-grid-connect-to-an-olap-datasource&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
