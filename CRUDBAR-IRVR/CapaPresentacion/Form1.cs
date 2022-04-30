using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new();
        private string idProducto;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LeerProds()
        {
            CN_Productos objeto = new();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtEsta.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Inserntar datos
            if(Editar == false)
            {
                try
                {
                    objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                    MessageBox.Show("Registro insertado exitosamente");
                    LeerProds();
                    LimpiarForm();


                }catch(Exception ex)
                {
                    MessageBox.Show("El registro no pudo ser insertado, el error es; " + ex);
                }
            }

            //Actualizar datos
            if (Editar == true)
            {
                try
                {
                    objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, txtid.Text);
                    MessageBox.Show("Registro Se ha actualizado exitosamente");
                    LeerProds();
                    LimpiarForm();

                    Editar = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("El registro no pudo ser Actualizado, el error es; " + ex);
                }
            }


        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;

                txtid.Text = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                

            }
            else
            {
                MessageBox.Show("Favor seleccionar una fila");
            }



        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = txtid.Text;
                objetoCN.EliProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                LeerProds();
            }
            else
            {
                MessageBox.Show("Favor seleccionar una fila");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //idProducto = "idProducto";
            //txtProd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txtDesc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //txtPrec.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //txtExis.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //txtEsta.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            

        }
    }
}