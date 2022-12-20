<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128647685/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4044)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Expand and Collapse Master Rows

This example demonstrates how to expand and collapse the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl)'s master rows in code. The example contains the following buttons:

* The **Expand All** button expands all master rows.
* The **Collapse All** button collapses all master rows.
* The **Collapse All But This** button collapses all master rows except for the focused row / row with the focused detail.

The `CTRL+*` shortcut is bound to toggle the focused master row's expanded state.

![image](https://user-images.githubusercontent.com/65009440/208685574-6faad993-d7e1-4064-b367-35c2ede2a12a.png)

## Files to Review

* [MainWindow.xaml](./CS/WpfApplication21/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication21/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication21/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication21/MainWindow.xaml.vb))

## Documentation

* [Data Grid in Details](https://docs.devexpress.com/WPF/119851/controls-and-libraries/data-grid/master-detail/data-grid-in-details)
* [Expand and Collapse Master Rows](https://docs.devexpress.com/WPF/11836/controls-and-libraries/data-grid/master-detail/master-detail-member-table#expand-and-collapse-master-rows)
* [GridControl.ExpandMasterRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.ExpandMasterRow(System.Int32-DevExpress.Xpf.Grid.DetailDescriptorBase))
* [GridControl.CollapseMasterRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CollapseMasterRow(System.Int32-DevExpress.Xpf.Grid.DetailDescriptorBase))
* [GridControl.IsMasterRowExpanded](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.IsMasterRowExpanded(System.Int32-DevExpress.Xpf.Grid.DetailDescriptorBase))
* [GridControl.SetMasterRowExpanded](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.SetMasterRowExpanded(System.Int32-System.Boolean-DevExpress.Xpf.Grid.DetailDescriptorBase))

## More Examples

* [WPF Data Grid - Create Master-Detail Grid](https://github.com/DevExpress-Examples/wpf-data-grid-create-master-detail-grid)
* [WPF Data Grid - Create a Master-Detail Grid in Code](https://github.com/DevExpress-Examples/wpf-data-grid-create-master-detail-grid-in-code)
* [WPF Data Grid - Display Detail Content in Tabs](https://github.com/DevExpress-Examples/wpf-data-grid-display-detail-content-in-tabs)
* [WPF Data Grid - Specify Detail Buttons Visibility](https://github.com/DevExpress-Examples/detail-buttons-visibility-e4050)
* [WPF Data Grid - Select Details Based on the Data in the Master Row](https://github.com/DevExpress-Examples/how-to-use-different-details-depending-on-data-in-gridcontrols-master-row-t590724)
