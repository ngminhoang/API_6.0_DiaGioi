using API_6._0_2.DBcontext;

namespace API_6._0_2.Repositories
{
    public class XaRepo: Repo<Xa>
    {
        private EF_DBcontext _dbcontext;
        public XaRepo(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //HAM LAY TOAN BO DOI TUONG
        public List<Xa> GetAll()
        {
            try
            {
                List<Xa> rs = _dbcontext.Xas.ToList();
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM READ
        public Xa Read(int id)
        {
            try
            {
                var rs = _dbcontext.Xas.FirstOrDefault(t => t.Xid == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void Create(Xa Xa)
        {
            try
            {
                _dbcontext.Xas.Add(Xa);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM UPDATE
        public void Update(Xa Xa)
        {
            try
            {
                _dbcontext.Xas.Update(Xa);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM DELETE
        public void Delete(Xa Xa)
        {
            try
            {
                _dbcontext.Xas.Remove(Xa);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int MaxId()
        {
            try { 
            var maxIdXa = _dbcontext.Xas.OrderByDescending(t => t.Xid).FirstOrDefault();
                if (maxIdXa == null) return 0;
                return maxIdXa.Xid; }
            catch (Exception ex) { return 0; }
        }
    }
}
