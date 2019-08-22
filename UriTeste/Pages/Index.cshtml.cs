using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UriTeste.Pages
{
    public class IndexModel : PageModel{
        public string Mensagem {get; private set;} = "TESTE";
        public void OnGet()
        {
            
        }
    }
}
