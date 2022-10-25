using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Centro_animal.entities;
namespace ConsoleCentro_animal 
{
    public class Program
    {
        public static List<centro_adopcion> Refugios = new List<centro_adopcion>();
        public static centro_adopcion cen1;


        static void Main(string[] args)
        {
            int opcion = 0;
            int opcionrefugio = 0;
            int idrefugio = 0;
            int opcionadop = 0;
            int opcionanimal = 0;
            List<animal> listani = new List<animal>();
            List<personal> listape = new List<personal>();
            List<adoptante> listaado = new List<adoptante>();
            Refugios.Add(cen1 = new centro_adopcion(1, "Palmeritas", "AV suares &00", 300, listani, listape, listaado));
            personal personal = new personal(1, "pepe", "nose", 44, "peras", 4444.8);
            Refugios[0].listaPersonal.Add(personal);
            while (opcion != 99)
            {
                opcion = menu();
                switch (opcion)
                {
                    case 1:
                        Refugios.Add(creaCentro());
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Nuevo centro de Refugio Animal creado");
                        break;
                    case 2:
                        idrefugio = menuRefugio();
                        opcionrefugio = menuPersonas();
                        if (opcionrefugio == 1)
                        {
                            Refugios[idrefugio].listaPersonal.Add(creaPersonal());
                            Console.WriteLine("Nuevo Personal Agregado");
                        }
                        if (opcionrefugio == 2)
                        {
                            Refugios[idrefugio].listaAdoptantes.Add(creaAdoptante());
                            Console.WriteLine("Nuevo Adoptante Agregado");
                        }
                        break;
                    case 3:
                        idrefugio = menuRefugio();
                        opcionrefugio = menuAnimales();
                        animal d;
                        if (opcionrefugio == 1)
                        {
                            d = creaMamifero();
                            Refugios[idrefugio].listaanimales.Add(d);
                            Console.WriteLine("Nuevo Animal Agregado al Centro");
                        }
                        if (opcionrefugio == 2)
                        {
                            d = null;
                        }
                        else
                        {
                            d = null;
                        };
                        break;
                    case 4:
                        idrefugio = menuRefugio();
                        opcionrefugio = menuPersonas();
                        if (opcionrefugio == 1)
                        {
                            Console.WriteLine("*****************************************");
                            //  Console.WriteLine(Refugios[idrefugio].listaPersonal.ToString());
                            foreach (personal item in Refugios[idrefugio].listaPersonal)
                            {
                                Console.WriteLine("*****************************************");
                                Console.WriteLine(item.ToString());

                                Console.WriteLine("*****************************************");
                            }
                        }
                        if (opcionrefugio == 2)
                        {
                            Console.WriteLine("*****************************************");
                            // Console.WriteLine(Refugios[idrefugio].listaAdoptantes.ToString());
                            foreach (adoptante item in Refugios[idrefugio].listaAdoptantes)
                            {
                                Console.WriteLine("*****************************************");
                                Console.WriteLine(item.ToString());
                                foreach (animal ani in item.listaanimalesaCargo)
                                {
                                    Console.WriteLine(ani.ToString());
                                }
                                Console.WriteLine("*****************************************");
                            }
                        }
                        break;
                    case 5:
                        mostrarRefugios();
                        break;
                    case 6:
                        idrefugio = menuRefugio();
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("El Refugio Contiene");
                        //Refugios.iterator();
                        // Console.WriteLine(Refugios[idrefugio].listaanimales.ToString());
                        foreach (animal ca in Refugios[idrefugio].listaanimales)
                        {
                            Console.WriteLine("*****************************************");
                            Console.WriteLine(ca.IDanimal + ". Nombre " + ca.NombreAnimal + " Raza " + ca.raza);
                            // ca.Estadoanimal();
                            Console.WriteLine("*****************************************");
                        }
                        break;
                    case 7:
                        animal a;
                        idrefugio = menuRefugio();
                        opcionadop = eleccionAdoptante(Refugios[idrefugio]);
                        opcionanimal = eleccionAnimal(Refugios[idrefugio]);
                        a = Refugios[idrefugio].listaanimales[opcionanimal];
                        Refugios[idrefugio].listaAdoptantes[opcionadop].listaanimalesaCargo.Add(a);
                        Refugios[idrefugio].listaanimales.Remove(a);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Adopcion exitosa");
                        break;
                    case 8:
                        adoptante b;
                        idrefugio = menuRefugio();
                        opcionadop = eleccionAdoptante(Refugios[idrefugio]);
                        b = Refugios[idrefugio].listaAdoptantes[opcionadop];
                        Refugios[idrefugio].listaAdoptantes.Remove(b);
                        Console.WriteLine("Borrado exitoso");
                        break;
                    case 9:
                        personal c;
                        idrefugio = menuRefugio();
                        opcionadop = eleccionPersonal(Refugios[idrefugio]);
                        c = Refugios[idrefugio].listaPersonal[opcionadop];
                        Refugios[idrefugio].listaPersonal.Remove(c);
                        Console.WriteLine("Borrado exitoso");
                        break;
                    case 10:
                        idrefugio = menuRefugio(); ;
                        foreach (animal ca in Refugios[idrefugio].listaanimales)
                        {
                            Console.WriteLine("*****************************************");
                            Console.WriteLine(ca.IDanimal + ". Animal " + ca.NombreAnimal + " Estado :");
                            // ca.Estadoanimal();
                            Console.WriteLine("*****************************************");
                        }
                        break;
                }
            }
        }
        //menu de opciones
        public static int menu()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("Bienvenido al Centro de Adopcion");
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1. Crear Centro de Adopcion");
            Console.WriteLine("2. Agregar Persona ");
            Console.WriteLine("3. Agregar Animal");
            Console.WriteLine("4. Mostrar Personal y Adoptantes");
            Console.WriteLine("5. Mostrar Centros");
            Console.WriteLine("6. Mostrar Animles en adopcion");
            Console.WriteLine("7. Adoptar Animal");
            Console.WriteLine("8. Remover Adoptante");
            Console.WriteLine("9. Remover Personal");
            Console.WriteLine("¿ Que accion desea realizar ?");
            Console.WriteLine("99. Salir");
            Console.WriteLine("*****************************************");
            int opcion = pideint();
            return opcion;
        }

