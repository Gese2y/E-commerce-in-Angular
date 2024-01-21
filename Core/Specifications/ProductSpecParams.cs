using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public string sort {get; set;}
        private const int MaxPageSize = 50;
        public int PageIndex {get; set;} = 1;
        private int _pagSize = 6;
        public int PageSize
        {
         get => _pagSize;
         set => _pagSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? brandId {get; set;}
        public int? typeId{get;set;}
        
        private string _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}