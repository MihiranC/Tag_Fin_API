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
    public  class CustomerService
    {
        private readonly string _adminConnectionString;
        private readonly string _finConnectionString;

        public CustomerService(string adminConnectionString, string finConnectionString)
        {
            _adminConnectionString = adminConnectionString;
            _finConnectionString = finConnectionString;

        }

        public async Task<BaseModel> Select(string code, string firstName, string lastName, string mobileNo, string nicNo, string email, int records)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Records", records, DbType.Int32);
                    para.Add("@Code", code, DbType.String);
                    para.Add("@FirstName", firstName, DbType.String);
                    para.Add("@LastName", lastName, DbType.String);
                    para.Add("@MobileNo", mobileNo, DbType.String);
                    para.Add("@NicNo", nicNo, DbType.String);
                    para.Add("@Email", email, DbType.String);
                    var Customers = await connection.QueryAsync<Customer>("TAG_FIN_SELECT_Customers", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = Customers };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = code };
            }
        }

        public async Task<BaseModel> Insert(Customer data)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(data);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Action", "I", DbType.String);

                    var customer = await connection.QueryAsync<Customer>("[dbo].[TAG_FIN_POPULATE_Customer]", para, commandType: System.Data.CommandType.StoredProcedure);

                    return new BaseModel() { code = "1000", description = "Success", data = customer };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }

        public async Task<BaseModel> Update(UpdateData data)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = data.NewData.GetRawText();
                    string OldJsonData = data.OldData.GetRawText();
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@OldJsonData", OldJsonData, DbType.String);
                    para.Add("@Action", "U", DbType.String);

                    await connection.ExecuteAsync("[dbo].[TAG_FIN_POPULATE_Customer]", para, commandType: System.Data.CommandType.StoredProcedure);

                    return new BaseModel() { code = "1000", description = "Success", data = data };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }

        public async Task<BaseModel> Delete(Customer data)
        {
            try
            {
                using (var connection = new SqlConnection(_adminConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(data);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Action", "D", DbType.String);
                    para.Add("@RoleCode", "", DbType.String);

                    await connection.ExecuteAsync("[dbo].[TAG_FIN_POPULATE_Customer]", para, commandType: System.Data.CommandType.StoredProcedure);

                    return new BaseModel() { code = "1000", description = "Success", data = data };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }
    }
}
