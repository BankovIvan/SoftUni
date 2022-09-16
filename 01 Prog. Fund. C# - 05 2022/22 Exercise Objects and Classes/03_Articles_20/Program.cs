using System;
using System.Collections.Generic;
using System.Numerics;

namespace _03_Articles_20
{
    class Program
    {

        class Article{
            public string Title {get; set;}
            public string Content {get; set;}
            public string Author {get; set;}

            public Article(){

            }

            public Article(string Title, string Content, string Author){
                this.Title = Title;
                this.Content = Content;
                this.Author = Author;                
            }

            public void Edit(string sNewContent){
                this.Content = sNewContent;
            }

            public void ChangeAuthor(string sNewAuthor){
                this.Author = sNewAuthor;
            }

            public void Rename(string sNewName){
                this.Title = sNewName;
            }

            public override string ToString(){
                return this.Title + " - " + this.Content + ": " + this.Author;
            }

        }
        static void Main(string[] args)
        {
            string[] arrInput;
            List<Article> lstArticle = new List<Article>();
            int i, nRepeat;
            
            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++){
                
                arrInput = Console.ReadLine().Split(", ");
                lstArticle.Add(new Article(arrInput[0], arrInput[1], arrInput[2]));

            }

            lstArticle.ForEach(x => Console.WriteLine(x));

            //Console.WriteLine("{0} - {1}: {2}",objArticle.Title, objArticle.Content, objArticle.Author);

        }
    }
}