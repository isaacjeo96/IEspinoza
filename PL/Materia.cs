using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {
            // ingresar los datos del producto 
            ML.Materia materia = new ML.Materia();//instancia 

            Console.WriteLine("Ingresa el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion de la materia");
            materia.Descripcion = Console.ReadLine();

            ML.Result result = BL.Materia.Add(materia); //query

            if (result.Correct)
            {
                Console.WriteLine("Materia ingresada correctamente");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Materia " + result.ErrorMessage);
                Console.ReadLine();
            }
        }//agregar productos 
    }
}
