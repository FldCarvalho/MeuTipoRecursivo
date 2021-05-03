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
        public int Tamanho
        {
            get
            {
                return TamanhoLista();
            }
        }
        public MinhaLista()
        {
            recursivo = new MinhaListaItem<T>();
        }

        public void Adicionar (T valor)
        {
            MinhaListaItem<T> item = recursivo;
            while(item.Node != null)
            {
               item = item.Node;
            }
            item.Node = new MinhaListaItem<T>();
            item.Node.Valor = valor;
        }

        public void Inserir (int posicao, T valor)
        {
            MinhaListaItem<T> novo = new MinhaListaItem<T>();
            novo.Valor = valor;

            MinhaListaItem<T> item = recursivo;
            int contador = 0;
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
            item.Node.Valor = valor;
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
            return item.Node.Valor;
        }
        public void Remover (int posicao)
        {
            MinhaListaItem<T> item = recursivo;
            int contador = 0;
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

        private int TamanhoLista()
        {
            MinhaListaItem<T> item = recursivo;
            int contador = 0;
            while(item.Node != null)
            {
                item = item.Node;
                contador++;
            }
            return contador;
        }

        public override string ToString()
        {
            MinhaListaItem<T> item = new MinhaListaItem<T>();
            item = recursivo;

            string a ="{ ";
            int tamanho = TamanhoLista();
            for (int i = 0; i < tamanho; i++)
            {
                if(item.Node != null)
                {
                    item = item.Node;
                    a += item.Valor;
                    if(item.Node != null)
                    {
                        a += ", ";
                    }
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

            while(item.Node.Node != null)
            {
                bool resp = func(item.Node.Valor);
                if(resp)
                {
                    novo.Adicionar(item.Node.Valor);
                }
                item = item.Node;
            }
            return novo;            
        }
    }
}