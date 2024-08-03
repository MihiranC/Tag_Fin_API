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
using Newtonsoft.Json;

namespace TagFin.Services
{
    public class ApplicationService
    {
        private readonly string _adminConnectionString;
        private readonly string _finConnectionString;

        public ApplicationService(string adminConnectionString, string finConnectionString)
        {
            _adminConnectionString = adminConnectionString;
            _finConnectionString = finConnectionString;
        }

        public async Task<BaseModel> GenerateSchedule(ScheduleInputs data)
        {
            try
            {
                using (var connection = new SqlConnection(_finConnectionString))
                {
                    string JsonCapitalizedCharges = JsonConvert.SerializeObject(data.capitalizedCharges);
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@LoanAmount", data.loanAmount, DbType.String);
                    para.Add("NumberOfMonths", data.numberOfMonths, DbType.String);
                    para.Add("AnnualInterestRate", data.annualInterestRate, DbType.String);
                    para.Add("CapitalizedCharges", JsonCapitalizedCharges, DbType.String);
                    para.Add("IsACapitalizedCharge", data.isACapitalizedCharge, DbType.Boolean);
                    para.Add("CalMethodCode", data.calMethodCode, DbType.String);
                    var result = await connection.QueryAsync<Schedule>("[dbo].[TAG_FIN_GENERATE_Schedule]", para, commandType: System.Data.CommandType.StoredProcedure);
                    return new BaseModel() { code = "1000", description = "Success", data = result };
                }
            }
            catch (Exception ex)
            {
                return new BaseModel() { code = "998", description = ex.Message, data = data };
            }
        }
    }
}
