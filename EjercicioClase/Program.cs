using System;

namespace EjercicioClase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.Write("Ingrese el xml");
            string xml = @"<Persona>
                          <Nombre>Carlos</Nombre>
                          <Edad>20</Edad>
                        </Persona>";

            var p = new Persona();
            var superXml = new SuperXML();
            superXml.Desializar(xml, p);
            Console.Write("Edad: " + p.Edad + "\n");
            Console.WriteLine("Nombre: " + p.Nombre);
            string xml2 = @"<Estudiante>
                          <Nombre>Erick</Nombre>
                          <CantidadDeClases>20</CantidadDeClases>
                          <NumeroCuenta>20</NumeroCuenta>
                        </Estudiante>";

            var estudiante = superXml.Desializar<Estudiante>(xml2);
            Console.Write("Numero de Cuenta: " + estudiante.NumeroCuenta + "\n");
            Console.Write("Cantidad de Clases: " + estudiante.CantidadDeClases + "\n");
            Console.Write("Nombre: " + estudiante.Nombre + "\n");
            Console.ReadKey();
        }
    }
}