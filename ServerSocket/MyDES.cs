using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocket
{
    [Serializable]
    public class MyDES
    {
        public byte[] key;
        public byte[] IV;

        public MyDES(byte[] _key, byte[] _IV)
        {
            key = _key;
            IV = _IV;
        }
    }
}
