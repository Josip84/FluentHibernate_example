using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluentHibernate_Example_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NHibernateHelper.CreateSchema();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entities.Employee em = new Entities.Employee();

            em.FirstName = "Pero";
            em.LastName = "Peric";

            Entities.Project proj = new Entities.Project();
            proj.Name = "Test";
            proj.EstimatedHours = 5;

            Entities.Project proj2 = new Entities.Project();
            proj2.Name = "Test 2";
            proj2.EstimatedHours = 10;

            em.Projects.Add(proj);
            em.Projects.Add(proj2);



            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Save(em);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }

        }
    }
}
