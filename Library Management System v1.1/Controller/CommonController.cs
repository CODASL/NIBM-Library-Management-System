using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class CommonController
    {

        //==================Field Validations=============================
        public Boolean isEmailValid(String email)
        {

            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);
            if (!reg.IsMatch(email))
            {
                return false;
            }
            else if(email == null)
            {
                return false;
            }
            return true;
        }

        public Boolean isEmailValid1(String email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public Boolean isPhoneNumberValid(int phone)
        {
            if(phone.ToString().Length != 9)
            {
                return false;
            }
            return true;
        }

        //============================Building Random Passwords==============================
        public string RandomPassword(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        //======================Phone number Field logic==========================
        public String BindNumber(String selectedCountryCode , int phoneNumber) {
            String phone = selectedCountryCode + phoneNumber.ToString();
            Console.WriteLine(phone);
            return phone;
        }

        public void extractNumber(MaterialComboBox cmb , MaterialTextBox txt , String number)
        {
            String countrycode = number.Substring(0,(number.Length-9));
            String phone = number.Substring(number.Length - 9);
            Console.WriteLine(countrycode + phone);
            cmb.Text = countrycode;
            txt.Text = phone;
        }
    }
}
