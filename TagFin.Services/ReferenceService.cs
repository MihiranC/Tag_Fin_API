using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagFin.Domain;
using System.Data.SqlClient;
using Dapper;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TagFin.Domain.CustomClasses;

namespace TagFin.Services
{
    public  class ReferenceService
    {
        private readonly string _adminConnectionString;
        private readonly string _finConnectionString;

        public ReferenceService(string adminConnectionString, string finConnectionString)
        {
            _adminConnectionString = adminConnectionString;
            _finConnectionString = finConnectionString;

        }

        public async Task<BaseModel> SelectProduct(string code)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Code", code, DbType.String);
                    var result = await connection.QueryAsync<Product>("[dbo].[TAG_FIN_SELECT_Product]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = code };
            }
        }

        public async Task<BaseModel> SelectProductWiseChargers(string chargeCode, string productCode)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@ChargeCode", chargeCode, DbType.String);
                    para.Add("@ProductCode", productCode, DbType.String);
                    var result = await connection.QueryAsync<Product>("[dbo].[TAG_FIN_SELECT_ProductWiseChargers]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = productCode };
            }
        }

        public async Task<BaseModel> SelectCalMethdFrequency()
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    var result = await connection.QueryAsync<CalMethdFrequency>("[dbo].[TAG_FIN_SELECT_CalMethodFrequency]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = null };
            }
        }

        public async Task<BaseModel> SelectProductWiseCalMethods()
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    var result = await connection.QueryAsync<ProductWiseCalMethods>("[dbo].[TAG_FIN_SELECT_ProductWiseCalMethods]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = null };
            }
        }
    }
}
