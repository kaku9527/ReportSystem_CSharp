using FPCCTradePointWeb.Models;
using FPCCTradePointWeb.Models.DataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPCCTradePointWeb.Controllers
{
    public class PointReportController : Controller
    {
        private readonly string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

        public List<FPCCTradePoint> GetAllData()
        {
            List<FPCCTradePoint> results = new List<FPCCTradePoint>();
            SqlConnection sqlconn = new SqlConnection(connStr);
            
            string sSQL = "SELECT * FROM FPCCTradePoint ORDER BY TradeDate";

            SqlCommand sqlcmd = new SqlCommand(sSQL, sqlconn);

            sqlconn.Open();
            SqlDataReader sqlReader = sqlcmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    FPCCTradePoint result = new FPCCTradePoint {
                        StoreID = sqlReader.GetString(sqlReader.GetOrdinal("StoreID")),
                        StoreName = sqlReader.GetString(sqlReader.GetOrdinal("StoreName")),
                        TradeType = sqlReader.GetString(sqlReader.GetOrdinal("TradeType")),
                        TradePoint = sqlReader.GetDouble(sqlReader.GetOrdinal("TradePoint")),
                        MemberType = sqlReader.GetString(sqlReader.GetOrdinal("MemberType")),
                        MemberNo = sqlReader.GetString(sqlReader.GetOrdinal("MemberNo")),
                        TradeDate = sqlReader.GetDateTime(sqlReader.GetOrdinal("TradeDate")).ToString("yyyy/MM/dd"),
                        WriteOffNo = sqlReader.GetString(sqlReader.GetOrdinal("WriteOffNo")),
                        iCashDate = sqlReader["iCashDate"] != DBNull.Value ? sqlReader.GetDateTime(sqlReader.GetOrdinal("iCashDate")).ToString("yyyy/MM/dd") : "",
                        PointStatus = sqlReader.GetString(sqlReader.GetOrdinal("PointStatus")),
                        CreateDate = sqlReader.GetDateTime(sqlReader.GetOrdinal("CreateDate")),
                        ModifyDate = sqlReader.GetDateTime(sqlReader.GetOrdinal("ModifyDate"))
                    };

                    results.Add(result);
                }
            }
            sqlconn.Close();

            return results;
        }

        // GET: PointReport
        public ActionResult Index()
        {
            List<FPCCTradePoint> results = GetAllData();
            ViewBag.results = results;
            return View();
        }

        // GET: PointReport/Details
        public ActionResult Details()
        {
            List<FPCCTradePoint> results = GetAllData();

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        // GET: PointReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointReport/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PointReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PointReport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: PointReport/Delete
        [HttpPost]
        public JsonResult Delete(FormCollection postData)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                string TradeDate = postData["TradeDate"];
                responseDTO.httpStatus = "200";
                responseDTO.message = TradeDate;
                return Json(responseDTO);
            }
            catch
            {
                responseDTO.httpStatus = "500";
                responseDTO.message = "Error";
                return Json(responseDTO);
            }
        }
    }
}
