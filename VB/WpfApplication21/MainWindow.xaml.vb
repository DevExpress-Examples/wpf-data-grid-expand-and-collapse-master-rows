Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Input

Namespace WpfApplication21

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = Employees.GetEmployees()
        End Sub

        Private Sub TableView_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            Dim view As TableView = TryCast(sender, TableView)
            ' Avoid key processing when focus is within detail views or when a group row is focused:
            If Not view.IsFocusedView OrElse view.FocusedRowHandle < 0 Then Return
            ' Process CTRL+* key combination:
            If e.Key = Key.Multiply AndAlso (Keyboard.Modifiers And ModifierKeys.Control) = ModifierKeys.Control Then
                Dim finalExpandedState As Boolean = Not view.Grid.IsMasterRowExpanded(view.FocusedRowHandle)
                view.Grid.SetMasterRowExpanded(view.FocusedRowHandle, finalExpandedState)
                e.Handled = True
            End If
        End Sub

        Private Sub ExpandAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
            For i As Integer = 0 To Me.grid.VisibleRowCount - 1
                Dim rowHandle = Me.grid.GetRowHandleByVisibleIndex(i)
                Me.grid.ExpandMasterRow(rowHandle)
            Next
        End Sub

        Private Sub CollapseAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
            For i As Integer = 0 To Me.grid.VisibleRowCount - 1
                Dim rowHandle = Me.grid.GetRowHandleByVisibleIndex(i)
                Me.grid.CollapseMasterRow(rowHandle)
            Next
        End Sub

        Private Sub CollapseAllButThis(ByVal sender As Object, ByVal e As RoutedEventArgs)
            For i As Integer = 0 To Me.grid.VisibleRowCount - 1
                Dim rowHandle = Me.grid.GetRowHandleByVisibleIndex(i)
                Dim detailGrid = Me.grid.GetVisibleDetail(rowHandle)
                If detailGrid IsNot Nothing Then
                    Dim detailView = CType(detailGrid, GridControl).View
                    Dim focusedDetailRowHandle = CType(detailView, TableView).FocusedRowHandle
                    If focusedDetailRowHandle = DataControlBase.InvalidRowHandle AndAlso rowHandle <> Me.view.FocusedRowHandle Then Me.grid.CollapseMasterRow(rowHandle)
                End If
            Next
        End Sub
    End Class

    Public Class Employee

        Public Property FirstName As String

        Public Property LastName As String

        Public Property Title As String

        Public Property Orders As List(Of Order)
    End Class

    Public Class Order

        Public Property Supplier As String

        Public Property [Date] As Date

        Public Property ProductName As String

        Public Property Quantity As Integer
    End Class

    Public Class Employees

        Public Shared Function GetEmployees() As ObservableCollection(Of Employee)
            Dim employees As ObservableCollection(Of Employee) = New ObservableCollection(Of Employee)() From {New Employee() With {.FirstName = "Bruce", .LastName = "Cambell", .Title = "Sales Manager", .Orders = New List(Of Order)()}, New Employee() With {.FirstName = "Cindy", .LastName = "Haneline", .Title = "Vice President of Sales", .Orders = New List(Of Order)()}}
            employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 1", .[Date] = Date.Now, .ProductName = "TV", .Quantity = 20})
            employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 2", .[Date] = Date.Now.AddDays(3), .ProductName = "Projector", .Quantity = 15})
            employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 3", .[Date] = Date.Now.AddDays(3), .ProductName = "HDMI Cable", .Quantity = 50})
            employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 1", .[Date] = Date.Now.AddDays(1), .ProductName = "Blu-Ray Player", .Quantity = 10})
            employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 2", .[Date] = Date.Now.AddDays(1), .ProductName = "HDMI Cable", .Quantity = 10})
            employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 3", .[Date] = Date.Now.AddDays(1), .ProductName = "Projector", .Quantity = 10})
            employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 4", .[Date] = Date.Now.AddDays(1), .ProductName = "Amplifier", .Quantity = 10})
            Return employees
        End Function
    End Class
End Namespace
