using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeuTipoRecursivo
{
    public class MinhaLista
    {
        internal class MinhaListaItem
        {
            public int? Valor {get; set;}
            public MinhaListaItem Node { get; set; }
        }

        private MinhaListaItem recursivo { get; set; }

        public MinhaLista()
        {
            recursivo = new MinhaListaItem();
        }

        public void Adicionar (int? valor)
        {
            MinhaListaItem item = recursivo;

            if(item.Valor == null)
            {
                item.Valor = valor;
            }
            else
            {
                while(item.Node != null)
                {
                    item = item.Node;
                }
                item.Node = new MinhaListaItem();
                item.Node.Valor = valor;
            }
        }

         public void Inserir (int posicao, int valor)
        {
            MinhaListaItem novo = new MinhaListaItem();
            novo.Valor = valor;

            MinhaListaItem item = recursivo;
            if(posicao == 0)
            {
                novo.Node = item;
                recursivo = novo;
            }
            else
            {
                int contador = 0;
                posicao -= 1;
                while(contador != posicao)
                {
                    item = item.Node;
                    contador++;
                }
                novo.Node = item.Node;
                item.Node = novo;
            }
            
        }

        public void Alterar (int posicao, int valor)
        {
            MinhaListaItem item = recursivo;
            int contador = 0;
            while(contador != posicao)
            {
                item = item.Node;
                contador++;
            }
            item.Valor = valor;
        }

        public int? Ler (int posicao)
        {
            MinhaListaItem item = recursivo;
            int contador = 0;
            while(contador != posicao)
            {
                item = item.Node;
                contador++;
            }
            return item.Valor;
        }
        public void Remover (int posicao)
        {
            MinhaListaItem item = recursivo;
            if(posicao == 0)
            {
                item.Valor = item.Node.Valor;
                item.Node = item.Node.Node;
            }
            else
            {
                int contador = 0;
                posicao -= 1;
                while(contador != posicao)
                {
                    item = item.Node;
                    contador++;
                }
                item.Node = item.Node.Node;
            }
        }

        public int Tamanho()
        {
            int contador = 0;
            while(recursivo.Node != null)
            {
                recursivo = recursivo.Node;
                contador++;
            }
            return contador + 1;
        }

        public override string ToString()
        {
            MinhaListaItem item = new MinhaListaItem();
            item = recursivo;

            string a ="{ ";
            int tamanho = Tamanho();
            for (int i = 0; i < tamanho; i++)
            {
                a += item.Valor;
                if(item.Node != null)
                {
                    a += ", ";
                    item = item.Node;
                }
            }
            a += " }";
            return a;
        }

        public MinhaLista Filtrar (Func<int?, bool> func)
        {
            MinhaLista novo = new MinhaLista();

            MinhaListaItem item = new MinhaListaItem();
            item = recursivo;

            while(item.Node != null)
            {
                bool resp = func(item.Valor);
                if(resp == true)
                {
                    novo.Adicionar(item.Valor);
                }
                item = item.Node;
            }
            return novo;            
        }
    }
}