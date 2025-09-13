using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionBack.Data.Interfaces;
using FacturacionBack.Domain;
using FacturacionBack.Data;

namespace FacturacionBack.Data.Repositories
{
    public class BillDetailRepository : IBillDetailRepository
    {

        public List<BillDetail> GetAll()
        {
            List<Bill> list = new List<Bill>();
            List<BillDetail> listD = new List<BillDetail>();
            List<Product> listP = new List<Product>();

            var dt = DataHelper.GetInstance().ExecuteQuery("SP_GetDetalleFactura");
            var dtf = DataHelper.GetInstance().ExecuteQuery("SP_GetFacturas");
            var dtp = DataHelper.GetInstance().ExecuteQuery("SP_GetArticulos");


            foreach (DataRow row in dtf.Rows)
            {
                Bill b = new Bill();
                b.Id = (int)row["nro_factura"];
                b.Date = Convert.ToDateTime(row["fecha"]);
                b.IdpaymentForm = (int)row["id_formaPago"];
                list.Add(b);
            }

            foreach (DataRow row in dtp.Rows)
            {
                Product p = new Product();
                p.Name = (string)row["nombre"];
                p.Price = Convert.ToInt32(row["precio"]) ;
                listP.Add(p);
            }

            foreach (DataRow row in dt.Rows)
            {
                BillDetail bd = new BillDetail();
                bd.Id = (int)row["id_detalle"];
                foreach (Bill b in list)
                    if ((int)dt.Rows[0]["nro_factura"] == b.Id)
                        bd.IdBill = list;
                foreach (Product p in listP)
                    if ((string)dt.Rows[0]["nombre"] == p.Name)
                        bd.IdProduct = listP;
                bd.Amount = (int)row["cantidad"];

                listD.Add(bd);
            }
            return listD;
        }

        public BillDetail? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(BillDetail detail)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
