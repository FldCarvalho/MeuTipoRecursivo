using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeuTipoRecursivo
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // MinhaLista<DateTime> list = new MinhaLista<DateTime>();
                // list.Adicionar(new DateTime(2001, 09, 15));
                // list.Adicionar(new DateTime(2002, 09, 15));
                // list.Adicionar(new DateTime(2003, 09, 15));
                // list.Adicionar(new DateTime(2004, 09, 15));
                MinhaLista<int> list = new MinhaLista<int>();
                list.Adicionar(10);
                list.Adicionar(20);
                list.Adicionar(30);
                list.Adicionar(40);
                Console.WriteLine(list.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
