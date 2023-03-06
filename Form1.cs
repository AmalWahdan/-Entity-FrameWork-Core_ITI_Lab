using Code_First.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Code_First
{
    public partial class Form1 : Form
    {
        MagazineContext db = new  MagazineContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();

        }


        private void Update()
        {

            News news = db.News.Where(T => T.Id == (int)comboBox1.SelectedValue).SingleOrDefault();
            news.Title = txtTitle.Text;
            news.Bref = txtBref.Text;
            news.AuthorId = (int)comboBox2.SelectedValue;
            db.News.Update(news);
            db.SaveChanges();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

     

        private void Add()
        {

            AddDetails();
            News news = new News();
            news.Title = txtTitle.Text;
            news.Bref = txtBref.Text;
            news.Datetime = DateTime.Now;
            news.AuthorId = (int)comboBox2.SelectedValue;
            news.NewsDetailsId = db.NewsDetails.ToList()[db.NewsDetails.ToList().Count() - 1].Id;
            db.News.Add(news);
            db.SaveChanges();
        }

        private void AddDetails()
        {
            NewsDetails newsDetails = new NewsDetails();
            newsDetails.Desc = txtNewsDetailsDes.Text;
            newsDetails.Refernce = "Referance";
            newsDetails.Pdf = "Pdf Source";
            newsDetails.Photo = "photo path";
            db.NewsDetails.Add(newsDetails);
            db.SaveChanges();
        }


        private void display()
        {
            dataGridView1.DataSource = db.News.ToList();
            comboBox1.DataSource = db.News.ToList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Title";
            comboBox2.DataSource = db.Authors.ToList();
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Add();
            display();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Update();
            display();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtTitle.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtBref.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.SelectedValue = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
            comboBox1.SelectedValue = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

                News news = db.News.Where(T => T.Id == (int)comboBox1.SelectedValue).SingleOrDefault();
                db.News.Remove(news);
                db.SaveChanges();
                display();
        
        }
    }
}