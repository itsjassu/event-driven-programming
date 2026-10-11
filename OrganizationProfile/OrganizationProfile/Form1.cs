using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }


        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);
            return _StudentNo;
        }

        public long ContactNo(string contact)
        {
            if (!Regex.IsMatch(contact, @"^[0-9]{10,11}$"))
            {
                throw new FormatException(
                    "Contact number must contain 10 or 11 digits.");
            }

            _ContactNo = long.Parse(contact);
            return _ContactNo;
        }

        public string FullName(
            string lastName,
            string firstName,
            string middleInitial)
        {
            if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(firstName, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(middleInitial, @"^[a-zA-Z]$"))
            {
                throw new FormatException(
                    "Enter valid names and a one-letter middle initial.");
            }

            _FullName = lastName + ", " + firstName + ", " + middleInitial;
            return _FullName;
        }

        public int Age(string age)
        {
            _Age = int.Parse(age);

            if (_Age < 1 || _Age > 120)
            {
                throw new OverflowException(
                    "Age must be between 1 and 120.");
            }

            return _Age;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            

            for(int i = 0; i<6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Check required fields
                if (string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtMiddleInitial.Text) ||
                    string.IsNullOrWhiteSpace(txtAge.Text) ||
                    string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    throw new ArgumentNullException(
                        "Please complete all required fields.");
                }

                // Check student number format
                if (!Regex.IsMatch(txtStudentNo.Text, @"^[0-9]+$"))
                {
                    throw new FormatException(
                        "Student number must contain digits only.");
                }

                // Check program selection
                string[] programs =
                {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
        };

                int selectedIndex = cbPrograms.SelectedIndex;

                if (selectedIndex < 0 ||
                    selectedIndex >= programs.Length)
                {
                    throw new IndexOutOfRangeException(
                        "Please select a valid program.");
                }

                // Check gender selection
                if (cbGender.SelectedIndex < 0)
                {
                    throw new ArgumentNullException(
                        "Please select a gender.");
                }

                // Store the registration information
                StudentInformationClass.SetStudentNo =
                    StudentNumber(txtStudentNo.Text);

                StudentInformationClass.SetFullName =
                    FullName(
                        txtLastName.Text,
                        txtFirstName.Text,
                        txtMiddleInitial.Text);

                StudentInformationClass.SetContactNo =
                    ContactNo(txtContactNo.Text);

                StudentInformationClass.SetAge =
                    Age(txtAge.Text);

                StudentInformationClass.SetProgram =
                    cbPrograms.SelectedItem.ToString();

                StudentInformationClass.SetGender =
                    cbGender.SelectedItem.ToString();

                StudentInformationClass.SetBirthday =
                    datePickerBirthday.Value.ToString("yyyy-MM-dd");

                // Open the confirmation form
                frmConfirmation confirmation = new frmConfirmation();
                confirmation.ShowDialog();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Invalid Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Overflow Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Invalid Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                Console.WriteLine("Registration attempt completed.");
            }
        }

    }

}

