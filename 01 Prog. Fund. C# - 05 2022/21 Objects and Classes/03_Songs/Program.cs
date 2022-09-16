using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Songs{
        public string TypeList {get; set;}
        public string Name {get; set;}
        public string Time {get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Songs> songs = new List<Songs>();
            int i, N;
            string[] data;    
            Songs song; 
            string typeList;

            N = int.Parse(Console.ReadLine());

            for(i = 0; i < N; i++){
                data = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);

                song = new Songs();
                song.TypeList = data[0];
                song.Name = data[1];
                song.Time=data[2];

                songs.Add(song);

            }

            typeList = Console.ReadLine();

            if(typeList == "all"){
                foreach(Songs _song in songs){
                    Console.WriteLine(_song.Name);
                } 
            }
            else{
                foreach(Songs _song in songs){
                    if(_song.TypeList == typeList) Console.WriteLine(_song.Name);
                } 
            }

        }
    }
}