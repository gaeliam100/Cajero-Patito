

namespace cajero_patito_s.a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cajero patito s.a");
            string usuario = string.Empty;
            string res = string.Empty;
            double tarifa = 17.50;
            double hora;
            double total;
            double dinero;
            double salida;
            do
            {
                Console.Clear();
                var cont5 = 0;
            int cont2 = 0;
            int cont1 = 0;
            int cont50 = 0;
            int cont20 = 0;
            int contm10 = 0;
            int contm5 = 0;
            int contm2 = 0;
            int contm1 = 0;
            int valor = 0;
            int valor1 = 0;
            int valor2 = 0;
            int valor3 = 0;
            int valor4 = 0;
            int valor5 = 0;
            int valor6 = 0;
            int valor7 = 0;


                Console.WriteLine("introduzca su Nombre");
                usuario = Console.ReadLine();
                Console.WriteLine("tarifa por hora 17.50");
                Console.WriteLine("introduzca el numero de horas por pagar");
                hora = Convert.ToDouble(Console.ReadLine());
                total = tarifa * hora;
                Console.WriteLine("el importe total es:" + Math.Round(total));
                Console.WriteLine("entrada de dinero");
                dinero = Convert.ToDouble(Console.ReadLine());
                salida = (dinero - Math.Round(total));
                Console.WriteLine(salida.ToString());
                for (int i = Convert.ToInt32(salida); i >= 500; i -= 500)
                {
                    valor = i%500;
                    cont5++;
                }
                if (valor != 0)
                {
                     for (int i = valor; i >= 200; i -= 200)
                    {
                        valor1 = i % 200;
                        cont2++;
                    }  
                }
                if (valor1 != 0)
                {
                    for (int i = valor1; i >= 100; i -= 100)
                    {
                        valor2 = i % 100;
                        cont1++;
                    }
                }
                if (valor2!=0)
                {
                    for (int i = valor2; i >= 50; i -= 50)
                    {
                        valor3 = i % 50;
                        cont50++;
                    }
                }
                if (valor3 != 0)
                {
                    for (int i = valor3; i >= 20; i -= 20)
                    {
                        valor4 = i % 20;
                        cont20++;
                    }
                }
                if (valor4 != 0)
                {
                    for (int i = valor4; i >= 10; i -= 10)
                    {
                        valor5 = i % 10;
                        contm10++;
                    }

                }
                if (valor5 != 0)
                {
                    for (int i = valor5; i >= 5; i -= 5)
                    {
                        valor6 = i % 5;
                        contm5++;
                    }
                }
                if (valor6 != 0)
                {
                    for (int i = valor6; i >= 2; i -= 2)
                    {
                        valor7 = i % 2;
                        contm2++;
                    }
                }
                if (valor7 != 0)
                {
                    for (int i = valor7; i >= 1; i -= 1)
                    {
                        valor5 = i % 1;
                        contm1++;
                    }
                }

                if ((salida >= 200) && (salida < 500))
                {
                    Console.WriteLine("cambio menor a 500");
                    for (int i = Convert.ToInt32(salida); i >= 200; i -= 200)
                    {
                        valor = i % 200;
                        cont2++;
                    }
                    if ((valor >= 50) && (valor < 100))
                    {
                        for (int i = valor; i >= 50; i -= 50)
                        {
                            valor1 = i % 50;
                            cont50++;
                        }
                        if (valor1 >= 20)
                        {
                            for (int i = valor1; i >= 20; i -= 20)
                            {
                                valor2 = i % 20;
                                cont20++;
                            }
                            if (valor2 >= 10)
                            {
                                for (int i = valor2; i >= 10; i -= 10)
                                {
                                    valor3 = i % 10;
                                    contm10++;
                                }
                                if (valor3 >= 5)
                                {
                                    for (int i = valor3; i >= 5; i -= 5)
                                    {
                                        valor4 = i % 5;
                                        contm5++;
                                    }
                                    for (int i = valor4; i >= 2; i -= 2)
                                    {
                                        valor5 = i % 2;
                                        contm2++;
                                    }
                                    for (int i = valor5; i >= 1; i -= 1)
                                    {
                                        valor6 = i % 1;
                                        contm1++;
                                    }
                                }
                                else if (valor3 < 5)
                                {
                                    for (int i = valor3; i >= 2; i -= 2)
                                    {
                                        valor6 = i % 2;
                                        contm2++;
                                    }
                                    for (int i = valor6; i >= 1; i -= 1)
                                    {
                                        valor7 = i % 1;
                                        contm1++;
                                    }
                                }

                            }
                            else if (valor2 < 10)
                            {
                                for (int i = valor2; i >= 5; i -= 5)
                                {
                                    valor3 = i % 5;
                                    contm5++;
                                }
                                for (int i = valor3; i >= 2; i -= 2)
                                {
                                    valor4 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor4; i >= 1; i -= 1)
                                {
                                    valor5 = i % 1;
                                    contm1++;
                                }
                            }

                        }
                        else if ((valor1 >= 10) && (valor1 < 20))
                        {
                            for (int i = valor1; i >= 10; i -= 10)
                            {
                                valor2 = i % 10;
                                contm10++;
                            }
                            if (valor2 >= 5)
                            {
                                for (int i = valor2; i >= 5; i -= 5)
                                {
                                    valor3 = i % 5;
                                    contm5++;
                                }
                                for (int i = valor3; i >= 2; i -= 2)
                                {
                                    valor4 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor4; i >= 1; i -= 1)
                                {
                                    valor3 = i % 1;
                                    contm1++;
                                }
                            }
                            else if (valor2 < 5)
                            {
                                for (int i = valor2; i >= 2; i -= 2)
                                {
                                    valor3 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor3; i >= 1; i -= 1)
                                {
                                    valor4 = i % 1;
                                    contm1++;
                                }
                            }
                            else if ((valor1 >= 5) && (valor1 < 10))
                            {

                                for (int i = valor1; i >= 5; i -= 5)
                                {
                                    valor2 = i % 5;
                                    contm5++;
                                }
                                for (int i = valor2; i >= 2; i -= 2)
                                {
                                    valor3 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor3; i >= 1; i -= 1)
                                {
                                    valor3 = i % 1;
                                    contm1++;
                                }

                            }

                        }
                        else if (valor1 < 5)
                        {
                            for (int i = valor1; i >= 2; i -= 2)
                            {
                                valor2 = i % 2;
                                contm2++;
                            }
                            for (int i = valor2; i >= 1; i -= 1)
                            {
                                valor3 = i % 1;
                                contm1++;
                            }
                        }

                    }
                    else if (valor > 100)
                    {
                        for (int i = valor; i >= 100; i -= 100)
                        {
                            valor1 = i % 100;
                            cont1++;
                        }
                        if (valor1 > 50)
                        {
                            for (int i = valor1; i >= 50; i -= 50)
                            {
                                valor2 = i % 50;
                                cont2++;
                            }
                            if (valor2 > 20)
                            {

                            }
                            else if (valor2 < 20)
                            {

                            }
                        }
                        else if (valor1 < 50)
                        {

                        }
                    }
                }
                if ((salida >= 100) && (salida <= 200))
                {
                    Console.WriteLine("cambio menor a 200");
                    for (int i = Convert.ToInt32(salida); i >= 100; i -= 100)
                    {
                        valor = i % 100;
                        cont1++;
                    }
                    if (valor >= 50)
                    {
                        for (int i = valor; i >= 50; i -= 50)
                        {
                            valor1 = i % 50;
                            cont50++;
                        }
                        if (valor1 >= 20)
                        {
                            for (int i = valor1; i >= 20; i -= 20)
                            {
                                valor2 = i % 20;
                                cont20++;
                            }
                            if (valor2 >= 10)
                            {
                                for (int i = valor2; i >= 10; i -= 10)
                                {
                                    valor3 = i % 10;
                                    contm10++;
                                }
                                if (valor3 >= 5)
                                {
                                    for (int i = valor3; i >= 5; i -= 5)
                                    {
                                        valor4 = i % 5;
                                        contm5++;
                                    }
                                    for (int i = valor4; i >= 2; i -= 2)
                                    {
                                        valor5 = i % 2;
                                        contm2++;
                                    }
                                    for (int i = valor5; i >= 1; i -= 1)
                                    {
                                        valor6 = i % 1;
                                        contm1++;
                                    }
                                }
                                else if (valor3 < 5)
                                {
                                    for (int i = valor3; i >= 2; i -= 2)
                                    {
                                        valor6 = i % 2;
                                        contm2++;
                                    }
                                    for (int i = valor6; i >= 1; i -= 1)
                                    {
                                        valor7 = i % 1;
                                        contm1++;
                                    }
                                }
                            }
                            else if (valor2 < 10)
                            {
                                for (int i = valor2; i >= 5; i -= 5)
                                {
                                    valor3 = i % 5;
                                    contm5++;
                                }
                                for (int i = valor3; i >= 2; i -= 2)
                                {
                                    valor4 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor4; i >= 1; i -= 1)
                                {
                                    valor5 = i % 1;
                                    contm1++;
                                }

                            }
                        }
                        else if ((valor1 >= 10) && (valor1 < 20))
                        {
                            for (int i = valor1; i >= 10; i -= 10)
                            {
                                valor2 = i % 10;
                                contm10++;
                            }
                            if (valor2 >= 5)
                            {
                                for (int i = valor2; i >= 5; i -= 5)
                                {
                                    valor3 = i % 5;
                                    contm5++;
                                }
                                for (int i = valor3; i >= 2; i -= 2)
                                {
                                    valor4 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor4; i >= 1; i -= 1)
                                {
                                    valor3 = i % 1;
                                    contm1++;
                                }
                            }
                            else if (valor2 < 5)
                            {
                                for (int i = valor2; i >= 2; i -= 2)
                                {
                                    valor3 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor3; i >= 1; i -= 1)
                                {
                                    valor4 = i % 1;
                                    contm1++;
                                }
                            }
                        }
                        else if ((valor1 >= 5) && (valor1 < 10))
                        {
                            for (int i = valor1; i >= 5; i -= 5)
                            {
                                valor2 = i % 5;
                                contm5++;
                            }
                            for (int i = valor2; i >= 2; i -= 2)
                            {
                                valor3 = i % 2;
                                contm2++;
                            }
                            for (int i = valor3; i >= 1; i -= 1)
                            {
                                valor4 = i % 1;
                                contm1++;
                            }
                        }
                        else if (valor1 < 5)
                        {
                            for (int i = valor1; i >= 2; i -= 2)
                            {
                                valor2 = i % 2;
                                contm2++;
                            }
                            for (int i = valor2; i >= 1; i -= 1)
                            {
                                valor3 = i % 1;
                                contm1++;
                            }
                        }
                    }
                    else if (valor < 50)
                    {
                        for (int i = valor; i >= 20; i -= 20)
                        {
                            valor1 = i % 20;
                            cont20++;
                        }
                        if (valor1 >= 10)
                        {
                            for (int i = valor1; i >= 10; i -= 10)
                            {
                                valor1 = i % 10;
                                contm10++;
                            }
                            if (valor1 >= 5)
                            {
                                for (int i = valor1; i >= 5; i -= 5)
                                {
                                    valor2 = i % 5;
                                    contm5++;
                                }
                                if (valor2 == 1)
                                {
                                    for (int i = valor2; i >= 1; i -= 1)
                                    {
                                        valor3 = i % 1;
                                        contm1++;
                                    }
                                }
                                else
                                    for (int i = valor2; i >= 2; i -= 2)
                                    {
                                        valor3 = i % 2;
                                        contm2++;
                                    }
                                for (int i = valor3; i >= 1; i -= 1)
                                {
                                    valor3 = i % 1;
                                    contm1++;
                                }
                            }
                            else if (valor1 < 5)
                            {
                                for (int i = valor1; i >= 2; i -= 2)
                                {
                                    valor2 = i % 2;
                                    contm2++;
                                }
                                for (int i = valor2; i >= 1; i -= 1)
                                {
                                    valor2 = i % 1;
                                    contm1++;
                                }
                            }
                        }

                        else if (valor < 5)
                        {
                            for (int i = valor; i >= 2; i -= 2)
                            {
                                valor1 = i % 2;
                                contm2++;
                            }
                            for (int i = valor1; i >= 1; i -= 1)
                            {
                                valor2 = i % 1;
                                contm1++;
                            }

                        }
                        else if (valor1 < 10)
                        {
                            for (int i = valor1; i >= 5; i -= 5)
                            {
                                valor2 = i % 5;
                                contm5++;
                            }
                            for (int i = valor2; i >= 2; i -= 2)
                            {
                                valor3 = i % 2;
                                contm2++;
                            }
                            for (int i = valor3; i >= 1; i -= 1)
                            {
                                valor4 = i % 1;
                                contm1++;
                            }
                        }
                    }
                }
                if ((salida >= 50) && (salida <= 100))
                {
                    Console.WriteLine("cambio menor a 100");
                    for (int i = Convert.ToInt32(salida); i >= 50; i -= 50)
                    {
                        valor = i % 50;
                        cont50++;
                    }
                    for (int i = valor; i >= 20; i -= 20)
                    {
                        valor1 = i % 20;
                        cont20++;
                    }
                    if (valor1 >= 10)
                    {
                        for (int i = valor1; i >= 10; i -= 10)
                        {
                            valor2 = i % 10;
                            contm10++;
                        }
                        if (valor2 >= 5)
                        {
                            for (int i = valor2; i >= 5; i -= 5)
                            {
                                valor3 = i % 5;
                                contm5++;
                            }
                            for (int i = valor3; i >= 2; i -= 2)
                            {
                                valor4 = i % 2;
                                contm2++;
                            }
                            for (int i = valor4; i >= 1; i -= 1)
                            {
                                valor5 = i % 1;
                                contm1++;
                            }
                        }

                    }
                    if (valor <= 10)
                    {
                        for (int i = valor; i >= 10; i -= 10)
                        {
                            valor1 = i % 10;
                            contm10++;
                        }
                        for (int i = valor1; i >= 5; i -= 5)
                        {
                            valor2 = i % 5;
                            contm5++;
                        }
                        for (int i = valor2; i >= 2; i -= 2)
                        {
                            valor3 = i % 2;
                            contm2++;
                        }
                        for (int i = valor3; i >= 1; i -= 1)
                        {
                            valor4 = i % 1;
                            contm1++;
                        }
                    }

                }
                if ((salida >= 20) && (salida <= 50))
                {
                    Console.WriteLine("cambio menor a 50");
                    for (int i = Convert.ToInt32(salida); i >= 20; i -= 20)
                    {
                        valor = i % 20;
                        cont20++;
                    }
                    if (valor >= 10)
                    {
                        for (int i = valor; i >= 10; i -= 10)
                        {
                            valor1 = i % 10;
                            contm10++;
                        }
                        if (valor1 >= 5)
                        {
                            for (int i = valor1; i >= 5; i -= 5)
                            {
                                valor2 = i % 5;
                                contm5++;
                            }
                            if (valor2 == 1)
                            {
                                for (int i = valor2; i >= 1; i -= 1)
                                {
                                    valor3 = i % 1;
                                    contm1++;
                                }
                            }
                            else
                                for (int i = valor2; i >= 2; i -= 2)
                                {
                                    valor3 = i % 2;
                                    contm2++;
                                }
                            for (int i = valor3; i >= 1; i -= 1)
                            {
                                valor3 = i % 1;
                                contm1++;
                            }
                        }
                        else if (valor < 5)
                        {
                            for (int i = valor; i >= 2; i -= 2)
                            {
                                valor1 = i % 2;
                                contm2++;
                            }
                            for (int i = valor1; i >= 1; i -= 1)
                            {
                                valor2 = i % 1;
                                contm1++;
                            }
                        }
                    }

                    else if (valor < 5)
                    {
                        for (int i = valor; i >= 2; i -= 2)
                        {
                            valor1 = i % 2;
                            contm2++;
                        }
                        for (int i = valor1; i >= 1; i -= 1)
                        {
                            valor2 = i % 1;
                            contm1++;
                        }
                    }
                    if (valor < 10)
                    {
                        for (int i = valor; i >= 5; i -= 5)
                        {
                            valor1 = i % 5;
                            contm5++;
                        }
                        for (int i = valor1; i >= 2; i -= 2)
                        {
                            valor2 = i % 2;
                            contm2++;
                        }
                        for (int i = valor2; i >= 1; i -= 1)
                        {
                            valor3 = i % 1;
                            contm1++;
                        }
                    }

                }
                //no mover nada aunque pienses lo contrario
                if ((salida >= 10) && (salida <= 20))
                {
                    Console.WriteLine("cambio menor a 20");
                    for (int i = Convert.ToInt32(salida); i >= 10; i -= 10)
                    {
                        valor = i % 10;
                        contm10++;
                    }
                    if (valor >= 5)
                    {
                        for (int i = valor; i >= 5; i -= 5)
                        {
                            valor1 = i % 5;
                            contm5++;
                        }
                        for (int i = valor1; i >= 2; i -= 2)
                        {
                            valor2 = i % 2;
                            contm2++;
                        }
                        for (int i = valor2; i >= 1; i -= 1)
                        {
                            valor3 = i % 1;
                            contm1++;
                        }
                    }
                    else if (valor < 5)
                    {
                        for (int i = valor; i >= 2; i -= 2)
                        {
                            valor1 = i % 2;
                            contm2++;
                        }
                        for (int i = valor1; i >= 1; i -= 1)
                        {
                            valor2 = i % 1;
                            contm1++;
                        }
                    }

                }
                if ((salida >= 0) && (salida <= 9))
                {
                    Console.WriteLine("cambio menor a 10");
                    if (salida >= 5)
                    {
                        for (int i = Convert.ToInt32(salida); i >= 5; i -= 5)
                        {
                            valor = i % 5;
                            contm5++;
                        }
                        for (int i = valor; i >= 2; i -= 2)
                        {
                            valor1 = i % 2;
                            contm2++;
                        }
                        for (int i = valor1; i >= 1; i -= 1)
                        {
                            valor2 = i % 1;
                            contm1++;
                        }
                    }
                    else if (salida < 5)
                    {
                        if (salida == 2)
                        {
                            for (int i = Convert.ToInt32(salida); i >= 2; i -= 2)
                            {
                                valor1 = i % 2;
                                contm2++;
                            }
                        }
                        else if (salida == 1)
                        {
                            for (int i = Convert.ToInt32(salida); i >= 1; i -= 1)
                            {
                                valor2 = i % 1;
                                contm1++;
                            }
                        }
                        else if ((3 == salida) || (salida == 4))
                        {
                            for (int i = Convert.ToInt32(salida); i >= 2; i -= 2)
                            {
                                valor1 = i % 2;
                                contm2++;
                            }
                            for (int i = valor1; i >= 1; i -= 1)
                            {
                                valor2 = i % 1;
                                contm1++;
                            }
                        }
                    }
                }


                //****************************************************
                Console.WriteLine("billetes de 500 =" + cont5);
                Console.WriteLine("billetes de 200 =" + cont2);
                Console.WriteLine("billetes de 100 =" + cont1);
                Console.WriteLine("billetes de 50 =" + cont50);
                Console.WriteLine("billetes de 20 =" + cont20);
                Console.WriteLine("monedas de 10 =" + contm10);
                Console.WriteLine("monedas de 5 =" + contm5);
                Console.WriteLine("monedas de  2 =" + contm2);
                Console.WriteLine("monedas de 1 =" + contm1);
                Console.WriteLine("repetir proceso=s");
                res = Console.ReadLine();
               
            } while (res == "s");
            
        }
       

    }
}






