using System;
using System.Reflection;

namespace InOut.Utils
{
    public static class PacketUtil
    {
        public static byte[] Build<T>(T entity)
        {

            var serializer = new JavaScriptSerializerEx();
            string json = serializer.Serialize(entity);

            return json.GetBytes();
        }

        public static void Parse<T>(byte[] packet, T entity)
        {
            string json = packet.ParseString();
            var serializer = new JavaScriptSerializerEx();
            var obj = serializer.Deserialize<T>(json);
            CopyProperty(entity, obj);
        }

        private static void CopyProperty<T>(T entity, T obj)
        {
            var propretiesInfo = typeof(T).GetProperties(BindingFlags.Public|BindingFlags.Instance);
            foreach (var propertyInfo in propretiesInfo)
            {
                propertyInfo.SetValue(entity, propertyInfo.GetValue(obj));
            }
        }

        public static T Parse<T>(byte[] packet) where T : new()
        {
            try
            {
                string json = packet.ParseString();
                var serializer = new JavaScriptSerializerEx();
                return serializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

    }
}
