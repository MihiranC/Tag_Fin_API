using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagFin.Domain.CustomClasses;
using TagFin.Domain;

namespace TagFin.Services
{
    public class BranchService
    {
        private readonly string _adminConnectionString;
        private readonly string _finConnectionString;

        public BranchService(string adminConnectionString, string finConnectionString)
        {
            _adminConnectionString = adminConnectionString;
            _finConnectionString = finConnectionString;

        }
        public async Task<BaseModel> SelectBranches(string code)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@Code", code, DbType.String);
                    var result = await connection.QueryAsync<Branch>("[dbo].[TAG_FIN_SELECT_Branches]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = code };
            }
        }
    }
}
