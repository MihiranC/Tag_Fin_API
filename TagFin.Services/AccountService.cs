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
    public  class AccountService
    {
        private readonly string _adminConnectionString;
        private readonly string _finConnectionString;

        public AccountService(string adminConnectionString, string finConnectionString)
        {
            _adminConnectionString = adminConnectionString;
            _finConnectionString = finConnectionString;

        }

        public async Task<BaseModel> SelectMainAccCategories(string code)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Code", code, DbType.String);
                    var result = await connection.QueryAsync<MainAccCategories>("[dbo].[TAG_FIN_SELECT_MainAccCategories]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = code };
            }
        }

        public async Task<BaseModel> SelectSubAccCategories(int id, string code)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Id", id, DbType.Int32);
                    para.Add("@Code", code, DbType.String);
                    var result = await connection.QueryAsync<SubAccCategories>("[dbo].[TAG_FIN_SELECT_SubAccCategories]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = code };
            }
        }

        public async Task<BaseModel> InsertSubAccCategories(SubAccCategories data)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(data);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Action", "I", DbType.String);
                    para.Add("@OldJsonData", "", DbType.String);

                    var result = await connection.QueryAsync<SubAccCategories>("[dbo].[TAG_FIN_POPULATE_SubAccCategories]", para, commandType: System.Data.CommandType.StoredProcedure);

                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }

        public async Task<BaseModel> UpdateSubAccCategories(UpdateData data)
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

                    await connection.ExecuteAsync("[dbo].[TAG_FIN_POPULATE_SubAccCategories]", para, commandType: System.Data.CommandType.StoredProcedure);

                    return new BaseModel() { code = "1000", description = "Success", data = data };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }

        public async Task<BaseModel> DeleteSubAccCategories(SubAccCategories data)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(data);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Action", "D", DbType.String);
                    para.Add("@OldJsonData", "", DbType.String);

                    await connection.ExecuteAsync("[dbo].[TAG_FIN_POPULATE_SubAccCategories]", para, commandType: System.Data.CommandType.StoredProcedure);

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
