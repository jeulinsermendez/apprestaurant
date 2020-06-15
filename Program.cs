using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace RestauranteJardiEjercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            String nombreUsuario;
            String numTelefon;
            int mesas;
            int comensales;
            int mesasVacias=0;
            Program myProgram = new Program();
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("D:\\ejemplo\\example.pdf", FileMode.OpenOrCreate)); ;
            document.Open();

            Restaurante myRest = new Restaurante();
            Usuario camarero = null;
            try
            {
                



                //pedimos el nombre de usuario y se lo asignamos a la variable nombreUsuario.
                Console.WriteLine("Dime el nombre de usuario");
                nombreUsuario = Console.ReadLine();
                //pedimos el numero de telefono  y se lo asignamos a la variable numTelefon.

                Console.WriteLine("el numero de telefono");
                numTelefon = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                document.Add(new Paragraph("RESTAURANTE JARDI"));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                //imprimimos por pantalla y por pdf
                camarero = myRest.buscarCamarero(nombreUsuario, numTelefon);
                Console.WriteLine( "NOMBRE: "+camarero.Nombre);
                Console.WriteLine(" " );
                document.Add(new Paragraph("NOMBRE: " + camarero.Nombre));
                document.Add(new Paragraph(" "));
                Console.WriteLine("NOMBRE DE USUARIO: " + camarero.NomUsuario);
                Console.WriteLine(" ");
                document.Add(new Paragraph("NOMBRE DE USUARIO: " + camarero.NomUsuario));
                document.Add(new Paragraph(" "));
                Console.WriteLine("NUMERO TELEFONICO: " + camarero.NumTelefono);
                Console.WriteLine(" ");
                document.Add(new Paragraph("NUMERO TELEFONICO: " + camarero.NumTelefono));
                document.Add(new Paragraph(" "));
                Console.WriteLine("TURNO: " + camarero.Turno);
                Console.WriteLine(" ");
                document.Add(new Paragraph("TURNO: " + camarero.Turno));
                document.Add(new Paragraph(" "));
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                //preguntara el numero de mesas mientras mesas sea menos que cero y mayor que diez
                do
                {
                    mesas = myProgram.escogerMesas();

                    if (mesas < 1 || mesas > 20)
                    {
                        Console.WriteLine("Incorrecto. Introducelo de nuevo");
                    }



                } while (mesas < 1 || mesas > 20);


                //preguntara el numero de comensales mientras comensales sea menos que cero y mayor que 8
                
                
                do
                {
                    comensales = myProgram.escogerComensales();
                    if (comensales < 0 || comensales > 8)
                    {
                        Console.WriteLine("Incorrecto. Introducelo de nuevo");
                    }
                } while (comensales < 0 || comensales > 8);

                Console.WriteLine("Has escogido " + mesas + " mesas y " + comensales + " comensales");

                for (int j = 1; j <= mesas; j++)
                {
                    mesasVacias = myProgram.rellenarComensales(comensales);
                    if (mesasVacias == 0)
                    {
                        Console.WriteLine("La mesa  " + j + " esta vacia");
                        document.Add(new Paragraph("La mesa  " + j + " esta vacia"));
                    }
                    else
                    {
                        Console.WriteLine("En la mesa  " + j + " hay " + mesasVacias + " comensales");
                        document.Add(new Paragraph("En la mesa  " + j + " hay " + mesasVacias + " comensales"));
                    }

                }

                Console.ReadLine();
                Console.WriteLine("¿Quieres generar un pdf? s/n");

                String ask = Console.ReadLine();
                if (ask.ToLower() == "s")
                {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Se ha generado el pdf...");
                    document.Close();
                    string pdfPath = Path.Combine(Application.Pdf, "Restaurante.pdf");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }




            //Programa para encontrar clientes habituales
            try
            {
                



                Boolean esta;

                //pedimos el nombre de usuario y se lo asignamos a la variable nombreUsuario.
                Console.WriteLine("Dime el nombre de usuario");
                nombreUsuario = Console.ReadLine();
                //pedimos el numero de telefono  y se lo asignamos a la variable numTelefon.

                Console.WriteLine("el numero de telefono");
                numTelefon = Console.ReadLine();




                esta = myRest.buscarCliente(nombreUsuario, numTelefon);
                if (esta == false)
                {

                    Console.WriteLine("Lo sentimos, los datos son incorrectos. ");

                }


                else
                {
                    int notaPreguntas=0;
                    int opcion;
                    Console.WriteLine("Datos correcttos.");
                    do
                    {
                        opcion = myProgram.displayMenu();

                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Has esccogido opcion 1");
                                Console.ReadLine();
                                notaPreguntas = myProgram.responderPreguntas();
                                break;
                            case 2:
                                Console.WriteLine("Has esccogido opcion 2");
                                Console.ReadLine();
                                Console.WriteLine("La media de satisfaccion es: "+ notaPreguntas);
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Adios!");
                                Console.ReadLine();
                                break;
                        }
                    } while (opcion != 3);
                    
                }





            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }




        }
        public int escogerMesas()
        {
            int mesas;
            Console.WriteLine("Dime el numero de mesas:");
            mesas = int.Parse(Console.ReadLine());

            return mesas;
        }

        public int escogerComensales()
        {
            int comensales;
            Console.WriteLine("Dime el numero de comensales:");
            comensales = int.Parse(Console.ReadLine());

            return comensales;
        }
        //funcion que escoge un numero aleatoriamente y se lo resta a los comensales. Devuelve el resultado que seran las mesas vacias
        public int rellenarComensales(int comensalesR)
        {

            int num;
            int result;
            Random rnd = new Random();
            num = rnd.Next(1, comensalesR + 1);

            result = comensalesR - num;
            return result;
        }

        //imprimir menu

        public int displayMenu()
        {
            int opcionD;


            Console.WriteLine("ESCOJE UNA RESPUESTA:");
            Console.WriteLine();
            Console.WriteLine("1. Responder a 3 preguntas de satisfaccion.");
            Console.WriteLine("2. Ver la media de su valoracion");
            Console.WriteLine("3. Salir");
            opcionD = int.Parse(Console.ReadLine());

            return opcionD;
        }

        public int responderPreguntas()
        {
            int p1=0;
            int p2 = 0;
            int p3 = 0;
            int resultado;
            Console.WriteLine("Del 1 al 10 dime si te ha resultado interesante nuestra app.");
            p1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Del 1 al 10 dime si cumple tus expectativas.");
            p2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Del 1 al 10 dime si la volverias a usar.");
            p3 = int.Parse(Console.ReadLine());
            resultado = (p1 + p2 + p3) / 3;
            return resultado;
        }

        





    }
}