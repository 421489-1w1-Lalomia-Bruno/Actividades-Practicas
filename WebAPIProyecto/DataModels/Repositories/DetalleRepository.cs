namespace FacturacionAPI.DataModels.Repositories
{
    public class DetalleRepository : IDetalleRepository
    {
        private FacturacionContext _dbContext;

        public DetalleRepository(FacturacionContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public void SetContext(FacturacionContext dbContext)
        //{
        //    _dbContext=dbContext;
        //}

        public void Delete(int id)
        {
            var detalleDelete = GetById(id);

            if (detalleDelete != null)
            {
                _dbContext.detallesFacturas.Remove(detalleDelete);
                _dbContext.SaveChanges();
            }

        }

        public List<detallesFactura> GetAll()
        {
            return _dbContext.detallesFacturas.ToList();
        }

        public detallesFactura? GetById(int id)
        {
            return _dbContext.detallesFacturas.Find(id);
        }

        public void Save(detallesFactura detalle)
        {
            _dbContext.detallesFacturas.Add(detalle);

            _dbContext.SaveChanges();
        }
    }
}
