namespace _09_Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        private string name;
        private int badges;

        public string Name { get { return name; } set { name = value; } }
        public int Badges { get { return badges; } set { badges = value; } }

        public List<Pokemon> Pokemons { get; set; }  

        public Trainer()
        {
            this.Name = null;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public Trainer(string name) : this()
        {
            this.Name = name;
        }

        public Trainer(string trainerName, string pokemonName, string pokemonElement, int pokemonHealth) : this(trainerName)
        {
            this.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }

        public void AddPokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }

        public void Tournament(string pokemonElement)
        {
            foreach(var v in Pokemons)
            {
                if(v.Element == pokemonElement)
                {
                    this.Badges++;
                    return;
                }
            }

            for(int i = 0; i < Pokemons.Count; i++)
            {
                if(Pokemons[i].Health <= 10)
                {
                    Pokemons.RemoveAt(i);
                    i--;
                }
                else
                {
                    Pokemons[i].Health -= 10;
                }

            }

        }

    }
}
