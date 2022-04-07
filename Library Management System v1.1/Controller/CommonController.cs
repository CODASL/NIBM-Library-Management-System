﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //===========Set Update Time==============================
        public String setUpdatedTime(String column_name, String table_name, String primary_key,String whereCommand)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT TOP 1 " + column_name + " FROM " + table_name + whereCommand+" ORDER BY " + primary_key + " DESC");
                sdr.Read();
                if (sdr.HasRows)
                {
                    String date = sdr[column_name].ToString();
                    database.Con.Close();
                    return date;
                }
                else
                {
                    database.Con.Close();
                    return "NO DATA";
                }
            }
            catch (Exception ex)
            {
                database.Con.Close();
                MessageBox.Show(ex.ToString());
                return "";
            }
        }


        //===============Custom Code For loadActivities =====================================
        public void loadActivities(MaterialListView listView, String Emp_No)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            listView.Items.Clear();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Activity WHERE Emp_Id= '" + Emp_No + "'");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["Description"].ToString());
                        item.SubItems.Add(sdr["Updated_Time"].ToString());
                        listView.Items.Add(item);
                    }
                    database.Con.Close();
                }
                else
                {
                    Console.WriteLine("No Data to Show");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }

        //==================Generate Id ==============================================

        public void setId(MaterialTextBox textBox, String IDColumn, String tableName, String firstLetter)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            String id;
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT TOP 1 " + IDColumn + " FROM " + tableName + " ORDER BY " + IDColumn + " DESC");
                sdr.Read();
                if (sdr.HasRows)
                {
                    id = sdr[IDColumn].ToString();
                    database.Con.Close();
                    id = firstLetter.ToUpper() + (Convert.ToInt32(id.Remove(0, 1)) + 1).ToString();
                }
                else
                {
                    database.Con.Close();
                    id = firstLetter.ToUpper() + "1";
                }

                textBox.Text = id;
            }
            catch (MySqlException ex)
            {
                database.Con.Close();
            }
            catch (Exception ex)
            {
                database.Con.Close();
            }
        }
    }
}
