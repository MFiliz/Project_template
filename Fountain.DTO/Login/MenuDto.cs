using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.DTO.Login
{
    public class MenuDto
    {

        public MenuDto()
        {
            Roles = new List<string>();
        }

        public List<string> Roles { get; set; }
        public int TicketCount { get; set; }

    }
}
