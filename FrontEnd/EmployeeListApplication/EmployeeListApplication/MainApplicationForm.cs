using EmployeeListApplication.ServiceModels;
using EmployeeListApplication.Services;
using System.Buffers;

namespace EmployeeListApplication
{
    public partial class MainApplication : Form
    {
        //Constructor
        public MainApplication(IEmployeeServices employeeservice)
        {
            InitializeComponent();
            employeeServices = employeeservice;
        }

        private readonly IEmployeeServices employeeServices;
        private Pagination Pagination;
        private List<EmployeeDisplay> Employees = new List<EmployeeDisplay>();

        //Pagination
        private string SearchValues = "";
        private int Currentpage = 1;
        private int Itemperpage = 20;




        #region Functions
        //Show Employee Modal
        private void ShowEmployeemodal()
        {
            Form ModalBackgorund = new Form();
            using (EmployeeModal modalcontent = new EmployeeModal(employeeServices))
            {
                ModalBackgorund.StartPosition = FormStartPosition.Manual;
                ModalBackgorund.FormBorderStyle = FormBorderStyle.None;
                ModalBackgorund.Opacity = .60d;
                ModalBackgorund.BackColor = Color.Black;
                ModalBackgorund.Bounds = this.Bounds;
                ModalBackgorund.Size = this.Size;
                ModalBackgorund.Location = this.Location;
                ModalBackgorund.ShowInTaskbar = false;
                ModalBackgorund.Show(this);

                modalcontent.Owner = ModalBackgorund;
                modalcontent.StartPosition = FormStartPosition.CenterParent;
                modalcontent.ShowDialog();
                ModalBackgorund.Dispose();
            }
        }
        //Get All Employee
        private async Task GetEmployee()
        {
            Pagination = new Pagination()
            {
                Searchvalue = SearchValues,
                CurrentPage = Currentpage,
                Itemperpage = Itemperpage
            };
            Employees = new List<EmployeeDisplay>();
            Employees = await employeeServices.GetEmployee(Pagination);
        }
        //Populate Datagrid
        private async Task PopulateDatagrid()
        {
            try
            {
                await GetEmployee();

                dataGridView1.Rows.Clear();
                foreach (EmployeeDisplay item in Employees)
                {
                    int rowindex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowindex];
                    row.Cells["IdCol"].Value = item.EmployeeId;
                    row.Cells["FullnameCol"].Value = item.Fullname;
                    row.Cells["EmployeeNumberCol"].Value = item.Employenumber;
                    row.Cells["DateCreatedCol"].Value = item.Datecreated.ToString("MMM/dd/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private async void MainApplication_Load(object sender, EventArgs e)
        {
            await PopulateDatagrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowEmployeemodal();
        }
    }
}
