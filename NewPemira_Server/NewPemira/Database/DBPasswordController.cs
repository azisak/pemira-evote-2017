using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPemira
{
    class DBPasswordController
    {
        /* Atribut Kelas DB NIM yang Sudah Memilih Controller
         * Inisialisasi adapter, dataset, dan sqlcommand untuk method kelas
         */
        public static DBPemiraDataSetTableAdapters.PasswordTableAdapter passwordTableAdapter = new DBPemiraDataSetTableAdapters.PasswordTableAdapter();
        public static DBPemiraDataSet.PasswordDataTable passwordDT = new DBPemiraDataSet.PasswordDataTable();
        public static SqlCommand sqlCmd = new SqlCommand();

        /* Constructor
         */
        public DBPasswordController()
        {
            try
            {
                sqlCmd.Connection = passwordTableAdapter.Connection;
                passwordTableAdapter.Fill(passwordDT);
            }
            catch (Exception e)
            {
                MessageBox.Show("DataBase Open error\nMessage: " + e.Message + "\n\nSource: " + e.Source);
            }
        }

        public bool addPassword(string password)
        {
            int result = passwordTableAdapter.Insert(password);
            if (result == 1)
            {
                MessageBox.Show("Add Password Berhasil");
                return true;
            }
            else
            {
                MessageBox.Show("Add Password Gagal");
                return false;
            }
        }

        public bool addPassword(List<string> password)
        {
            try
            {
                int result = passwordTableAdapter.Insert(password[0]);
                if (result == 1)
                {
                    MessageBox.Show("Add Password Berhasil");
                    passwordTableAdapter.Fill(passwordDT);
                    return true;
                }
                else
                {
                    MessageBox.Show("Add Password Gagal");
                    return false;
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            return false;
        }

        public bool isTableEmpty()
        {
            return passwordDT.Count == 0;
        }

        public bool checkPassword(List<string> password)
        {
            bool check = true;
            string find = "password = '" + password[0] + "'";
            DataRow[] found = passwordDT.Select(find);

            if (found.Length == 1)
            {
                string column = "password";
                if (!password.Contains(found[0][column].ToString()))
                {
                    check = false;
                }
            }
            else
            {
                check = false;
            }
            return check;
        }
    }
}
