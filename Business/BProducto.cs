using System;
using System.Collections.Generic;
using Data;
using Entity;

namespace Business
{
    public class BProducto
    {
        private DProducto DProducto = null;

        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                DProducto = new DProducto();
                DProducto.Insertar(producto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(Producto producto)
        {
            bool result = true;
            try
            {
                DProducto = new DProducto();
                DProducto.Actualizar(producto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProducto)
        {
            bool result = true;
            try
            {
                DProducto = new DProducto();
                DProducto.Eliminar(IdProducto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}

