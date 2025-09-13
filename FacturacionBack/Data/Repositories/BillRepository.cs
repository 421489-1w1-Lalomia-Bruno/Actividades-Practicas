using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FacturacionBack.Data;
using FacturacionBack.Data.Interfaces;
using FacturacionBack.Domain;

namespace FacturacionBack.Data.Repositories
{
    public class BillRepository : IBillRepository
    {
        public List<Bill> GetAll()
        {
            List<Bill> list = new List<Bill>();

            var dt = DataHelper.GetInstance().ExecuteQuery("SP_GetFacturas");

            foreach (DataRow row in dt.Rows)
            {
                Bill b = new Bill();
                b.Id = (int)row["nro_factura"];
                b.Date = Convert.ToDateTime(row["fecha"]);
                b.IdpaymentForm = (int)row["id_formaPago"];
                list.Add(b);
            }
            return list;
        }

        public Bill GetById(int id)
        {
            List<SpParam> lp = new List<SpParam>();
            {
                lp.Add(new SpParam()
                {
                    Name = @"nro",
                    Value = id
                });

            }
            var dt = DataHelper.GetInstance().ExecuteQuery("sp_GetFacturaById", lp);

            if (dt != null && dt.Rows.Count > 0)
            {
                Bill b = new Bill();
                foreach (DataRow row in dt.Rows)
                {
                    b.Id = (int)row["nro_factura"];
                    b.Date = Convert.ToDateTime(row["fecha"]);
                    b.IdpaymentForm = (int)row["id_formaPago"]; 
                }
                
               return b;
            }

            else
                return null;
        }

        public int Save(Bill bill)
        {
            string sp = "sp_InsertFactura";
            List<SpParam> list = new List<SpParam>();
            if (bill != null)
            {
                {
                    list.Add(new SpParam()
                    {
                        Name = @"id",
                        Value = bill.Id
                    });
                    list.Add(new SpParam()
                    {
                        Name = @"date",
                        Value = bill.Date
                    });
                    
                    list.Add(new SpParam()
                    {
                        Name = @"id_pm",
                        Value = bill.IdpaymentForm
                    });
                    
                }
            }
            int rowact = DataHelper.GetInstance().ExecuteSpDml(sp, list);
            return rowact;
        }
        public int Delete(int id)
        {
            string sp = "sp_DeleteFactura";
                
            List<SpParam> lp = new List<SpParam>();
            {
                lp.Add(new SpParam()
                {
                    Name = @"id",
                    Value = id
                });
            }
            int rowact = DataHelper.GetInstance().ExecuteSpDml(sp, lp);
            return rowact;
        }
    }
}
