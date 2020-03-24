using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartelera.Helpers
{
    public class AppSettings
    {

        //Propieadedes de JWT token
        public string Site { get; set; }
        public string Audience { get; set; }
        public string ExpireTime { get; set; }
        public string Secret { get; set; }
    }
}
