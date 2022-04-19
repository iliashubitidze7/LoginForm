using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Repository;
using UserRepository;


namespace LoginForm
{
    public partial class Default : System.Web.UI.Page
    {   
        private RepositoryBase _repository;
        public Default()
        {
            _repository = new RepositoryBase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            _repository.Insert(GetUser(FirstNameTextbox.Text,LastNameTextBox.Text));

            if (Compare(_repository.ReadUser()))
            {
                Response.Redirect("Succses.aspx");
            }
            //else
            //{

            //}
            
        }
        
        private User GetUser(string firstName , string lastName)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;

            return user;
        }

        private bool Compare(User user)
        {
            if (user.FirstName == FirstNameTextbox.Text && user.LastName == LastNameTextBox.Text)
            {
                return true;
            }
            return false;
        }
    }
}