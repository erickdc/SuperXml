using System;
using System.Reflection;
using System.Xml;

namespace EjercicioClase
{
    public class SuperXML
    {
        public void Desializar(String xml, Object objetoADesializar)
        {
            var doc = new XmlDocument();
            if (xml != null) doc.LoadXml(xml);
            Type pType = objetoADesializar.GetType();

            XmlNode nombreClase = doc.SelectSingleNode(pType.Name);
            FieldInfo[] fields = pType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                string valorDentroTag = nombreClase.SelectSingleNode(fields[i].Name).InnerText;
                string nombreTag = nombreClase.SelectSingleNode(fields[i].Name).LocalName;
                AssignarValorObjeto(objetoADesializar, valorDentroTag, nombreTag, fields, pType);
            }
        }

        public T Desializar<T>(String xml)
        {
            var doc = new XmlDocument();
            if (xml != null) doc.LoadXml(xml);

            var objetoADesializar = Activator.CreateInstance<T>();

            Type pType = objetoADesializar.GetType();

            XmlNode nombreClase = doc.SelectSingleNode(pType.Name);
            FieldInfo[] fields = pType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                string valorDentroTag = nombreClase.SelectSingleNode(fields[i].Name).InnerText;
                string nombreTag = nombreClase.SelectSingleNode(fields[i].Name).LocalName;
                AssignarValorObjeto(objetoADesializar, valorDentroTag, nombreTag, fields, pType);
            }

            return objetoADesializar;
        }

        private void AssignarValorObjeto(object objetoADesializar, object valorDentroTag, string nombreTag,
            FieldInfo[] fields, Type pType)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].Name == nombreTag)
                {
                    if (fields[i].FieldType == typeof(int))
                        pType.GetField(nombreTag).SetValue(objetoADesializar, Int32.Parse((string)valorDentroTag));
                    else
                        pType.GetField(nombreTag).SetValue(objetoADesializar, valorDentroTag);
                }
            }
        }
    }
}