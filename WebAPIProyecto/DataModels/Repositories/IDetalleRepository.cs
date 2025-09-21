namespace FacturacionAPI.DataModels.Repositories
{
    public interface IDetalleRepository
    {
        List<detallesFactura> GetAll();
        detallesFactura GetById(int id);
        void Save(detallesFactura detalle);
        void Delete(int id);
    }
}
