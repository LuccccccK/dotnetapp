using System;
using System.Data;
using System.Transactions;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace app.Controllers {
    public class DatabaseController : AbstractController {

        public DatabaseController () { }

        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        public IActionResult Insert (CalculateModel Model) {
            try {
                using (TransactionScope ts = new TransactionScope ()) {
                    var connStr = "Server=db_cont;Port=5432;User ID=postgres;Database=sample;Password=postgres;Enlist=true";
                    using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                        conn.Open ();
                        var sql = $@"
                            INSERT INTO project_mst (
                                company_id, 
                                project_name, 
                                create_staff_id, 
                                create_program, 
                                create_timestamp, 
                                update_staff_id, 
                                update_program, 
                                update_timestamp
                            ) VALUES (
                                :companyid,
                                :projectname,
                                :createstaffid,
                                :createprogram,
                                :createtimestamp,
                                :updatestaffid,
                                :updateprogram,
                                :updatetimestamp
                            );
                        ";
                        var cmd = new NpgsqlCommand (sql, conn);
                        cmd.Parameters.Add (new NpgsqlParameter ("companyid", DbType.String) { Value = "cid" });
                        cmd.Parameters.Add (new NpgsqlParameter ("projectname", DbType.String) { Value = "projectname" });
                        cmd.Parameters.Add (new NpgsqlParameter ("createstaffid", DbType.Int32) { Value = 1 });
                        cmd.Parameters.Add (new NpgsqlParameter ("createprogram", DbType.String) { Value = "sampleins" });
                        cmd.Parameters.Add (new NpgsqlParameter ("createtimestamp", DbType.DateTime) { Value = DateTime.Now });
                        cmd.Parameters.Add (new NpgsqlParameter ("updatestaffid", DbType.Int32) { Value = 1 });
                        cmd.Parameters.Add (new NpgsqlParameter ("updateprogram", DbType.String) { Value = "sampleupd" });
                        cmd.Parameters.Add (new NpgsqlParameter ("updatetimestamp", DbType.DateTime) { Value = DateTime.Now });
                        cmd.ExecuteNonQuery ();
                    }
                    ts.Complete ();
                }
                return Json ("success");
            } catch (Exception ex) {
                _logger.Debug (ex.Message);
                _logger.Debug (ex.StackTrace);
                throw ex;
            }
        }
    }
}