using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobilyaciProjesi
{
    class programLog
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        string errormessage;
        string formname;
        string errorbutton;

        public programLog(string errormessage1, string formname1, string errorbutton1)
        {
            errormessage = errormessage1;
            formname = formname1;
            errorbutton = errorbutton1;
        }

        public void databaseinsert()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand programlog = new SqlCommand("Insert Into program_log(error_message,user_id,insert_date, form_name, error_button,error_status) Values (" +
                            "@error_message, @user_id, @insert_date, @formname, @errorbutton,@error_status)", con);
            programlog.Parameters.AddWithValue("@error_message", errormessage);
            programlog.Parameters.AddWithValue("@user_id", login.userid);
            programlog.Parameters.AddWithValue("@insert_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            programlog.Parameters.AddWithValue("@formname", formname);
            programlog.Parameters.AddWithValue("@errorbutton", errorbutton);
            programlog.Parameters.AddWithValue("@error_status", "1");
            con.Open();
            programlog.ExecuteNonQuery();
            con.Close();
        }
    }
}
