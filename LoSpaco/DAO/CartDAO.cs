using System;
using System.Collections.Generic;

namespace LoSpacoWebAPi.DAO
{
    public abstract class CartDAO
    {
        private static Database db = new Database();

        public static List<dynamic> GetList(uint id)
        {
            List<dynamic> list = new List<dynamic>();
            db.ReaderRows(db.ReturnCommand($"select itemname, itemtype, ItemQnt, ItemImage, ItemPrice from vw_cart where LoginId='{id}'"), row => list.Add(new { Name = row[0], Type = row[1], Qnt = row[2], Price = row[3], Image = row[4] }));
            return list;
        }
        
        public static List<dynamic> GetCart(uint id)
        {
            List<dynamic> list = new List<dynamic>();
            db.ReaderRows(db.ReturnCommand($"select itemname, ItemQnt, ItemImage, ItemPrice, ItemType from vw_cart where LoginId='{id}'"), row => list.Add(new { Name = row[0], Quantity = row[1], Price = row[3], Image = row[2], ListServicesNames = (string)row[4] == "PACOTE" ?PackageDAO.GetServNameFromPackage(PackageDAO.GetByName((string) row[0]).Id) : null }));
            return list;
        }

        public static object GetTotalPrice(uint id) => db.ReaderValue(db.ReturnProcedure("sp_SelectTotalValueCart", id));
        public static void InsertItem(uint id, string name, byte quantity) => db.ExecuteProcedure("sp_insertItemCart", name, id, quantity);
        public static object[] RemoveItem(uint id, string name) => db.ReaderAllValue(db.ReturnProcedure("sp_RemoveItemCart", id, name));
        public static object[] UpdateQuantity(uint id, string name, byte qty) => db.ReaderAllValue(db.ReturnProcedure("sp_UpdateQntItemCart", id, name, qty));
        public static object GetItemsCount(uint id) => db.ReaderValue(db.ReturnProcedure("sp_CountItemCart", id));
        public static bool IsCartEmpty(uint id) => Convert.ToByte(GetItemsCount(id)) == 0;
        public static byte GetQuantity(uint id, string name) => (byte)db.ReaderValue(db.ReturnCommand($"select itemqnt from vw_cart where loginid='{id}' and itemname = '{name}'"));
    }
}

