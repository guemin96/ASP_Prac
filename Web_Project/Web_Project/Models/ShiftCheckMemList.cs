using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Web_Project.Models {
    public class ShiftCheckMemList {
        private SqlConnection con;

        public List<ShiftCheckMember> GetAll() {

            var Today_Date = DateTime.Today;

            var parameters = new DynamicParameters( new {Today_Date});
            return con.Query<ShiftCheckMember>("", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }
    }
}
