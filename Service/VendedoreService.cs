using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IVendedoreService
    {
        
        IEnumerable<Vendedores> GetAll();
        bool Add(Vendedores model);
        bool Delete(int id);
        bool Update(Vendedores model);
        Vendedores Get(int id);

    }

    public class VendedoreService: IVendedoreService
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public VendedoreService(ProjectDbContext ProjectDbContext)
        {
            _ProjectDbContext = ProjectDbContext;
        }


        ////////////////////////////////////////////////////////////////////////////////
        /// 

        public IEnumerable<Vendedores> GetAll()//(Clientes model)
        {
            var result = new List<Vendedores>();

            try
            {
                result = _ProjectDbContext.Vendedores.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }


        //////////////////////////////////////////////////////
        public Vendedores Get(int id)
        {
            var result = new Vendedores();

            try
            {
                result = _ProjectDbContext.Vendedores.Single(x => x.VendedorId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        //////////////////////////////////////////////////
        public bool Add(Vendedores model)
        {
            try
            {
                _ProjectDbContext.Add(model);
                _ProjectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        ///chequear el update en la parte del single
        public bool Update(Vendedores model)
        {
            try
            {
                var originalModel = _ProjectDbContext.Vendedores.Single(x => x.VendedorId == model.VendedorId);


                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
                originalModel.Salario = model.Salario;
                originalModel.Direccion = model.Direccion;
                originalModel.Telefono = model.Telefono;
                originalModel.Fecha = model.Fecha;


                _ProjectDbContext.Update(originalModel);
                _ProjectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        //////////////////////////////////////////////////////
        public bool Delete(int id)
        {
            try
            {
                _ProjectDbContext.Entry(new Vendedores { VendedorId = id }).State = EntityState.Deleted; ;
                _ProjectDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
