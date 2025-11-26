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
        private ModalAction ModalAction = new ModalAction();

        //Pagination
        private string SearchValues = "";
        private int Currentpage = 1;
        private int Itemperpage = 20;




        #region Functions
        //Show Employee Modal
        private void ShowEmployeemodal()
        {
            Form ModalBackgorund = new Form();
            using (EmployeeModal modalcontent = new EmployeeModal(employeeServices, ModalAction))
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
        //Get EmployeeInformation
        private async Task<EmployeeInformation> GetEmployeeInfo(Guid EmployeeId)
        {
            EmployeeInformation employeeInformation = new EmployeeInformation();
            try
            {
                employeeInformation = await employeeServices.GetEmployeeInfoById(EmployeeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return employeeInformation;
        }
        //Remove Employee
        private async Task RemoveEmployee()
        {
            List<Guid> employeeIds = new List<Guid>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells["IdCol"].Value != null &&
                    Guid.TryParse(row.Cells["IdCol"].Value.ToString(), out Guid id))
                {
                    employeeIds.Add(id);
                }

            }
            await RemoveAllEmployee(employeeIds);
            await EventHandler.InvokeEmployeeNotifier();
            MessageBox.Show("Successfully Removed", "Ssytem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async Task RemoveAllEmployee(List<Guid> employeeIds)
        {
            try
            {
                foreach (var item in employeeIds)
                {
                    await employeeServices.RemoveEmployee(item);
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion


        private async void MainApplication_Load(object sender, EventArgs e)
        {
            await PopulateDatagrid();
            EventHandler.EmployeeNotifier += async () =>
            {
                await PopulateDatagrid();
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ModalAction = new ModalAction()
            {
                ModalActionName = "Add",
                EmployeeInfo = null,
                EmployeeId = null
            };
            ShowEmployeemodal();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Guid selectedEmployeeId = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["IdCol"].Value.ToString());
                ModalAction = new ModalAction()
                {
                    ModalActionName = "Edit",
                    EmployeeInfo = await GetEmployeeInfo(selectedEmployeeId),
                    EmployeeId = selectedEmployeeId
                };
                ShowEmployeemodal();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
