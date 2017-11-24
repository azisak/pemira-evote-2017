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

        public bool addPassword(string pass1, string pass2, string pass3, string pass4, string pass5, string pass6)
        {
            int result = passwordTableAdapter.Insert(pass1, pass2, pass3, pass4, pass5, pass6);
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
                int result = passwordTableAdapter.Insert(password[0], password[1], password[2], password[3], password[4], password[5]);
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
            if (passwordDT.Count == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool checkPassword(List<string> password)
        {
            bool check = true;
            string find = "password_1 = '" + password[0] + "'";
            DataRow[] found = passwordDT.Select(find);

            if (found.Length == 1)
            {
                for (int j = 0; j < 5; j++)
                {
                    string col = "password_" + (j + 1);
                }
                int i = 1;
                while (i < 6 && check)
                {
                    string col = "password_" + (i + 1);
                    if (!password.Contains(found[0][col].ToString()))
                    {
                        check = false;
                    }
                    i++;
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
