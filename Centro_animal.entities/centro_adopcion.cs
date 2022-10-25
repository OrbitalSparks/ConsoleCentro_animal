using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Centro_animal.entities;

namespace Centro_animal.entities
{
    public class centro_adopcion
    {
        private static int cont = 1;
        public int idrefugio { get; set; }
        public string nombrerefugio { get; set; }
        public string direccion { get; set; }
        public int capacidad { get; set; }
        public List<animal> listaanimales { get; set; }
        public List<personal> listaPersonal { get; set; }
        public List<adoptante> listaAdoptantes { get; set; }

        public centro_adopcion(int idrefugio, string nombrerefugio, string direccion, int capacidad, List<animal> listaanimales, List<personal> listaPersonal, List<adoptante> listaAdoptantes)
        {
            idrefugio = cont;
            cont = cont + 1;
            this.idrefugio = idrefugio;
            this.nombrerefugio = nombrerefugio;
            this.direccion = direccion;
            this.capacidad = capacidad;
            this.listaanimales = listaanimales;
            this.listaPersonal = listaPersonal;
            this.listaAdoptantes = listaAdoptantes;
        }

        public string ToString()
        {
          return  "Centro de Adopcion // ID del Refugio : " + idrefugio + ", Nombre del Refugio :" + nombrerefugio + ", Direccion : "
                 + direccion + ", Capacidad : " + capacidad + "Animales registrados :" +"\n";
        }


    }





        
}
