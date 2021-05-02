using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeuTipoRecursivo
{
    public class MinhaLista<T>
    {
        internal class MinhaListaItem<I>
        {
            public I Valor {get; set;}
            public MinhaListaItem<I> Node { get; set; }
        }

        private MinhaListaItem<T> recursivo { get; set; }

        public MinhaLista()
        {
            recursivo = new MinhaListaItem<T>();
         
        }

        public void Adicionar (T valor)
        {
            MinhaListaItem<T> item = recursivo;

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
                item.Node = new MinhaListaItem<T>();
                item.Node.Valor = valor;
            }
        }

        public void Inserir (int posicao, T valor)
        {
            MinhaListaItem<T> novo = new MinhaListaItem<T>();
            novo.Valor = valor;

            MinhaListaItem<T> item = recursivo;
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
                    if(item.Node == null)
                    {
                        throw new ArgumentException("O Index deve estar entre os limites da lista. (Parametro 'posicao')");
                    }
                    else
                    {
                        item = item.Node;
                        contador++;
                    }
                }
                novo.Node = item.Node;
                item.Node = novo;
            }
            
        }

        public void Alterar (int posicao, T valor)
        {
            MinhaListaItem<T> item = recursivo;
            int contador = 0;
            while(contador != posicao)
            {
                if(item.Node == null)
                {
                    throw new ArgumentException("O item que você tentou alterar não existe");
                }
                else
                {
                    item = item.Node;
                    contador++;
                }
            }
            item.Valor = valor;
        }

        public T Ler (int posicao)
        {
            MinhaListaItem<T> item = recursivo;
            int contador = 0;
            while(contador != posicao)
            {
                if(item.Node == null)
                {
                    throw new ArgumentException("O item que você tentou ler não existe");
                }
                else
                {
                    item = item.Node;
                    contador++;
                }
            }
            return item.Valor;
        }
        public void Remover (int posicao)
        {
            MinhaListaItem<T> item = recursivo;
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
                    if(item.Node == null)
                    {
                        throw new ArgumentException("O item que você tentou remover não existe");
                    }
                    else
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
            MinhaListaItem<T> item = new MinhaListaItem<T>();
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

        public MinhaLista<T> Filtrar (Func<T, bool> func)
        {
            MinhaLista<T> novo = new MinhaLista<T>();

            MinhaListaItem<T> item = new MinhaListaItem<T>();
            item = recursivo;

            while(item.Node != null)
            {
                bool resp = func(item.Valor);
                if(resp)
                {
                    novo.Adicionar(item.Valor);
                }
                item = item.Node;
            }
            return novo;            
        }
    }
}