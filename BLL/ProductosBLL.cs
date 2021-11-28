using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VentasWPF.DAL;
using VentasWPF.Entidades;

namespace VentasWPF.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos Producto)
        {
            if (!Existe(Producto.ProductoId))
                return Insertar(Producto);
            else
                return Modificar(Producto);
        }

        private static bool Insertar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new();

            try
            {
                contexto.Productos.Add(Producto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new();

            try
            {
                //contexto.Database.ExecuteSqlRaw($"Delete From Facturas where ProductoId = {Producto.ProductoId}");

                contexto.Entry(Producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos encontrado;
            Contexto contexto = new();

            try
            {
                encontrado = contexto.Productos.Find(id);
                //encontrado = contexto.Productos.Where(x => x.ProductoId == id)
                //                             .Include(x => x.detalle)
                //                           .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new();

            try
            {
                var producto = ProductosBLL.Buscar(id);

                if(producto != null)
                {
                    contexto.Productos.Remove(producto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            bool esValido = false;
            Contexto contexto = new();

            try
            {
                esValido = contexto.Productos.Any(x => x.ProductoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> Criterio)
        {
            List<Productos> lista = new();
            Contexto contexto = new();

            try
            {
                lista = contexto.Productos.Where(Criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
