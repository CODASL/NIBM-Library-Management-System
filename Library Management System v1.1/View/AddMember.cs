using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.View
{
    public partial class AddMember : MaterialForm
    {
        Controller.CommonController commonController = new Controller.CommonController();
        Controller.MemberController memberController = new Controller.MemberController();
        Boolean isUpdate;
        String selectedRowID;
        public AddMember(Boolean isUpdate = false, String selectedRowID = "")
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.isUpdate = isUpdate;
            this.selectedRowID = selectedRowID;
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            commonController.setId(txt_mid, "MID", "Member", "M");
            commonController.setId(txt_GID, "GID", "Guardian", "G");
            loadAllFields();
            txt_mname.Focus();
        }

        //=================if update loadallfields ======================================================
        private void loadAllFields()
        {
            txt_mname.Focus();
            if (isUpdate)
            {
                Model.DatabaseService database = new Model.DatabaseService();
                this.Text = "Update Member";
                btn_AddMember.Text = "Update";
                String gid;
                try
                {
                    database.Con.Open();
                    MySqlDataReader sdr = database.readData("SELECT * FROM Member WHERE MID = '" + selectedRowID + "'");
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        txt_mid.Text = selectedRowID;
                        txt_mname.Text = sdr["Name"].ToString();
                        txt_MNIC.Text = sdr["NIC"].ToString();
                        txt_Maddress.Text = sdr["Address"].ToString();
                        commonController.extractNumber(cmb_Mcountrycodes, txt_MPhone, sdr["Phone_No"].ToString());
                        gid = sdr["Guardian_Id"].ToString();
                        database.Con.Close();
                        database.Con.Open();
                        MySqlDataReader sdr1 = database.readData("SELECT * FROM Guardian WHERE GID = '" + gid + "'");
                        sdr1.Read();
                        if (sdr1.HasRows)
                        {
                            txt_GID.Text = sdr1["GID"].ToString();
                            txt_Gname.Text = sdr1["Name"].ToString();
                            txt_GNIC.Text = sdr1["NIC"].ToString();
                            txt_GAddress.Text = sdr1["Address"].ToString();
                            commonController.extractNumber(cmb_GCountryCodes, txt_GPhone, sdr1["Phone"].ToString());
                        }
                    }

                    
                    database.Con.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Please check your internet connection \n" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    database.Con.Close();
                }
            }
        }


        //======================Add Member Btn ===================================================
        [Obsolete]
        private void btn_AddMember_Click(object sender, EventArgs e)
        {
            //Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                if (txt_mname.Text == null || txt_MNIC.Text == null || txt_Maddress.Text == null)
                {
                    MessageBox.Show("Please fill All Member Detail fields");
                }else if(txt_Gname.Text == null || txt_GNIC.Text == null || txt_GAddress.Text == null)
                {
                    MessageBox.Show("Please fill All Guardian Detail fields");
                }
                else if(txt_MPhone.Text.Length != 9)
                {
                    MessageBox.Show("Please Enter valid Member Phone number");
                }
                else if (txt_GPhone.Text.Length != 9)
                {
                    MessageBox.Show("Please Enter valid Guardian Phone number");
                }
                else
                {
                    //Bind Phone number
                    String Mphone = commonController.BindNumber(cmb_Mcountrycodes.SelectedItem.ToString(), Convert.ToInt32(txt_MPhone.Text));
                    String Gphone = commonController.BindNumber(cmb_GCountryCodes.SelectedItem.ToString(), Convert.ToInt32(txt_GPhone.Text));

                    //Define models
                    Model.Member member = new Model.Member(txt_mid.Text, txt_mname.Text, txt_Maddress.Text, Mphone, txt_MNIC.Text, txt_GID.Text, DateTime.Now, DateTime.Now);
                    Model.Guardian guardian = new Model.Guardian(txt_GID.Text, txt_Gname.Text, txt_GNIC.Text, txt_GAddress.Text, Gphone, DateTime.Now);
                    Model.MemberFee memberFee = new Model.MemberFee(new Controller.CommonController().setActivityId("Fee_Id", "Accounting").ToString(), txt_mid.Text, "0", "0", DateTime.Now);

                    Boolean isAdded;
                    if (!isUpdate)
                    {
                        isAdded = memberController.addMember(member, guardian);
                    }
                    else
                    {
                        isAdded = memberController.updateMember(member,guardian);
                    }

                    if (isAdded)
                    {
                        this.Hide();
                        if (isUpdate)
                        {
                            MessageBox.Show("Record Updated");

                        }
                        else
                        {
                            Controller.MemberFeeController.AddAccountingRecord(memberFee);
                            MessageBox.Show("Record Added");
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong try again");
                    }
                }
                
            }catch(MySqlException ex)
            {
                MessageBox.Show("Please check your internet connection \n"+ex.Message);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               
            }
        
        }

    }
}
