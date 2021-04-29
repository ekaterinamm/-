using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class FormUsers : Form
    {

        public List<User> Users = new List<User>();

        public class User
        {
            public readonly string password;
            public readonly string login;
            public readonly DateTime dateOfBirth;
            public readonly string phoneNumber;
            public readonly string email;
            public readonly string name;
            public readonly string surname;

            public User(string userPassword, string userLogin, DateTime userDateofBirth, string userPhoneNumber, string userMail, string userName, string userSurname)
            {
                //this не нужен(для красоты)
                this.password = userPassword;
                this.login = userLogin;
                this.dateOfBirth = userDateofBirth;
                this.phoneNumber = userPhoneNumber;
                this.email = userMail;
                this.name = userName;
                this.surname = userSurname;
            }

            public object[] getUserInfo()
            {
                return new object[] { login, email, name, surname, phoneNumber };
            }

        }
        public FormUsers()
        {
            InitializeComponent();
            UserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UserData.MultiSelect = true;
        }
        
        public void AddNewUser(User user)
        {
            Users.Add(user);
            UserData.Rows.Add(user.getUserInfo());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserAdd_Click(object sender, EventArgs e)
        {
            // Неоптимизированный способ ( лучше очищать и скрывать форму )
            NewUserAddForm newUserForm = new NewUserAddForm(this);
            newUserForm.Show();
        }


        //Удаление по индексу (0 элемента)
        private void button1_Click(object sender, EventArgs e)
        {
            if (UserData.SelectedRows.Count <= 0) return;
            int indSelect = UserData.SelectedRows[0].Index;

            UserData.Rows.RemoveAt(indSelect);
        }
    }
}
