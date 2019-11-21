using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica11
{
    class ejercicio1
    {
        //Marco René Esquivel Juárez
        //30-oct-2019
        public void ejer1()
        {
            try
            {
                FileStream stream = new FileStream("practica11-ejercicio1y2.bin", FileMode.Create, FileAccess.Write);
                Console.WriteLine("Ingrese los datos");
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Telefono:");
                string telefono = Console.ReadLine();
                Console.WriteLine("Fecha de nacimiento: (dd/mm/AA)");
                string nacimiento = Console.ReadLine();
                Console.WriteLine("Salario:");
                decimal salario = Convert.ToDecimal(Console.ReadLine());
                BinaryWriter archivo = new BinaryWriter(stream);
                archivo.Write(nombre);
                archivo.Write(telefono);
                archivo.Write(nacimiento);
                archivo.Write(salario);
                Console.WriteLine("Datos guardados....");
                stream.Close();
                archivo.Close();
                Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
