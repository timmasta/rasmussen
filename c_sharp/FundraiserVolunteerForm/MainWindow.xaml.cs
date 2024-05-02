using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FundraiserVolunteerForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FormValues userEntries = new FormValues();

        //fill the hours box with ranges
        List<string> hoursOptions = new List<string>
            {
                "5-10 hours per week",
                "11-20 hours per week",
                "21-30 hours per week",
                "31-40 hours per week"
            };

        List<string> activityOptions = new List<string>
            {
                "Brat Fry",
                "Walkathon",
                "Bake Sale",
                "Golf Tournament",
                "Car Wash"
            };

        public MainWindow()
        {
            InitializeComponent();
            

            

            comboBoxHours.ItemsSource = hoursOptions;
            comboBoxHours.SelectedIndex = 0;
        }

        private string BuildConfirmationMessage()
        {
            // Build a string containing all the user inputs
            string message = $"Name: {userEntries.userName}\n" +
                             $"Hours Available: {userEntries.hoursAvailable}\n" +                             
                             $"Activities: ";

            foreach (int activityIndex in userEntries.activityIndices)
            {
                message += $"{activityOptions[activityIndex]}, ";
            }
            message += $"\nStatus: {userEntries.isNewVolunteer}";

            return message.TrimEnd(',', ' ');
        }

        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            userEntries.userName = txtBoxName.Text;
        }

        private void comboBoxHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userEntries.hoursAvailable = hoursOptions[comboBoxHours.SelectedIndex];
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {

            string confirmationMessage = BuildConfirmationMessage();
            MessageBox.Show(confirmationMessage, "You have clicked submit!", MessageBoxButton.OK);
        }

        private void activity0_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.activityIndices.Add(0);
        }

        private void activity0_Unchecked(object sender, RoutedEventArgs e)
        {
            if (userEntries.activityIndices.Contains(0))
            {
                userEntries.activityIndices.Remove(0);
            }
        }

        private void activity1_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.activityIndices.Add(1);
        }

        private void activity1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (userEntries.activityIndices.Contains(1))
            {
                userEntries.activityIndices.Remove(1);
            }
        }

        private void activity2_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.activityIndices.Add(2);
        }

        private void activity2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (userEntries.activityIndices.Contains(2))
            {
                userEntries.activityIndices.Remove(2);
            }
        }

        private void activity3_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.activityIndices.Add(3);
        }

        private void activity3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (userEntries.activityIndices.Contains(3))
            {
                userEntries.activityIndices.Remove(3);
            }
        }

        private void activity4_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.activityIndices.Add(4);
        }

        private void activity4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (userEntries.activityIndices.Contains(4))
            {
                userEntries.activityIndices.Remove(4);
            }
        }


        private void checkBoxNewVolunteer_Checked(object sender, RoutedEventArgs e)
        {
            userEntries.isNewVolunteer = "New";
        }

        private void checkBoxNewVolunteer_Unchecked(object sender, RoutedEventArgs e)
        {
            userEntries.isNewVolunteer = "Existing";
        }
    }

    public partial class FormValues()
    {
        public string userName = "No Name Entered";
        public List<int> activityIndices = new List<int>();
        public string hoursAvailable = "";
        public string isNewVolunteer = "New";

    }
}