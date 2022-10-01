﻿using System;
using System.Windows;
using System.Windows.Controls;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ListaProducto.xaml
    /// </summary>
    public partial class ListaProducto : Window
    {
        public ListaProducto()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
            {
                Cargar();
            }

            private void Cargar()
            {
                BProducto Bproducto = null;
                try
                {
                    Bproducto = new BProducto();
                    dgvProducto.ItemsSource = Bproducto.Listar(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }
                finally
                {
                    Bproducto = null;
                }
            }

            private void BtnNuevo_Click(object sender, RoutedEventArgs e)
            {
                ManProducto manProducto = new ManProducto(0);
                manProducto.ShowDialog();
                Cargar();
            }

            private void DgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                int idProducto;
                var item = (Producto)dgvProducto.SelectedItem;
                if (null == item) return;
                idProducto = Convert.ToInt32(item.IdProducto);

                ManProducto manProducto = new ManProducto(idProducto);
                manProducto.ShowDialog();
                Cargar();
            }


        }
    }
}
