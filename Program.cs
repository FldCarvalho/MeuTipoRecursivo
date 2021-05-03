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
                MinhaLista<int> list = new MinhaLista<int>();
                list.Adicionar(10);
                list.Adicionar(20);
                list.Adicionar(30);
                list.Adicionar(40);
                list.Adicionar(50);
                list.Adicionar(60);
                list.Adicionar(70);
                list.Adicionar(80);

                Console.WriteLine(list.ToString());
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
