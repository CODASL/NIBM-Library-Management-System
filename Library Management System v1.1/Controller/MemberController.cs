using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class MemberController
    {
        public Boolean addMember(Model.Member member , Model.Guardian guardian)
        {
            Model.DatabaseService database = new Model.DatabaseService();

            int row = database.insertData("INSERT INTO Member VALUES('" + member.MemberId + "','" + member.Name + "','" + member.Address + "'," +
                                "'" + member.PhoneNo + "','" + member.NIC1 + "','" + member.GuardianId + "','" + member.Updated_date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + member.Added_date.ToString("yyyy-MM-dd HH:mm:ss") + "')");

            int row2 = database.insertData("INSERT INTO Guardian VALUES('" + guardian.Id + "','" + guardian.Name + "','" + guardian.NIC1 + "','" + guardian.Address + "'," +
                "'" + guardian.Phone + "','" + guardian.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "')");
           
            return row > 0 && row2>0;
        }


        public Boolean updateMember(Model.Member member ,  Model.Guardian guardian)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            int row = database.updateData("UPDATE Member SET Name = '" + member.Name + "', Address= '" + member.Address + "'," +
                                "Phone_NO = '" + member.PhoneNo + "',NIC = '" + member.NIC1 + "',Guardian_id ='" + member.GuardianId + "',updated_date = '" + member.Updated_date.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE MID = '" + member.MemberId + "'");

            int row2 = database.updateData("UPDATE Guardian SET Name = '" + guardian.Name + "' , NIC = '" + guardian.NIC1 + "' ," +
                "Address ='" + guardian.Address + "' ,Phone '"+guardian.Phone+"', updated_date '"+guardian.UpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE GID = '"+guardian.Id+"'");
            
            return row > 0 && row2>0;
        }
    }
}
