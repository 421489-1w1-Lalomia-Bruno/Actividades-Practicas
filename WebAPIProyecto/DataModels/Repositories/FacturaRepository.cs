using FacturacionBack.Data.Interfaces;
using FacturacionBack.Domain;
using Microsoft.EntityFrameworkCore;

namespace FacturacionAPI.DataModels.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private FacturacionContext _dbContext;

        public FacturaRepository(FacturacionContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public void SetContext(FacturacionContext dbContext)
        //{
        //    _dbContext=dbContext;
        //}

        public void Delete(int id)
        {
            var facturaDelete = GetById(id);

            if(facturaDelete != null)
            {
                _dbContext.facturas.Remove(facturaDelete);
                _dbContext.SaveChanges();
            }

        }

        public List<factura> GetAll()
        {
            return _dbContext.facturas.ToList();
        }

        public factura? GetById(int id)
        {
            return _dbContext.facturas.Find(id);
        }

        public void Save(factura factura)
        {
            _dbContext.facturas.Add(factura);

            _dbContext.SaveChanges();
        }
    }
}
