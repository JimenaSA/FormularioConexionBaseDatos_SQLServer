using System;

using System.Windows.Forms;
using ExampleWinForms.Repository;
using ExampleWinForms.Repository.IRepository;

namespace ExampleWinForms
{
    public partial class Form1 : Form
    {
        private readonly CategoriaRepository _repository = new CategoriaRepository();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            RegistrarCategoria();
        }

        #region "Registro de una categoria"

        private void RegistrarCategoria()
        {
            try
            {
                var nombre = txtNombreCategoria.Text.Trim().ToLower();
            
                if (string.IsNullOrEmpty(nombre))
                    MessageBox.Show(@"Error al registrar la categoria", @"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                var result = CreadorCategorias(nombre, _repository);
                
                if (result)
                    MessageBox.Show($@"Categoria {nombre} registrada correctamente", @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(@"Error al registrar la categoria", @"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Error: {e.Message}", @"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool CreadorCategorias(string nombre, ICategoriaRepository repos)
        {
            var result = repos.GuardaCategoria(nombre);
            return result;
        }

        #endregion
    }
}