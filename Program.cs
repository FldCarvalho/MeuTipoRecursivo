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

            // TESTES
            MinhaLista lista = new MinhaLista();
            lista.Adicionar(10);
            lista.Adicionar(20);
            lista.Adicionar(30);
            lista.Adicionar(30);
            lista.Adicionar(40);
            lista.Adicionar(50);

            MinhaLista list = lista.Filtrar(x => x == 30); 
            
            Console.WriteLine(list.ToString());
        }
    }
}
