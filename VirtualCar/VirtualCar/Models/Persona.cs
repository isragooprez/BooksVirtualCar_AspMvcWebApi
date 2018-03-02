using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualCar.Models
{
    public class Persona
    {

        public int edad;
        public string nombre;

        public Persona(int e, string n)
        {
            this.edad = e;
            this.nombre = n;
        }
    }
}