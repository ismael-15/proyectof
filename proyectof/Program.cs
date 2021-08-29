using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace proyectof
{
    class Program
    {
        static void Main(string[] args)
        {
            //definir la ruta del archivo
            string path = @"C:\proyectof\datos.txt";

            //evaluar si el archivo exite
            if (File.Exists(path))
            {
                Console.WriteLine("El archivo ya existe!");

                //leer el contenido del archivo linea por linea
                String[] lines;
                lines = File.ReadAllLines(path);
                Console.WriteLine("CONTENIDO UTILIZANDO ReadAllLines()");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                //leer el contenido del archivo
                Console.WriteLine("CONTENIDO UTILIZANDO ReadAllText()");
                String content;
                content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            else
            {
                //crear un archivo, y agregar texto
                using (StreamWriter archivo = File.AppendText(path))
                {
                    //contenido del archivo
                    archivo.WriteLine("Programacion Computacional I");
                    archivo.WriteLine("Clase teorica | Stream I/O");
                    archivo.Close();//cierra el archivo creado
                }
            }


            Console.ReadKey();
        }
    }
}



