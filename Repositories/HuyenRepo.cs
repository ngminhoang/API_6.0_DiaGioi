using API_6._0_2.DBcontext;

namespace API_6._0_2.Repositories
{
    public class HuyenRepo : Repo<Huyen>
    {
        private EF_DBcontext _dbcontext;
        public HuyenRepo(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //HAM LAY TOAN BO DOI TUONG
        public List<Huyen> GetAll()
        {
            try
            {
                List<Huyen> rs = _dbcontext.Huyens.ToList();
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM READ
        public Huyen Read(int id)
        {
            try
            {
                var rs = _dbcontext.Huyens.FirstOrDefault(t => t.Hid == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void Create(Huyen Huyen)
        {
            try
            {
                _dbcontext.Huyens.Add(Huyen);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM UPDATE
        public void Update(Huyen Huyen)
        {
            try
            {
                _dbcontext.Huyens.Update(Huyen);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM DELETE
        public void Delete(Huyen Huyen)
        {
            try
            {
                _dbcontext.Huyens.Remove(Huyen);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int MaxId()
        {
            try
            {
                var maxIdHuyen = _dbcontext.Huyens.OrderByDescending(t => t.Hid).FirstOrDefault();
                if (maxIdHuyen == null) return 0;
                return maxIdHuyen.Hid;
            }
            catch (Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH XA 
        public List<Xa> GetXaByHuyenId(int huyenId)
        {
            var xaList = _dbcontext.Xas
                .Where(h => h.Hid == huyenId)
                .ToList();

            return xaList;
        }
    }
}
