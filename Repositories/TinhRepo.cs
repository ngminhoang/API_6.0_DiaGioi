using API_6._0_2.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace API_6._0_2.Repositories
{
    public class TinhRepo : Repo<Tinh>
    {
        private EF_DBcontext _dbcontext;
        public TinhRepo(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //HAM LAY TOAN BO DOI TUONG
        public List<Tinh> GetAll() {
            try
            {
                List<Tinh> rs = _dbcontext.Tinhs.ToList();
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM READ
        public Tinh Read(int id)
        {
            try
            {
                var rs = _dbcontext.Tinhs.FirstOrDefault(t => t.Tid == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void Create(Tinh tinh)
        {
            try
            {
               _dbcontext.Tinhs.Add(tinh);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM UPDATE
        public void Update(Tinh tinh)
        {
            try
            {
                _dbcontext.Tinhs.Update(tinh);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM DELETE
        public void Delete(Tinh tinh)
        {
            try
            {
                _dbcontext.Tinhs.Remove(tinh);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int MaxId()
        {
            try
            {
                var maxIdTinh = _dbcontext.Tinhs.OrderByDescending(t => t.Tid).FirstOrDefault();
                if (maxIdTinh == null) return 0;
                return maxIdTinh.Tid;
            }
            catch(Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH HUYEN
        public List<Huyen> GetHuyenByTinhId(int tinhId)
        {
            var huyenList = _dbcontext.Huyens
                .Where(h => h.Tid == tinhId)
                .ToList();

            return huyenList;
        }
    }
}
