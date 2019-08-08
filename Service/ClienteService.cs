using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IClienteService
    {
        IEnumerable<Clientes> GetAll();
        bool Add(Clientes model);
        bool Delete(int id);
        bool Update(Clientes model);
        Clientes Get(int id);

    }



    public class ClienteService : IClienteService
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public ClienteService(ProjectDbContext ProjectDbContext)
        {
            _ProjectDbContext = ProjectDbContext;
        }

        ////////////////////////////////////////////////////////////////////////////////
        /// 

        public IEnumerable<Clientes> GetAll()//(Clientes model)
        {
            var result = new List<Clientes>();

            try
            {
                result = _ProjectDbContext.Clientes.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

       //////////////////////////////////////////////////////
        public Clientes Get(int id)
        {
            var result = new Clientes();

            try
            {
                result = _ProjectDbContext.Clientes.Single(x => x.ClienteId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        //////////////////////////////////////////////////
        public bool Add(Clientes model)
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
        public bool Update(Clientes model)
        {
            try
            {
                var originalModel = _ProjectDbContext.Clientes.Single(x => x.ClienteId == model.ClienteId);


                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;
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
                _ProjectDbContext.Entry(new Clientes { ClienteId = id }).State = EntityState.Deleted; ;
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
