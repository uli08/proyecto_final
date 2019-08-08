using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IVentaService
    {
        
        IEnumerable<Ventas> GetAll();
        bool Add(Ventas model);
        bool Delete(int id);
        bool Update(Ventas model);
        Ventas Get(int id);

    }




    public class VentaService : IVentaService
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public VentaService(ProjectDbContext ProjectDbContext)
        {
            _ProjectDbContext = ProjectDbContext;
        }

        ////////////////////////////////////////////////////////////////////////////////
        /// 

        public IEnumerable<Ventas> GetAll()//(Clientes model)
        {
            var result = new List<Ventas>();

            try
            {
                result = _ProjectDbContext.Ventas.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

       //////////////////////////////////////////////////////
        public Ventas Get(int id)
        {
            var result = new Ventas();

            try
            {
                result = _ProjectDbContext.Ventas.Single(x => x.VentasId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        //////////////////////////////////////////////////
        public bool Add(Ventas model)
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
        public bool Update(Ventas model)
        {
            try
            {
                var originalModel = _ProjectDbContext.Ventas.Single(x => x.VentasId == model.VentasId);


                originalModel.Pieza = model.Pieza;
                originalModel.Total = model.Total;
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
                _ProjectDbContext.Entry(new Ventas { VentasId = id }).State = EntityState.Deleted; ;
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
