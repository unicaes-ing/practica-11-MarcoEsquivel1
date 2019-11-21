using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica11
{
    class ejercicio2
    {
        //Marco René Esquivel Juárez
        //30-oct-2019
        public void ejer2()
        {
            
            try
            {
                FileStream stream = new FileStream("practica11-ejercicio1y2.bin", FileMode.Open, FileAccess.Read);
                BinaryReader binario = new BinaryReader(stream);
                string nombre = binario.ReadString();
                string telefono = binario.ReadString();
                string nacimiento = binario.ReadString();
                decimal salario = binario.ReadDecimal();
                stream.Close();
                binario.Close();
                Console.WriteLine("Datos del empleado");
                Console.WriteLine();
                Console.WriteLine("Nombre: {0}", nombre);
                Console.WriteLine("Telefono: {0}", telefono);
                Console.WriteLine("Fecha de Nacimiento: {0}", nacimiento);
                Console.WriteLine("Salario: {0}", salario.ToString("c2"));
                Console.ReadKey();  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
