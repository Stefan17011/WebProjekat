using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
using Models;

namespace ProjekatBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaficController : ControllerBase
    {
        public KaficContext Context { get; set; }

        public KaficController(KaficContext context)
        {
            Context=context;
        }
        [Route("PreuzmiKafice")]
        [HttpGet]
        public async Task< List<Kafic>> PreuzmiKafice()
        {
            return await Context.Kafici.Include(p=>p.Stolovi ).Include(p=>p.Porudzbine).ToListAsync();

        }
        [Route("UpisiKafic")]
        [HttpPost]
        public async Task UpisiVrtove([FromBody] Kafic kafic)
        {
           Context.Kafici.Add(kafic);
           await Context.SaveChangesAsync();

        }
        [Route("IzmeniKafic")]
        [HttpPut]

        public async Task IzmeniKafic([FromBody]Kafic kafic)
        {
            Context.Update<Kafic>(kafic);
            await Context.SaveChangesAsync();


        }
        [Route("IzbrisiKafic/{id}")]
        [HttpDelete]

        public async Task IzbrisiKafic(int id)
        {

           var rest=await Context.Kafici.FindAsync(id);
           Context.Kafici.Remove(rest);
            await Context.SaveChangesAsync();


        }

        [Route("ZauzmiSto{id}")]
        [HttpPost]
        public async Task ZauzmiSto(int id,[FromBody] Sto sto)
        {
           var rest=await Context.Kafici.FindAsync(id);
           sto.Kafic=rest;
           Context.Stolovi.Add(sto);
           
           await Context.SaveChangesAsync();

        }
        [Route("OslobodiSto/{n}/{m}/{id}")]
        [HttpDelete]

        public async Task OslobodiSto(int n,int m,int id)
        {

            var sto=await Context.Stolovi.Where( s=> s.N==n && s.M==m && s.Kafic.ID==id).FirstOrDefaultAsync();
            Context.Stolovi.Remove(sto);
            await Context.SaveChangesAsync();


        }

        
        [Route("IzmeniSto/{n}/{m}/{brLjudi}/{id}") ]
        [HttpPut]

        public async Task IzmeniSto(int n,int m,int brLjudi,int id)
        {
            var sto=await Context.Stolovi.Where( s=> s.N==n && s.M==m && s.Kafic.ID==id).FirstOrDefaultAsync();
                       
            sto.Kapacitet=brLjudi;
            await Context.SaveChangesAsync();


        }

        [Route("DodajPorudzbinu{id}")]
        [HttpPost]
        public async Task DodajPorudzbinu(int id,[FromBody] Porudzbina porudzbina)
        {
           var rest=await Context.Kafici.FindAsync(id);
           porudzbina.Kafic=rest;
           Context.Porudzbine.Add(porudzbina);
           
           await Context.SaveChangesAsync();

        }
        [Route("OtkaziPorudzbinu/{n}/{m}")]
        [HttpDelete]

        public async Task OtkaziPorudzbinu(int n,int m)
        {

           
            var por=await Context.Porudzbine.Where( s=> s.X==n && s.Y==m).FirstOrDefaultAsync();
            Context.Porudzbine.Remove(por);
            await Context.SaveChangesAsync();



        }

       
    }
}
