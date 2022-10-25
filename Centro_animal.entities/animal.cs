namespace Centro_animal.entities
{
    public class animal
    {
        public static int cont = 1;
        public int IDanimal { get; set; }
        public string NombreAnimal { get; set; }
        public double PesoAnimal { get; set; }
        public int Edadanimal { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string raza { get; set; }



        public animal(int iDanimal, string nombreAnimal, double pesoAnimal, int edadanimal, DateTime fechaIngreso,
                string raza)
        {
            iDanimal = cont;
            cont = cont + 1;
            IDanimal = iDanimal;
            NombreAnimal = nombreAnimal;
            PesoAnimal = pesoAnimal;
            Edadanimal = edadanimal;
            this.fechaIngreso = fechaIngreso;
            this.raza = raza;
        }

        public string ToString()
        {
            return
            "Tipo Animal  //  Raza : " + raza + ", IDanimal : " + IDanimal + ", Nombre del Animal : " + NombreAnimal
                    + ", Peso del Animal : " + PesoAnimal + " Kg " + ", Edad del Animal : " + Edadanimal + " Años" + ", fecha de Ingreso : " + fechaIngreso + "\n";
        }

    }
}