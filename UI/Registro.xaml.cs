using P2_AP1_20190266.BLL;
using P2_AP1_20190266.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P2_AP1_20190266.UI
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private Proyecto proyecto = new Proyecto();
        private TipoDeTareas tipotarea = new TipoDeTareas();
        public List<TipoDetalle> Detalle;

        public Registro()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            ProyectoidTextBox.Text = "0";
            Detalle = new List<TipoDetalle>();
            TipodeTareaComboBox.ItemsSource = TipoDeTareaBLL.GetPermisos();
            TipodeTareaComboBox.SelectedValuePath = "Tipoid";
            TipodeTareaComboBox.DisplayMemberPath = "TipodeTarea";

            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectoBLL.Eliminar(Convert.ToInt32(ProyectoidTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Proyecto Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                Limpiar();

            }
            else
            {
                MessageBox.Show("No Fue Posible Eliminar el Proyecto! :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (TipoDataGrid.Items.Count >= 1 && TipoDataGrid.SelectedIndex <= TipoDataGrid.Items.Count - 1)
            {
                proyecto.TipoDetalle.RemoveAt(TipoDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            this.Detalle.Add(new TipoDetalle(
                proyectoid: (int)Convert.ToInt32(ProyectoidTextBox.Text),
                tipotarea: TipodeTareaComboBox.Text,
                requerimiento: RequerimientoTextBox.Text,
                tiempo: (int)Convert.ToInt32(TiempoTextBox.Text)
                )
                );
            Cargar();
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            var encontrado = ProyectoBLL.Buscar(Convert.ToInt32(ProyectoidTextBox.Text));


            if (encontrado != null)
            {
                this.proyecto = encontrado;
                this.Detalle = encontrado.TipoDetalle;

                Cargar();
            }
            else
            {

                this.proyecto = new Proyecto();
                MessageBox.Show("El Proyecto no existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            this.DataContext = this.proyecto;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (!Validar())
                return;
            */
            if (!Validar())
            {
                return;
            }
            //bool paso = ProyectoBLL.Guardar(this.proyecto);
            var paso = ProyectoBLL.Guardar(proyecto);
            if (proyecto.Proyectoid == 0)
            {
                paso = ProyectoBLL.Guardar(proyecto);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ProyectoBLL.Guardar(proyecto);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();

                MessageBox.Show("Transacion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Error al guardar :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Cargar()
        {

            /*this.DataContext = null;
            this.DataContext = proyecto;
            
           this.TipoDataGrid.ItemsSource = null;
            this.TipoDataGrid.ItemsSource = proyecto.TipoDetalle;
            */
            //Viejos
            TipoDataGrid.ItemsSource = null;
            TipoDataGrid.ItemsSource = Detalle;
            proyecto.TipoDetalle = Detalle;

            
        }

        private void Limpiar()
        {
            this.proyecto = new Proyecto();
            this.DataContext = proyecto;
          /*this.R = new Rol();
            this.DataContext = R;
             */
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Proyecto esValido = ProyectoBLL.Buscar(proyecto.Proyectoid);

            return (esValido != null);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (ProyectoidTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor de llenar proyecto id", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor de llenar Descripcion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
    }
}
