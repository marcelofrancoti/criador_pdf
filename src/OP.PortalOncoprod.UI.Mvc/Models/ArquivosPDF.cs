using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP.PortalOncoprod.UI.Mvc.Models
{
    public class ArquivosPDF
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "nome")]
        public string nome { get; set; }
    }
}