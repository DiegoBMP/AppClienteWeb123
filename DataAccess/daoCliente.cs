using DataAccess.Contract;
using DataAccess.Repository;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class daoCliente : OracleConexion, IOperacionCrud<ClienteBO>
    {
        public string Actualizar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_1_UPDATE_CLIENTE1", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_CLIENTE", OracleType.Number)).Value = dto.ID_CLIENTE;
                        command.Parameters.Add(new OracleParameter("P_NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                        command.Parameters.Add(new OracleParameter("P_APELLIDOS", OracleType.VarChar)).Value = dto.APELLIDOS;
                        command.Parameters.Add(new OracleParameter("P_RUT", OracleType.VarChar)).Value = dto.RUT;
                        command.Parameters.Add(new OracleParameter("P_CELULAR", OracleType.Number)).Value = dto.CELULAR;
                        command.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        command.Parameters.Add(new OracleParameter("P_CONTRASEÑA", OracleType.VarChar)).Value = dto.CLAVE;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string Eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_1_DELETE_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_CLIENTE", OracleType.Number)).Value = dto;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string Insertar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_1_INSERT_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_CLIENTE", OracleType.Number)).Value = dto.ID_CLIENTE;
                        command.Parameters.Add(new OracleParameter("P_NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                        command.Parameters.Add(new OracleParameter("P_APELLIDOS", OracleType.VarChar)).Value = dto.APELLIDOS;
                        command.Parameters.Add(new OracleParameter("P_RUT", OracleType.VarChar)).Value = dto.RUT;
                        command.Parameters.Add(new OracleParameter("P_CELULAR", OracleType.Number)).Value = dto.CELULAR;
                        command.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        command.Parameters.Add(new OracleParameter("P_CLAVE", OracleType.VarChar)).Value = dto.CLAVE;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result =Convert.ToString( command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ClienteBO> Listar()
        {
            List<ClienteBO> list = new List<ClienteBO>();
            ClienteBO dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_1_SELECT_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new ClienteBO();
                                dto.ID_CLIENTE = Convert.ToInt32(dr["ID_CLIENTE"]);
                                dto.NOMBRES = Convert.ToString(dr["NOMBRES"]);
                                dto.APELLIDOS = Convert.ToString(dr["APELLIDOS"]);
                                dto.RUT = Convert.ToString(dr["RUT"]);
                                dto.CELULAR = Convert.ToInt32(dr["CELULAR"]);
                                dto.CORREO = Convert.ToString(dr["CORREO"]);
                                dto.DIRECCION = Convert.ToString(dr["DIRECCION"]);
                                dto.CLAVE = Convert.ToString(dr["CLAVE"]);
                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error el metodo Listar "+  ex.Message);
            }
            return list;
        }
    }
}
