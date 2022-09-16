using System;
using System.Collections.Generic;
using System.Numerics;

namespace _02_Articles
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

        }
        static void Main(string[] args)
        {
            string[] arrInput;
            Article objArticle;
            int i, nRepeat;

            arrInput = Console.ReadLine().Split(", ");
            objArticle = new Article(arrInput[0], arrInput[1], arrInput[2]);

            nRepeat = int.Parse(Console.ReadLine());    

            for(i = 0; i < nRepeat; i++){
                
                arrInput = Console.ReadLine().Split(": ");

                switch(arrInput[0]){
                    case "Edit":
                        objArticle.Edit(arrInput[1]);
                        break;

                    case "ChangeAuthor":
                        objArticle.ChangeAuthor(arrInput[1]);
                        break;

                    case "Rename":
                        objArticle.Rename(arrInput[1]);
                        break;

                    default:
                        break;
                }

            }

            Console.WriteLine("{0} - {1}: {2}",objArticle.Title, objArticle.Content, objArticle.Author);

        }
    }
}