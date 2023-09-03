using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AddrDtoResponse
    {
        public int Id { get; set; }
        public string StrtAddr { get;   set; } = null!;

        public string City { get;   set; } = null!;

        public string Cntry { get;   set; } = null!;

        public string? ZipCode { get;   set; }
    }
}
