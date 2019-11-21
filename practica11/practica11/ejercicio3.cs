using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica11
{
    class ejercicio3
    {
        //Marco René Esquivel Juárez
        //30-oct-2019
        public void ejer3()
        {
            FileStream stream;
            BinaryWriter bWri;
            BinaryReader bRea;
            int anchoR = 20 + 9 + 4 + 16;
            int numR = 0;
            int op;
            try
            {
                stream = new FileStream("ejer3.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bWri = new BinaryWriter(stream);
                bRea = new BinaryReader(stream);
                numR = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoR));
                do
                {
                    Console.Clear();
                    Console.WriteLine("[1]Agregar alumno");
                    Console.WriteLine("[2]Mostrar alumno");
                    Console.WriteLine("[3]Buscar alumno");
                    Console.WriteLine("[4]Salir");
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            try
                            {
                                numR = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoR));
                                bWri.BaseStream.Seek(numR * anchoR, SeekOrigin.Begin);
                                Console.WriteLine("Datos de la persona:");
                                string carnet;
                                do
                                {
                                    Console.WriteLine("Carnet: formato \"2019FG660\" ");
                                    carnet = Console.ReadLine();
                                } while (carnet.Length > 9);
                                Console.Write("Nombre: (20 caracteres max) ");
                                string nombre = Console.ReadLine();
                                if (nombre.Length > 20)
                                {
                                    nombre = nombre.Substring(0, 20);
                                }
                                else
                                {
                                    nombre.PadRight(20, ' ');
                                }
                                Console.Write("Edad:");
                                int edad = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("CUM:");
                                decimal cum = Convert.ToDecimal(Console.ReadLine());
                                bWri.Write(carnet);
                                bWri.Write(nombre);
                                bWri.Write(edad);
                                bWri.Write(cum);
                                Console.WriteLine();
                                Console.WriteLine("Datos almacenados...");
                                Console.ReadKey();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2:
                            try
                            {

                                Console.WriteLine("[1]Todos los alumnos");
                                Console.WriteLine("[2]Por CUM");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                   case 1:
                                        try
                                        {
                                            try
                                            {
                                                numR = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoR));
                                                bWri.BaseStream.Seek(0, SeekOrigin.Begin);
                                                Console.Clear();
                                                Console.WriteLine("Datos:");
                                                Console.WriteLine();
                                                Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                                Console.WriteLine("_________________________________________________________________________________");
                                                int num = 1;

                                                do
                                                {
                                                    string carnet = bRea.ReadString();
                                                    string nombre = bRea.ReadString();
                                                    int edad = bRea.ReadInt32();
                                                    decimal cum = bRea.ReadDecimal();
                                                    Console.Write("{0, -5}", num);
                                                    Console.Write("{0, -10}", carnet);
                                                    Console.Write("{0, -21}", nombre);
                                                    Console.Write("{0, -11}", edad);
                                                    Console.Write("{0}", cum);
                                                    Console.WriteLine();
                                                    bRea.BaseStream.Seek(num * anchoR, SeekOrigin.Begin);
                                                    num++;
                                                } while (true);
                                            }
                                            catch (Exception)
                                            {  
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Presione cualquier tecla para regresar al menu principal");
                                        Console.ReadKey();
                                        break;
                                   case 2:
                                        decimal lim1 = 0, lim2 = 0;
                                        try
                                        {
                                            try
                                            {
                                                
                                                Console.WriteLine("Ingrese el rango de CUM que desea visualizar");
                                                Console.WriteLine("[1] 8.00 - 10.00");
                                                Console.WriteLine("[2] 7.00 - 7.99");
                                                Console.WriteLine("[3] 5.00 - 6.99");
                                                Console.WriteLine("[4] 3.00 - 4.99");
                                                Console.WriteLine("[5] 0.00 - 2.99");
                                                op = Convert.ToInt32(Console.ReadLine());
                                                switch (op)
                                                {
                                                    case 1:
                                                        lim1 = 8.00m;
                                                        lim2 = 10.00m;
                                                        break;
                                                    case 2:
                                                        lim1 = 7.00m;
                                                        lim2 = 7.99m;
                                                        break;
                                                    case 3:
                                                        lim1 = 5.00m;
                                                        lim2 = 6.99m;
                                                        break;
                                                    case 4:
                                                        lim1 = 3.00m;
                                                        lim2 = 4.99m;
                                                        break;
                                                    case 5:
                                                        lim1 = 0.00m;
                                                        lim2 = 2.99m;
                                                        break;
                                                }
                                                numR = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoR));
                                                bWri.BaseStream.Seek(0, SeekOrigin.Begin);
                                                Console.Clear();
                                                Console.WriteLine("Datos:");
                                                Console.WriteLine();
                                                Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                                Console.WriteLine("_________________________________________________________________________________");
                                                int num = 1;

                                                do
                                                {
                                                    
                                                    string carnet = bRea.ReadString();
                                                    string nombre = bRea.ReadString();
                                                    int edad = bRea.ReadInt32();
                                                    decimal cum = bRea.ReadDecimal();
                                                    if (cum > lim1 && cum < lim2)
                                                    {
                                                        Console.Write("{0, -5}", num);
                                                        Console.Write("{0, -10}", carnet);
                                                        Console.Write("{0, -21}", nombre);
                                                        Console.Write("{0, -11}", edad);
                                                        Console.Write("{0}", cum);
                                                        Console.WriteLine(); 
                                                    }
                                                    bRea.BaseStream.Seek(num * anchoR, SeekOrigin.Begin);
                                                    num++;
                                                } while (true);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Presione cualquier tecla para regresar al menu principal");
                                        Console.ReadKey();
                                        break;
                                }  
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine();
                            try
                            {
                                try
                                {
                                    Console.WriteLine("Ingrese el carnet de la persona a consultar");
                                    string c = Console.ReadLine();
                                    bWri.BaseStream.Seek(0, SeekOrigin.Begin);
                                    Console.WriteLine("Datos:");
                                    Console.WriteLine();
                                    Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                    Console.WriteLine("_________________________________________________________________________________");
                                    int num = 1;
                                    do
                                    {
                                        string carnet = bRea.ReadString();
                                        string nombre = bRea.ReadString();
                                        int edad = bRea.ReadInt32();
                                        decimal cum = bRea.ReadDecimal();
                                        if (c == carnet)
                                        {
                                            Console.Write("{0, -5}", num);
                                            Console.Write("{0, -10}", carnet);
                                            Console.Write("{0, -21}", nombre);
                                            Console.Write("{0, -11}", edad);
                                            Console.Write("{0}", cum);
                                            Console.WriteLine();
                                        }
                                        bRea.BaseStream.Seek(num * anchoR, SeekOrigin.Begin);
                                        num++;
                                        Console.ReadKey();
                                    } while (true);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                    }
                } while (op != 4);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
