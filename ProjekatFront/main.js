import {Kafic} from "./Kafic.js"


fetch("https://localhost:5001/Kafic/PreuzmiKafice").then(p=>
{
    p.json().then(data=>
        {
           data.forEach(kafic => {
               const Kafic1=new Kafic(kafic.id,kafic.naziv,kafic.x,kafic.y,kafic.kapacitet);
               Kafic1.crtajKafic(document.body);
               kafic.stolovi.forEach(s=>{
                   var sto= Kafic1.stolovi[s.n*Kafic1.x+parseInt(s.m)];
                    
            
                  
                   if(s.maxKapacitet>=s.kapacitet+sto.kapacitet)
                   {
                      sto.popuniSto(s.n,s.m,s.kapacitet, s.n*Kafic1.x + parseInt(s.m));
                      
                   }
               });
               kafic.porudzbine.forEach(p=>{

                var por=Kafic1.porudzbine[p.x*Kafic1.x+parseInt(p.y)];
                 por.azurirajPorudzbinu(p.x*Kafic1.x+parseInt(p.y),p.tip,p.cena,p.redniBroj);
               });
           });
        })

    
});