        //generar un Centro
        public static centro_adopcion creaCentro()
        {
            int id;
            string nombre;
            string direccion;
            int capacidad;
            List<animal> listaanimales = new List<animal>();
            List<personal> listaPersonal = new List<personal>();
            List<adoptante> listaAdoptantes = new List<adoptante>();
            Console.WriteLine("Dame nombre del Refugio");
            nombre = pid3string();
            id = 1;
            Console.WriteLine("Dame la direccion del Refugio");
            direccion = pid3string();
            Console.WriteLine("Dame la capacidad del Refugio");
            capacidad = pideint();
            centro_adopcion ca = new centro_adopcion(id, nombre, direccion, capacidad, listaanimales, listaPersonal, listaAdoptantes);
            return ca;
        }


        //muestra los refigios
        public static void mostrarRefugios()
        {
            foreach (centro_adopcion cen in Refugios)
            {
                Console.WriteLine(cen.ToString());
                foreach (personal item in cen.listaPersonal)
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (animal item in cen.listaanimales)
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (adoptante item in cen.listaAdoptantes)
                {
                    Console.WriteLine(item.ToString());
                    foreach (animal iteamani in item.listaanimalesaCargo)
                    {
                        Console.WriteLine(iteamani.ToString());
                    }
                }

            }

        }
        //selecion de refugio
        public static int menuRefugio()
        {
            foreach (centro_adopcion com in Refugios)
            {
                Console.WriteLine(com.idrefugio + "-->" + com.nombrerefugio);
            }
            Console.WriteLine("¿Cual Refugio?");
            int opcion = pideint();

            return opcion - 1;

        }

        //menu de personas para elegir
        public static int menuPersonas()
        {
            int opcion = 0;
            Console.WriteLine("1. Personal");
            Console.WriteLine("2. Adoptante");
            Console.WriteLine("Que tipo de Persona");
            opcion = pideint();
            while (opcion != 1 && opcion != 2)
            {
                Console.WriteLine("Opcion erronea intente de nuevo");
                opcion = pideint();
            }
            return opcion;
        }
        //menu eleccion de animales
        public static int menuAnimales()
        {
            int opcion = 0;
            Console.WriteLine("1. Mamiferio");
            Console.WriteLine("2. salir");
            opcion = pideint();
            while (opcion != 1 && opcion != 2)
            {
                Console.WriteLine("Opcion erronea intente de nuevo");
                opcion = pideint();
            }
            return opcion;
        }
        //elegir adoptante
        public static int eleccionAdoptante(centro_adopcion centro_adopcion)
        {
            int i = 0;
            foreach (adoptante adon in centro_adopcion.listaAdoptantes)
            {
                i = i + 1;
                Console.WriteLine("-Opcion-->" + i + " -->" + adon.nombre);
            }
            Console.WriteLine("¿ Quien sera el Adoptante ?");
            int opcion = pideint();
            return opcion - 1;

        }
        //elegir el personal
        public static int eleccionPersonal(centro_adopcion centro_adopcion)
        {
            int i = 0;
            foreach (personal adon in centro_adopcion.listaPersonal)
            {
                i = i + 1;
                Console.WriteLine("-Opcion-->" + i + " -->" + adon.nombre);
            }
            Console.WriteLine("¿ Quien sera el Empleado ?");
            int opcion = pideint();
            return opcion - 1;
        }

