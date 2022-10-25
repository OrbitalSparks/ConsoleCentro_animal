using Centro_animal.entities;

namespace Centro_animal.entities
{
    public class adoptante : Persona
    {

        // protected string Razon { get; set; }
        public List<animal> listaanimalesaCargo { get; set; }
        public adoptante(int id, string nombre, string apellidos, int edad, List<animal> listaanimalesaCargo) : base(id, nombre, apellidos, edad)
        {
            //Razon = razon;
            this.listaanimalesaCargo = listaanimalesaCargo;
        }







        public String ToString() { return "Adoptante //" + ", ID : " + id + ", Nombre : "
                    + nombre + ", Apellido : " + apellidos + ", Edad : " + edad + " Años" +
                    "lista de Animales a Cargo :" + "\n";}

    }
}




