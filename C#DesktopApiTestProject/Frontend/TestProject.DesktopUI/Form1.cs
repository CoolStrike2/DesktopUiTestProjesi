using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestProject.DesktopUI.Concrete;

namespace TestProject.DesktopUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // var client = new HttpClient();
            // client.BaseAddress = new Uri("http://localhost:5292/");
            // HttpResponseMessage response = await client.GetAsync("api/Staff");
            // string responsebody = await response.Content.ReadAsStringAsync();
            // var options = new JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true
            // };
            //List<Staff> stafflist = JsonConvert.DeserializeObject<List<Staff>>(responsebody);


            // foreach (var staff in stafflist)
            // {
            //     richTextBox1.AppendText($"Staff ID: {staff.StaffID}\n");
            //     richTextBox1.AppendText($"User Name: {staff.UserName}\n");
            //     richTextBox1.AppendText($"Password: {staff.Password}\n");
            //     richTextBox1.AppendText($"Name: {staff.Name}\n");
            //     richTextBox1.AppendText($"Surname: {staff.Surname}\n");
            //     richTextBox1.AppendText($"Title: {staff.Title}\n");
            //     richTextBox1.AppendText($"Email: {staff.Email}\n");
            //     richTextBox1.AppendText($"Tel No: {staff.TelNo}\n");
            //     richTextBox1.AppendText($"Activity: {staff.Activity}\n\n");
            // }

            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5292/");
            AddStaff addStaff = new AddStaff();
            addStaff.UserName = "Test";
            addStaff.Password = "password";
            addStaff.Name = "Test";
            addStaff.Surname = "Test";
            addStaff.Title = "Test";
            addStaff.Email = "email";
            addStaff.TelNo = "1234";
            addStaff.Activity = true;
            var jsondata = JsonConvert.SerializeObject(addStaff);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5292/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("baþarýlý");
            }
        }

        private async void btnList_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5292/");
            HttpResponseMessage response = await client.GetAsync("api/Staff");
            string responsebody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Staff> stafflist = JsonConvert.DeserializeObject<List<Staff>>(responsebody);


            foreach (var staff in stafflist)
            {
                richTextBox1.AppendText($"Staff ID: {staff.StaffID}\n");
                richTextBox1.AppendText($"User Name: {staff.UserName}\n");
                richTextBox1.AppendText($"Password: {staff.Password}\n");
                richTextBox1.AppendText($"Name: {staff.Name}\n");
                richTextBox1.AppendText($"Surname: {staff.Surname}\n");
                richTextBox1.AppendText($"Title: {staff.Title}\n");
                richTextBox1.AppendText($"Email: {staff.Email}\n");
                richTextBox1.AppendText($"Tel No: {staff.TelNo}\n");
                richTextBox1.AppendText($"Activity: {staff.Activity}\n\n");
            }
        }
    }
}
