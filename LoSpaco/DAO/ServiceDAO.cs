using System;
using System.Collections.Generic;
using  LoSpacoWebAPi.Models;

namespace  LoSpacoWebAPi.DAO {
    public abstract class ServiceDAO {
        private static string GetQuery(int index, string category, int? startPrice, int? endPrice)
        {
            string cat = (category == null || category == "Tudo") ? "" : $"and CategoryId = '{category}'";
            startPrice = startPrice ?? 0;
            endPrice = endPrice ?? 99999;
            string defaultStr = $"select * from vw_services where (ServPrice > {startPrice} and ServPrice < {endPrice}) {cat} order by ServPrice";
            string[] OrderingQueries = { $"{defaultStr}", $"{defaultStr}", $"{defaultStr} desc" };
            return OrderingQueries[index];
        }

        public static List<Service> GetList(int orderIndex, string category, int? sp, int? ep)
        {
            var list = new List<Service>();
            string query = GetQuery(orderIndex, category, sp, ep);
            Database.ReaderRows(Database.ReturnCommand(query), row => {
                decimal? startRating = row[9] != null ? Convert.ToDecimal(row[9] + "") : (decimal?)null;
                list.Add(new Service((ushort)row[0], (string)row[1], (decimal)row[2], (string)row[3], (string)row[4], CategoryDAO.GetById((byte)row[5]),
                     TimeSpan.Parse(row[6].ToString()), (byte[])row[7], (string)row[8], startRating));
            });
            return list;
        }

        public static List<Service> GetList()
        {
            var list = new List<Service>();
            Database.ReaderRows(Database.ReturnCommand("select * from vw_services"), row => {
                decimal? startRating = row[9] != DBNull.Value ? Convert.ToDecimal(row[9] + "") : (decimal?)null;
                list.Add(new Service((ushort)row[0], (string)row[1], (decimal)row[2], (string)row[3], (string)row[4], CategoryDAO.GetById((byte)row[5]),
                     TimeSpan.Parse(row[6].ToString()), (byte[])row[7], (string)row[8], startRating));
            });
            return list;
        }

        public static Service GetById(ushort id)
        {
            object[] row = Database.ReaderRow(Database.ReturnCommand($"select * from vw_services where ServId = '{id}'"));
            decimal? startRating = row[9] != null ? Convert.ToDecimal(row[9] + "") : (decimal?)null;
            Service service = new Service((ushort)row[0], (string)row[1], (decimal)row[2], (string)row[3], (string)row[4], CategoryDAO.GetById((byte)row[5]),
                     TimeSpan.Parse(row[6].ToString()), (byte[])row[7], (string)row[8], startRating);
            return service;
        }

        public static Service GetByName(string name)
        {
            object[] row = Database.ReaderRow(Database.ReturnCommand($"select * from vw_services where ServName = '{name}'"));
            decimal? startRating = row[9] != null ? Convert.ToDecimal(row[9] + "") : (decimal?)null;
            Service service = new Service((ushort)row[0], (string)row[1], (decimal)row[2], (string)row[3], (string)row[4], CategoryDAO.GetById((byte)row[5]),
                     TimeSpan.Parse(row[6].ToString()), (byte[])row[7], (string)row[8], startRating);
            return service;
        }

        public static List<Service> GetByCategoryId(ushort id)
        {
            var list = new List<Service>();

            Database.ReaderRows(Database.ReturnCommand($"select * from vw_services where CategoryId ={id}"), row => {
                decimal? startRating = row[9] != DBNull.Value ? Convert.ToDecimal(row[9] + "") : (decimal?)null;
                list.Add(new Service((ushort)row[0], (string)row[1], (decimal)row[2], (string)row[3], (string)row[4], CategoryDAO.GetById((byte)row[5]),
                     TimeSpan.Parse(row[6].ToString()), (byte[])row[7], (string)row[8], startRating));
            });
            return list;
        }

        public static int GetMaxPrice()
        {
            decimal price = (decimal)Database.ReaderValue(Database.ReturnCommand("select ServPrice from vw_services order by ServPrice desc limit 1;"));
            return (int)Math.Truncate(price) + 5;
        }

        public static int GetMinPrice()
        {
            decimal price = (decimal)Database.ReaderValue(Database.ReturnCommand("select ServPrice from vw_services order by ServPrice limit 1;"));
            return (int)Math.Truncate(price); ;
        }
    }
}