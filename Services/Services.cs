using API_6._0_2.DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace API_6._0_2.Services
{
    public class Services
    {
        private readonly Repositories.TinhRepo Tinh;
        private readonly Repositories.HuyenRepo Huyen;
        private readonly Repositories.XaRepo Xa;
        public Services(EF_DBcontext eF_DBcontext)
        {
            Tinh = new Repositories.TinhRepo(eF_DBcontext);
            Huyen = new Repositories.HuyenRepo(eF_DBcontext);
            Xa = new Repositories.XaRepo(eF_DBcontext);
        }


        //MAX_ID
        public int MaxID(string t)
        {
            if (t == "Tinh") return Tinh.MaxId();
            else if (t == "Huyen") return Huyen.MaxId();
            else if (t == "Xa") return Xa.MaxId();
            return 0;
        }


        //READ
        public object Read(string t, int id)
        {
            if (t == "Tinh") { return Tinh.Read(id); }
            else if (t == "Huyen") { return Huyen.Read(id); }
            else if (t == "Xa") { return Xa.Read(id); }
            else return null;
        }


        //CREATE
        public String Create(Tinh x)
        {

            Tinh.Create(x);
            return "Created";
        }
        public String Create(Huyen x)
        {
            Huyen.Create(x);
            return "Created";
        }
        public String Create(Xa x)
        {
            Xa.Create(x);
            return "Created";
        }

        //UPDATE
        public String Update(Tinh x)
        {
            Tinh.Update(x);
            return "Updated";
        }
        public String Update(Huyen x)
        {
            Huyen.Update(x);
            return "Updated";
        }
        public String Update(Xa x)
        {
            Xa.Update(x);
            return "Updated";
        }

        //DELETE
        public String Delete(string t, int id)
        {
            if (t == "Tinh") { var x = Tinh.Read(id); Tinh.Delete(x); return "Deleted"; }
            else if (t == "Huyen") { var x = Huyen.Read(id); Huyen.Delete(x); return "Deleted"; }
            else if (t == "Xa") { var x = Xa.Read(id); Xa.Delete(x); return "Deleted"; }
            else return null;
        }

        //LAY DANH SACH XA CUA HUYEN
        public Tuple<Huyen, List<Xa>> ComponentOfHuyen(int hid)
        {
            var data1 = Huyen.Read(hid);
            List<Xa> data2 = Huyen.GetXaByHuyenId(hid);
            return Tuple.Create(data1, data2);
        }

        //LAY DANH SCH XA, HUYEN CUA TINH
        public Tuple<Tinh, List<Tuple<Huyen, List<Xa>>>> ComponentOfTinh(int tid)
        {
            
            var data1 = Tinh.Read(tid);
            List<Tuple<Huyen, List<Xa>>> data2 = new List<Tuple<Huyen, List<Xa>>>();
            List<Huyen> data3 = Tinh.GetHuyenByTinhId(tid);
            foreach(Huyen h in data3)
            {
                var data4 = ComponentOfHuyen(h.Hid);
                data2.Add(data4);
            }
            return Tuple.Create(data1,data2);
            }
            
        }
    

 }

