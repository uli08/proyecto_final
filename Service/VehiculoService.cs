using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IVehiculoService
    {
        
        IEnumerable<Vehiculos> GetAll();
        bool Add(Vehiculos model);
        bool Delete(int id);
        bool Update(Vehiculos model);
        Vehiculos Get(int id);

    }


    public class VehiculoService : IVehiculoService
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public VehiculoService(ProjectDbContext ProjectDbContext)
        {
            _ProjectDbContext = ProjectDbContext;
        }


        ////////////////////////////////////////////////////////////////////////////////
        /// 

        public IEnumerable<Vehiculos> GetAll()//(Clientes model)
        {
            var result = new List<Vehiculos>();

            try
            {
                result = _ProjectDbContext.Vehiculos.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }


        //////////////////////////////////////////////////////
        public Vehiculos Get(int id)
        {
            var result = new Vehiculos();

            try
            {
                result = _ProjectDbContext.Vehiculos.Single(x => x.VehiculoId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        //////////////////////////////////////////////////
        public bool Add(Vehiculos model)
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
        public bool Update(Vehiculos model)
        {
            try
            {
                var originalModel = _ProjectDbContext.Vehiculos.Single(x => x.VehiculoId == model.VehiculoId);


                originalModel.Modelo = model.Modelo;
                originalModel.Marca = model.Marca;
                originalModel.pieza = model.pieza;                              
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
                _ProjectDbContext.Entry(new Vehiculos { VehiculoId = id }).State = EntityState.Deleted; ;
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
