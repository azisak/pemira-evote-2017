using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemiraClient
{

    class ReceiveResponse
    {
        public bool status;
        public string value;

        public ReceiveResponse(bool s, string v)
        {
            status = s;
            value = v;
        }
    }
}
