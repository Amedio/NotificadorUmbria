using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificadorMensajesUmbria.Model
{
    public struct Message
    {
        public int ThreadsNumber { get; set; }
        public int MessagesNumber { get; set; }
        public string Game { get; set; }
        public string Type { get; set; }
    }
}
