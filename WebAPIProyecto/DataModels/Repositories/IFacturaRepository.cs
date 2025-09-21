using FacturacionBack.Domain;

namespace FacturacionAPI.DataModels.Repositories
{
    public interface IFacturaRepository
    {
        List<factura> GetAll();
        factura GetById(int id);
        void Save(factura factura);
        void  Delete(int id);

    }
}
