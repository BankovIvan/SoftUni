let location = {
    name: 'Izgrev',
    longitude: '95.243',
    latitude: '94.231',
    pokemons: {
        0: {
            name: 'Pikachu',
            power: 2000,
            evolvedFrom: 'none',
            evolvesTo: 'Raichu'
        },
        1: {
            name: 'Wartortle',
            power: 500,
            evolvedFrom: 'Squirtle',
            evolvesTo: 'Blastoise'
        },
        2: {
            name: 'CherryBerry',
            power: 9999,
            evolvedFrom: 'Cherry',
            evolvesTo: 'Berry'
        }
    }
};

function renderData(pokData){
    var pokLocationName = pokData['name'];
    console.log("Location: " + pokLocationName);
    var pokLocationLongitude = pokData['longitude'];
    var pokLocationLatitude = pokData['latitude'];
    console.log("Longitude: " + pokLocationLongitude + "  Latitude: " + pokLocationLatitude);
    var pokLocationPokemons = pokData['pokemons'];
    console.log("Pokemons:");

    for(var pokPokemon in pokLocationPokemons){
        var pokPokemonName = pokLocationPokemons[pokPokemon]['name'];
        console.log("###Name: " + pokPokemonName);
        var pokPokemonPower = pokLocationPokemons[pokPokemon]['power'];
        console.log("###Power: " + pokPokemonPower + "pp");
        var pokPokemonEvolvedFrom = pokLocationPokemons[pokPokemon]['evolvedFrom'];
        console.log("###Evolved From: " + pokPokemonEvolvedFrom);
        var pokPokemonEvolvesTo = pokLocationPokemons[pokPokemon]['evolvesTo'];
        console.log("###Evolves To: " + pokPokemonEvolvesTo);
    }
}

renderData(location);
