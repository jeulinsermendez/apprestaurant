using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteJardiEjercicio
{
    class Restaurante
    {
        //El restaurante tiene una lista de camareros
        List<Usuario> camareros;
        Dictionary<String, String> clientes;

        //Constructor de restaurante donde instanciamos la lista de camareros
        public Restaurante()
        {
            camareros = new List<Usuario>();
            Usuario c1 = new Usuario("luisgg", "655145452", "Luis Garcia Garcia", "mañana");
            Usuario c2 = new Usuario("leynormendez", "682755920", "Leynor Mendez Sena", "tarde");
            Usuario c3 = new Usuario("angelsss", "655143452", "Angel Perez", "mañana");
            Usuario c4 = new Usuario("antoni", "653335452", "Antonio Garcia", "mañana");
            Usuario c5 = new Usuario("migelmmm", "688845452", "Miguel Mendez", "tarde");


            clientes = new Dictionary<string, string>();

            clientes.Add("lnr", "682755920");
            clientes.Add("aaa", "682999920");
            clientes.Add("bbb", "682755777");
            clientes.Add("ccc", "682555920");
            clientes.Add("ddd", "682733320");

            camareros.Add(c1);
            camareros.Add(c2);
            camareros.Add(c3);
            camareros.Add(c4);
            camareros.Add(c5);

        }



        //metodo para agregar camareros
        public void addCamarero(Usuario newCamarero)
        {
            camareros.Add(newCamarero);
        }
        public Usuario buscarCamarero(String nomUsuario, String numTelefono)
        {
            Usuario result = null;

            int i;
            for (i = 0; i < camareros.Count; i++)
            {

                if (camareros[i].NomUsuario == nomUsuario)
                {
                    result = camareros[i];
                }
            }




            return result;


        }

        public Boolean buscarCliente(String nomUsuario, String numTelefono)
        {

            Boolean result = false;
            String contra;
            if (clientes.ContainsKey(nomUsuario))
            {
                contra = clientes[nomUsuario];
                if (contra == numTelefono)
                {
                    result = true;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                    result = false;
                }

            }
            else
            {
                Console.WriteLine("El usuario no existe");
                result = false;

            }

            return result;
        }



    }
}
