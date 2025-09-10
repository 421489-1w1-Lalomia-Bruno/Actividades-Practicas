using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Proyecto_Practica01_.Domain;

namespace Proyecto_Practica01_.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.CadenaCoinexionLocal);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteQuery(string sp, List<SpParam>? param = null)
        {
            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                using var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                if (param != null)
                {
                    foreach (SpParam p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Value);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }

            return dt;
        }

        public int ExecuteSpDml(string sp, List<SpParam>? list = null)
        {
            int filasAfectadas = 0;
            _connection.Open();
            var cmd = new SqlCommand(sp, _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (list != null)
            {
                foreach (SpParam param in list)
                {
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
            }

            filasAfectadas = cmd.ExecuteNonQuery();
            _connection.Close();
            return filasAfectadas;
        }

        //public bool ExecuteTransaction(BillDetail billDetail)
        //{
        //    _connection.Open();

        //    SqlTransaction transaction = _connection.BeginTransaction();

        //    var cmd = new SqlCommand("SP_Save_DetailInvoice", _connection, transaction);
        //    cmd.CommandType = CommandType.StoredProcedure;

            
        //    cmd.Parameters.AddWithValue("@idDetalle", billDetail.Id);
        //    cmd.Parameters.AddWithValue("@idArticulo", billDetail.IdProduct);
        //    cmd.Parameters.AddWithValue("@cantidad", billDetail.Amount);

        //    int affectedRows = cmd.ExecuteNonQuery();
        //    if (affectedRows <= 0)
        //    {
        //        transaction.Rollback();
        //        return false;
        //    }
        //    else
        //    {

        //        foreach (Bill b in billDetail.Id)
        //        {
                    
        //            SqlCommand cmdDetalle = new SqlCommand("SP_GUARDAR_INGREDIENTE", _connection, transaction);
        //            cmdDetalle.CommandType = CommandType.StoredProcedure;

        //            int codigoProducto = 1;
                    
        //            cmdDetalle.Parameters.AddWithValue("@codigo_producto", codigoProducto);
        //            cmdDetalle.Parameters.AddWithValue("@nombre", b.Nombre);
        //            cmdDetalle.Parameters.AddWithValue("@cantidad", b.Cantidad);
        //            cmdDetalle.Parameters.AddWithValue("@unidad", b.Unidad);

        //            // - Ejecutar el comando
        //            int affectedRowsDetalle = cmdDetalle.ExecuteNonQuery();

        //            // - Validar el resultado y revertir en caso de que sea necesario
        //            if (affectedRowsDetalle <= 0)
        //            {
        //                transaction.Rollback();
        //                return false;
        //            }
        //        }

        //        // Ya insertamos el maestro y todos sus detalles sin problemas -> COMMIT
        //        // Se confirma la transacción y se retorna true
        //        transaction.Commit();
        //        return true;
        //    }
        //}

        
    }
}
