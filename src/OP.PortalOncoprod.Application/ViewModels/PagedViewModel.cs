using System.Collections.Generic;

namespace SistemaIndexador.Application.ViewModels
{
    public class PagedViewModel<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}