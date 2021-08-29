using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace proyectof
{
    class fileproyectof
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu();
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {

            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevos dato");
            Console.WriteLine("2. Actualizar datos del usuario");
            Console.WriteLine("3. Mostrar listado de usuarios");
            Console.WriteLine("4. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    register();
                    return true;
                case "2":
                    updateData();
                    Console.ReadKey();
                    return true;
                case "3":

                    Console.WriteLine("LISTADO DE usuarios");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return false;
            }
        }


        private static string getPath()
        {
            string path = @"C:\proyectof\datos.txt";
            return path;
        }


        private static void register()
        {

            Console.WriteLine("DATOS DEL USUARIO");
            Console.Write("Nombre y apellido: ");
            string fullname = Console.ReadLine();
            Console.Write("Numero de telefono: ");
            int age = Convert.ToInt32(Console.ReadLine());


            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; {1}", fullname, age);
                sw.Close();
            }
        }


        private static Dictionary<object, object> readFile()
        {

            Dictionary<object, object> listData = new Dictionary<object, object>();


            using (var reader = new StreamReader(getPath()))
            {

                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }


            return listData;
        }


        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

        private static void updateData()
        {

            Console.Write("Escriba el nombre del usuario a actualizar: ");
            var name = Console.ReadLine();


            if (search(name))
            {
                Console.WriteLine("El registro existe!");
                Console.Write("Nuevo nuero de Telefono: ");
                var newAge = Console.ReadLine();


                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newAge;
                Console.WriteLine("El registro ha sido actualizado!");
                File.Delete(getPath());

                using (StreamWriter sw = File.AppendText(getPath()))
                {

                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);

                    }
                }

            }
            else
            {
                Console.WriteLine("El registro no se encontro!");
            }
        }



    }
}







