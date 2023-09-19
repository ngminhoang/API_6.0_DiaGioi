using API_6._0_2.DBcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_6._0_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaGioi : ControllerBase
    {
        private readonly Services.Services ser;
        public DiaGioi(EF_DBcontext eF_DBcontext)
        {
            ser = new Services.Services(eF_DBcontext);
        }


        // GET
        [HttpGet("Tinh/{tid}")]
        public IActionResult ReadTinh( int tid)
        {
            return Ok(ser.ComponentOfTinh(tid));
        }

        [HttpGet("Huyen/{hid}")]
        public IActionResult ReadHuyen(int hid)
        {
            return Ok(ser.ComponentOfHuyen(hid));
        }

        [HttpGet("Xa/{hid}")]
        public IActionResult ReadXa(int xid)
        {
            return Ok(ser.Read("Xa", xid));
        }


        // POST
        [HttpPost("Tinh")]
        public IActionResult CreateTinh(string tname, string tdes)
        {
            try {

                var data = new Tinh() { Tid= ser.MaxID("Tinh")+1, Tname=tname,Tdes=tdes};
                return Ok(ser.Create(data));
            }
            catch {
                return BadRequest();
            }
        }


        [HttpPost("Tinh/{tid}/Huyen")]
        public IActionResult CreateHuyen(string hname, string hdes, int tid)
        {
            try
            {

                var data = new Huyen() { Hid = ser.MaxID("Huyen") + 1, Hname = hname, Hdes = hdes, Tid= tid, Tinh= (Tinh)ser.Read("Tinh",tid)  };
                return Ok(ser.Create(data));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Huyen/{hid}/Xa")]
        public IActionResult CreateXa(string xname, string xdes, int hid)
        {
            try
            {

                var data = new Xa() { Xid = ser.MaxID("Xa") + 1, Xname = xname, Xdes = xdes, Hid = hid };
                return Ok(ser.Create(data));
            }
            catch
            {
                return BadRequest();
            }
        }

        
        // PUT
        [HttpPut("Tinh/{id}")]
        public IActionResult UpdateTinh(int id,string tname, string tdes)
        {
            try {
                Tinh data = new Tinh() { Tid = id,Tname = tname, Tdes = tdes };
                return Ok(ser.Update(data)); }
            catch(Exception ex) { return  BadRequest(); }
        }
        [HttpPut("Huyen/{id}")]
        public IActionResult UpdateHuyen(int id, string hname, string hdes, int tid)
        {
            try
            {
                Huyen data = new Huyen() { Hid=id,Hname = hname, Hdes = hdes, Tid = tid, Tinh = (Tinh)ser.Read("Tinh",tid) };
                return Ok(ser.Update(data));
            }
            catch (Exception ex) { return BadRequest(); }
        }

        [HttpPut("Xa/{id}")]
        public IActionResult UpdateXa(int id, string xname, string xdes, int hid)
        {
            try
            {
                Xa data = new Xa() { Xid = id, Xname = xname, Xdes = xdes, Hid = hid, Huyen = (Huyen)ser.Read("Huyen", hid) };
                return Ok(ser.Update(data));
            }
            catch (Exception ex) { return BadRequest(); }
        }


        // DELETE
        [HttpDelete("Tinh/{id}")]
        public IActionResult DeleteTinh(int id)
        {
            try {
                return Ok(ser.Delete("Tinh",id));
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpDelete("Huyen/{id}")]
        public IActionResult DeleteHuyen(int id)
        {
            try
            {
                return Ok(ser.Delete("Huyen", id));
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpDelete("Xa/{id}")]
        public IActionResult DeleteXa(int id)
        {
            try
            {
                return Ok(ser.Delete("Xa", id));
            }
            catch (Exception ex) { return BadRequest(); }
        }
    }
}
