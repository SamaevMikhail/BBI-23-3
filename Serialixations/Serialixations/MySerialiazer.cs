using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Serializations
{
    public abstract class MySerializer
    {
        public abstract void Write<T>(T obj, string path);
        public abstract T Read<T>(string path);
    }
}
