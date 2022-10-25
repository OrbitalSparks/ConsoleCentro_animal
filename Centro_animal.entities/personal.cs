namespace Centro_animal.entities
{
    public class personal : Persona
    {
        public string cargo { get; set; }
        public double salario { get; set; }

        public personal(int id, string nombre, string apellidos, int edad, string cargo, double salario) : base(id, nombre, apellidos, edad)
        {

            this.cargo = cargo;
            this.salario = salario;
        }


        public String ToString() { return "Personal // Nombre : " + nombre + " Apellidos : " + apellidos + " Edad : " + edad + " Cargo : " + cargo + " Salario : " + salario + " ID : " + id + "\n";}
    }
}