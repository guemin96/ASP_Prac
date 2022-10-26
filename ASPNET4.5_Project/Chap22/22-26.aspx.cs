using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap22 {
    public partial class _22_26 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                BindMemberList();
            }
        }
        void BindMemberList() {
            MyDBEntities1 context = new MyDBEntities1();
            GridView1.DataSource = context.Members.ToList();
            GridView1.DataBind();

        }

        protected void btnInsert_Click(object sender, EventArgs e) {
            Member member = new Member();
            member.UserID = Int32.Parse(txtUserID.Text);
            member.Password = txtPassword.Text;
            member.Name=txtName.Text;
            member.Phone = txtPhone.Text;

            MyDBEntities1 context = new MyDBEntities1();
            context.Members.Add(member);
            context.SaveChanges();

            BindMemberList();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) {
            GridView1.EditIndex = e.NewEditIndex;
            BindMemberList();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView1.EditIndex = -1;
            BindMemberList();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            int userID = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            MyDBEntities1 context = new MyDBEntities1();
            Member member = context.Members.Where(x => x.UserID == userID).Single();

            member.Password = e.NewValues["Password"].ToString();
            member.Name = e.NewValues["Name"].ToString();
            member.Phone = e.NewValues["Phone"].ToString();

            context.SaveChanges();
            GridView1.EditIndex = -1;
            BindMemberList();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            int userID = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());

            MyDBEntities1 context = new MyDBEntities1();
            Member member = context.Members.Where(x => x.UserID == userID).Single();
            if (member.Carts.Count() == 0) {
                context.Members.Remove(member);
                context.SaveChanges();

                BindMemberList();
            }
            else {
                Response.Write("Cart에서 해당 Member를 참조하고 있기 때문에 삭제X");
            }

        }
    }
}