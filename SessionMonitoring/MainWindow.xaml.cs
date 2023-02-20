using SessionMonitoring.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SessionMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private List<Employee> employees;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeEmployees();
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void InitializeEmployees()
        {
            employees = new List<Employee>
            {
                new Employee("Финн Мертенс", "Researcher", new Session(), new SessionStatus("Inactive", false)),
                new Employee("Марселин Абадир", "Manager", new Session(), new SessionStatus("Inactive", false)),
                new Employee("Леон Кеннеди", "Researcher", new Session(), new SessionStatus("Inactive", false)),
                new Employee("Игги Куперсон", "IT", new Session(), new SessionStatus("Probably still working.. 😵‍💫", false)),
                new Employee("Гвен Стэйси", "HR", new Session(), new SessionStatus("Inactive", false))
            };
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable start button and enable stop button
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;

            // Stop timer
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer = null;
            }

            employees.ForEach(employee =>
            {
                employee.Session.StartTime = DateTime.Now;
                employee.SessionStatus.Status = employee.AccessLevel == "IT" ? "Big brain stuff.. " : "Active 😸";
                employee.SessionStatus.IsActive = true;

            });

            // Update status text
            StatusText.Content = "Status: Monitoring...";
            EmployeeDataGrid.Items.Refresh();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            // Enable start button and disable stop button
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;

            // Start timer to periodically update session status and duration
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();

            employees.ForEach(employee =>
            {
                employee.Session.EndTime = DateTime.Now;
                employee.Session.Duration = employee.Session.EndTime - employee.Session.StartTime;
                employee.SessionStatus.Status = employee.AccessLevel == "IT" ? "Probably still working.. 😵‍💫" : "Inactive";
                employee.SessionStatus.IsActive = false;
            });

            // Update status text
            StatusText.Content = "Status: Not Monitoring";
            EmployeeDataGrid.Items.Refresh();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Loop through each employee and update their session status and duration
            foreach (var employee in employees)
            {
                // Get current session status
                var currentStatus = employee.SessionStatus;
                var session = employee.Session;

                // Display message/notification for inactive sessions
                if (!currentStatus.IsActive)
                {
                    MessageBox.Show($"Employee { employee.EmployeeName }'s session is { currentStatus.Status }.");
                }
            }
        }
    }
}
