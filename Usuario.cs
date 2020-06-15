using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteJardiEjercicio
{
    class Usuario
    {
        String nomUsuario;
        String numTelefono;
        String nombre;
        String turno;

        public String NomUsuario
        {
            get { return nomUsuario; }
            set { nomUsuario = value; }
        }

        public String NumTelefono
        {
            get { return numTelefono; }
            set { numTelefono = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        public Usuario()
        {

        }

        public Usuario(String nomUsuarioC, String numTelefonoC, String nombreC, String turnoC)
        {
            nomUsuario = nomUsuarioC;
            numTelefono = numTelefonoC;
            nombre = nombreC;
            turno = turnoC;
        }


    }
}
