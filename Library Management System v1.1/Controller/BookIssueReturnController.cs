using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class BookIssueReturnController
    {
        //===========================Search Function ==================================================
        public static void bookIssueSearchFunction(MaterialListView list, int itemIndex, MaterialTextBox inputBox)
        {

            if (itemIndex == 0)
            {

                for (int i = list.Items.Count - 1; i >= 0; i--)
                {
                    var item = list.Items[i];

                    if (item.Text.ToLower().Contains(inputBox.Text.ToLower()))
                    {

                    }
                    else
                    {
                        list.Items.Remove(item);
                    }
                }
                if (list.SelectedItems.Count == 1)
                {
                    list.Focus();
                }
            }
            else if (itemIndex == 1)
            {
                for (int i = list.Items.Count - 1; i >= 0; i--)
                {
                    var item = list.Items[i];

                    if (item.SubItems[1].Text.ToLower().Contains(inputBox.Text.ToLower()))
                    {

                    }
                    else
                    {
                        list.Items.Remove(item);
                    }
                }
                if (list.SelectedItems.Count == 1)
                {
                    list.Focus();
                }

            }
            else if (itemIndex == 2)
            {
                for (int i = list.Items.Count - 1; i >= 0; i--)
                {
                    var item = list.Items[i];

                    if (item.SubItems[5].Text.ToLower().Contains(inputBox.Text.ToLower()))
                    {

                    }
                    else
                    {
                        list.Items.Remove(item);
                    }
                }
                if (list.SelectedItems.Count == 1)
                {
                    list.Focus();
                }

            }
            else
            {

            }

        }
    }
}
