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
    public class FacturasBLL
    {
        public static bool Guardar(Facturas Factura)
        {
            if (!Existe(Factura.FacturaId))
                return Insertar(Factura);
            else
                return Modificar(Factura);
        }

        private static bool Insertar(Facturas Factura)
        {
            bool paso = false;
            Contexto contexto = new();

            try
            {
                foreach(var detalle in Factura.Detalle)
                {
                    detalle.Producto.Cantidad -= detalle.Unidades;
                    contexto.Entry(detalle.Producto).State = EntityState.Modified;
                }

                contexto.Facturas.Add(Factura);
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

        private static bool Modificar(Facturas Factura)
        {
            bool paso = false;
            Contexto contexto = new();

            try
            {
                var FacturaAnterior = contexto.Facturas.Where(x => x.FacturaId == Factura.FacturaId)
                                                       .Include(x => x.Detalle)
                                                       .ThenInclude(x => x.Producto)
                                                       .AsNoTracking()
                                                       .SingleOrDefault();

                foreach (var detalle in Factura.Detalle)
                {
                    var producto = contexto.Productos.Find(detalle.Producto.ProductoId);
                    producto.Cantidad += detalle.Unidades;
                    detalle.Producto = producto;
                    contexto.Entry(detalle.Producto).State = EntityState.Modified;
                }

                contexto.Database.ExecuteSqlRaw($"Delete From FacturasDetalle where FacturaId = {Factura.FacturaId}");

                foreach(var detalle in Factura.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    var producto = contexto.Productos.Find(detalle.Producto.ProductoId);
                    producto.Cantidad -= detalle.Unidades;
                    detalle.Producto = producto;
                    contexto.Entry(detalle.Producto).State = EntityState.Modified;
                }

                contexto.Entry(Factura).State = EntityState.Modified;
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

        public static Facturas Buscar(int id)
        {
            Facturas encontrado;
            Contexto contexto = new();

            try
            {
                
                encontrado = contexto.Facturas.Where(x => x.FacturaId == id)
                                               .Include(x => x.Detalle)
                                               .ThenInclude(x => x.Producto)
                                               .AsNoTracking()
                                               .SingleOrDefault();
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
                var Factura = FacturasBLL.Buscar(id);

                if (Factura != null)
                {
                    foreach (var detalle in Factura.Detalle)
                    {
                        detalle.Producto.Cantidad += detalle.Unidades;
                        contexto.Entry(detalle.Producto).State = EntityState.Modified;
                    }

                    contexto.Facturas.Remove(Factura);
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
                esValido = contexto.Facturas.Any(x => x.FacturaId == id);
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

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> Criterio)
        {
            List<Facturas> lista = new();
            Contexto contexto = new();

            try
            {
                lista = contexto.Facturas.Where(Criterio).ToList();
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
