using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calcular_edad
{
    class calcuedad
    {
        private static int edadenaños;
        private static int edadmeses;
        private static int edaddias;
        public int años = 0;

        public  int Edadenaños { get => edadenaños; set => edadenaños = value; }
        public  int Edadmeses { get => edadmeses; set => edadmeses = value; }
        public  int Edaddias { get => edaddias; set => edaddias = value; }

        public calcuedad()
        {
            
        }
        public int edad(int restaaños)
        {
            Edadenaños = restaaños;
            return Edadenaños;
        }

        public int restames(int restameses)
        {
            Edadmeses = restameses;
            return Edadmeses;
        }
        public int restadias(int restadiass)
        {
            Edaddias= restadiass;
            return Edaddias;
        }

    }
}
