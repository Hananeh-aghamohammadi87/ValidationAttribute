using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace ValidationAttribute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidatePerson(Person p)
        {
            errorProvider1.Clear();

            var context =
                new ValidationContext(p);

            var results =
                new List<ValidationResult>();

            bool isValid =
                Validator.TryValidateObject(
                    p,
                    context,
                    results,
                    true);

            foreach (ValidationResult item in results)
            {
                foreach (string member in item.MemberNames)
                {
                    if (member == "FirstName")
                    {
                        errorProvider1.SetError(
                            txtName,
                            item.ErrorMessage);
                    }

                    if (member == "LastName")
                    {
                        errorProvider1.SetError(
                            txtFamily,
                            item.ErrorMessage);
                    }
                }
            }

            return isValid;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var p = new Person();

            p.FirstName = txtName.Text;
            p.LastName = txtFamily.Text;

            if (!ValidatePerson(p))
                return;

            MessageBox.Show("ثبت شد");
        }
    }
}
