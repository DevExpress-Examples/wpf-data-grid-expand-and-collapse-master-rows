using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication21 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = Employees.GetEmployees();
        }

        private void TableView_KeyDown(object sender, KeyEventArgs e) {
            TableView view = sender as TableView;

            // Avoid key processing when focus is within detail views or when a group row is focused:
            if (!view.IsFocusedView || view.FocusedRowHandle < 0)
                return;

            // Process CTRL+* key combination:
            if (e.Key == Key.Multiply && ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)) {
                bool finalExpandedState = !view.Grid.IsMasterRowExpanded(view.FocusedRowHandle);
                view.Grid.SetMasterRowExpanded(view.FocusedRowHandle, finalExpandedState);
                e.Handled = true;
            }
        }

        void ExpandAll(object sender, RoutedEventArgs e) {
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                var rowHandle = grid.GetRowHandleByVisibleIndex(i);
                grid.ExpandMasterRow(rowHandle);
            }
        }

        void CollapseAll(object sender, RoutedEventArgs e) {
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                var rowHandle = grid.GetRowHandleByVisibleIndex(i);
                grid.CollapseMasterRow(rowHandle);
            }
        }

        void CollapseAllButThis(object sender, RoutedEventArgs e) {
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                var rowHandle = grid.GetRowHandleByVisibleIndex(i);
                var detailGrid = grid.GetVisibleDetail(rowHandle);
                if (detailGrid != null) {
                    var detailView = ((GridControl)detailGrid).View;
                    var focusedDetailRowHandle = ((TableView)detailView).FocusedRowHandle;
                    if (focusedDetailRowHandle == DataControlBase.InvalidRowHandle && rowHandle != view.FocusedRowHandle)
                        grid.CollapseMasterRow(rowHandle);
                }
            }
        }
    }
    public class Employee {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Order {
        public string Supplier { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
    public class Employees {
        public static ObservableCollection<Employee> GetEmployees() {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>() {
                new Employee() {
                    FirstName="Bruce",
                    LastName="Cambell",
                    Title="Sales Manager",
                    Orders = new List<Order>()
                },
                new Employee() {
                    FirstName="Cindy",
                    LastName="Haneline",
                    Title="Vice President of Sales",
                    Orders = new List<Order>()
                },
            };
            employees[0].Orders.Add(new Order() { Supplier = "Supplier 1", Date = DateTime.Now, ProductName = "TV", Quantity = 20 });
            employees[0].Orders.Add(new Order() { Supplier = "Supplier 2", Date = DateTime.Now.AddDays(3), ProductName = "Projector", Quantity = 15 });
            employees[0].Orders.Add(new Order() { Supplier = "Supplier 3", Date = DateTime.Now.AddDays(3), ProductName = "HDMI Cable", Quantity = 50 });
            employees[1].Orders.Add(new Order() { Supplier = "Supplier 1", Date = DateTime.Now.AddDays(1), ProductName = "Blu-Ray Player", Quantity = 10 });
            employees[1].Orders.Add(new Order() { Supplier = "Supplier 2", Date = DateTime.Now.AddDays(1), ProductName = "HDMI Cable", Quantity = 10 });
            employees[1].Orders.Add(new Order() { Supplier = "Supplier 3", Date = DateTime.Now.AddDays(1), ProductName = "Projector", Quantity = 10 });
            employees[1].Orders.Add(new Order() { Supplier = "Supplier 4", Date = DateTime.Now.AddDays(1), ProductName = "Amplifier", Quantity = 10 });
            return employees;
        }
    }
}
