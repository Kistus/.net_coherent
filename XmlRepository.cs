using System;
using System.IO;
using System.Xml.Serialization;

namespace LibrarySystem.Repositories
{
    public class XmlRepository<T>
    {
        public void SaveToFile(T data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        public T LoadFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
