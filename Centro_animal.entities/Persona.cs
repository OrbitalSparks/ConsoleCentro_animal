namespace Centro_animal.entities
{
    public class Persona
    {
        public static int cont = 1;
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }

        public Persona(int id, String nombre, String apellidos, int edad)
        {
            id = cont;
            cont = cont + 1;
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }



        public override string? ToString()
        {
            return base.ToString();
        }







        // public string ToString => "Persona // ID : " + id + " Nombre : " + nombre + " Apellidos : " + apellidos + " Edad : " + edad + "\n";
    }
}