        //elegir animal
        public static int eleccionAnimal(centro_adopcion centro_adopcion)
        {
            int i = 0;
            foreach (animal adon in centro_adopcion.listaanimales)
            {
                i = i + 1;
                Console.WriteLine("-Opcion-->" + i + " -->" + adon.NombreAnimal);
            }
            Console.WriteLine("¿ Quien sera el Animal ?");
            int opcion = pideint();
            return opcion - 1;

        }

        // crear un adoptante
        public static adoptante creaAdoptante()
        {
            int iDpersonal;
            string nombre;
            // String razon;
            string Apellido;
            int edad;
            iDpersonal = 1;
            Console.WriteLine("Dame nombre del Adoptante");
            nombre = pid3string();
            Console.WriteLine("Dame Apellido de Adoptante");
            Apellido = pid3string();
            //  Console.WriteLine("Dame razon de adopcion");
            // razon = pid3string();
            Console.WriteLine("Dame su edad");
            edad = pideint();
            while (edad < 18 || edad < 1 || edad > 99)
            {
                Console.WriteLine("Error en la edad, ingrese la edad correctamente");
                edad = pideint();
            }
            List<animal> listaanimalesaCargo = new List<animal>();
            adoptante ad = new adoptante(iDpersonal, nombre, Apellido, edad, listaanimalesaCargo);
            return ad;
        }

        //agregar personal
        public static personal creaPersonal()
        {
            int iDpersonal;
            string nombre;
            string Apellido;
            int edad;
            string cargo;
            double salario;
            iDpersonal = 1;
            Console.WriteLine("Dame nombre del Personal");
            nombre = pid3string();
            Console.WriteLine("Dame Apellido del Personal");
            Apellido = pid3string();
            Console.WriteLine("Dame su edad");
            edad = pideint();
            while (edad < 18 || edad < 1 || edad > 99)
            {
                Console.WriteLine("Error en la edad, ingrese la edad correctamente");
                edad = pideint();
            }
            Console.WriteLine("Dame su Cargo");
            cargo = pid3string();
            Console.WriteLine("Dame su Salario");
            salario = pidedouble();
            personal pe = new personal(iDpersonal, nombre, Apellido, edad, cargo, salario);
            return pe;
        }
        //crecion de animales
        public static animal creaMamifero()
        {
            int idanimal;
            string nombreanimal;
            string raza;
            double peso;
            int edad;
            int cria1;
            string cria = null;
            idanimal = 1;
            Console.WriteLine("Dame nombre del animal");
            nombreanimal = pid3string();
            Console.WriteLine("Dame el peso del animal (Kg)");
            peso = pidedouble();
            Console.WriteLine("Dame su edad del animal");
            edad = pideint();
            while (edad < 1 || edad > 100)
            {
                Console.WriteLine("Error en la edad, ingrese la edad correctamente");
                edad = pideint();
            }
            Console.WriteLine("puede Tener crias");
            Console.WriteLine("1.Si");
            Console.WriteLine("2.No");
            cria1 = pideint();

            while (cria1 != 1 && cria1 != 2)
            {
                Console.WriteLine("Error en numero, ingrese  correctamente");
                cria1 = pideint();
            }
            if (cria1 == 1)
            {
                cria = "Si";
            }
            if (cria1 == 2)
            {
                cria = "No";
            }
            Console.WriteLine("Dame la Raza del animal");
            raza = pid3string();
            DateTime fecha = DateTime.Now;
            animal ap = new animal(idanimal, nombreanimal, peso, edad, fecha, raza);
            return ap;

        }


        //inputs de caracteres
        public static string pid3string()
        {
            string input = Console.ReadLine();
            return input;
        }
        public static double pidedouble()
        {

            string input = Console.ReadLine();
            double numeros;
            numeros = Convert.ToDouble(input);
            while (numeros < 1)
            {
                Console.WriteLine("Error en numero, ingrese  correctamente");
                numeros = Convert.ToDouble(input);
            }
            return numeros;
        }

        public static int pideint()
        {

            string input = Console.ReadLine();
            int numeros;
            numeros = Convert.ToInt32(input);
            while (numeros < 1)
            {
                Console.WriteLine("Error en numero, ingrese  correctamente");
                numeros = Convert.ToInt32(input);
            }
            return numeros;
        }
    }

}