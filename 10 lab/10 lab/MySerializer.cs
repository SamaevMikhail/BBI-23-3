using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProtoBuf;

namespace _10_lab
{
    public abstract class MySerializer
    {
        public virtual T ReadPublishHouse<T>(string filePath)
        {
            return default(T);
        }
        public virtual void WritePublishHouse<T>(T obj, string filePath)
        {

        }
    }
    public class MyJsonSerializer : MySerializer
    {
        public override void WritePublishHouse<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
        public override T ReadPublishHouse<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
            return default(T);
        }
    }

    public class MyXmlSerializer : MySerializer
    {

            public override void WritePublishHouse<T>(T obj, string filePath)
            {
                XmlSerializer x = new XmlSerializer(typeof(T));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    x.Serialize(writer, obj);
                }
            }

            public override T ReadPublishHouse<T>(string filePath)
            {
                XmlSerializer x = new XmlSerializer(typeof(T));
                using (TextReader reader = new StreamReader(filePath))
                {
                    return (T)x.Deserialize(reader);
                }
            }

    }
    public class MyBinarySerializer : MySerializer
    {
        public override void WritePublishHouse<T>(T obj, string filePath)
        {
            using (var file = File.Create(filePath))
            {
                Serializer.Serialize<T>(file, obj);
            }
        }
        public override T ReadPublishHouse<T>(string filePath)
        {
            using (var file = File.OpenRead(filePath))
            {
                return Serializer.Deserialize<T>(file);
            }
            return default(T);
        }
    }
}
