$(window).ready(function() {
    // Run code
    //console.log(Location2);
    //renderDataInHTML(Location2);
    renderDataInHTML(Location1);
});

let Location1 = {
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

let Location2 = {
    name: 'Dianabad',
    longitude: '95.242',
    latitude: '94.123',
    pokemons: {
        0: {
            name: 'Pikachu',
            power: 2000,
            evolvedFrom: 'none',
            evolvesTo: 'Raichu'
        },
        1: {
            name: 'Bulbasaur',
            power: 1000,
            evolvedFrom: 'Something',
            evolvesTo: 'Something else'
        }
    }
};

function renderDataInHTML(pokData){

        //Get location data;
        var pokLocationName = pokData['name'];
        //console.log("Location: " + pokLocationName);
        var pokLocationLongitude = pokData['longitude'];
        var pokLocationLatitude = pokData['latitude'];
        //console.log("Longitude: " + pokLocationLongitude + "  Latitude: " + pokLocationLatitude);
        var pokLocationPokemons = pokData['pokemons'];
        //console.log("Pokemons:");

        //Render location HTML;
        $('.location-name').text("Location: " + pokLocationName);
        $('.location-longitude').text("Longitude: " + pokLocationLongitude);
        $('.location-latitudee').text("Latitude: " + pokLocationLatitude);

        //Clear Pokemon DIVs;
        $('.pokemons').empty();

        for(var pokPokemon in pokLocationPokemons){
            //Get Pokemon data;
            var pokPokemonName = pokLocationPokemons[pokPokemon]['name'];
            //console.log("###Name: " + pokPokemonName);
            var pokPokemonPower = pokLocationPokemons[pokPokemon]['power'];
            //console.log("###Power: " + pokPokemonPower + "pp");
            var pokPokemonEvolvedFrom = pokLocationPokemons[pokPokemon]['evolvedFrom'];
            //console.log("###Evolved From: " + pokPokemonEvolvedFrom);
            var pokPokemonEvolvesTo = pokLocationPokemons[pokPokemon]['evolvesTo'];
            //console.log("###Evolves To: " + pokPokemonEvolvesTo);

            //Render Pokemon data;
            var divClassPokemon = $('<div>');
            divClassPokemon.addClass('pokemon');

            var divClassPokemonTitle = $('<div>');
            divClassPokemonTitle.addClass('pokemon-title');
            divClassPokemonTitle.text(pokPokemonName);
            divClassPokemon.append(divClassPokemonTitle);

            var divClassPokemonStats = $('<div>');
            divClassPokemonStats.addClass('pokemon-stats');

            var divClassPokemonName = $('<div>');
            divClassPokemonName.addClass('pokemon-name');
            divClassPokemonName.text("Name: " + pokPokemonName);
            divClassPokemonStats.append(divClassPokemonName);

            var divClassPokemonPower = $('<div>');
            divClassPokemonPower.addClass('pokemon-power');
            divClassPokemonPower.text("Power: " + pokPokemonPower + "pp");
            divClassPokemonStats.append(divClassPokemonPower);

            var divClassPokemonEvolvedFrom = $('<div>');
            divClassPokemonEvolvedFrom.addClass('pokemon-evolved-from');
            divClassPokemonEvolvedFrom.text("Evolved From: " + pokPokemonEvolvedFrom);
            divClassPokemonStats.append(divClassPokemonEvolvedFrom);

            var divClassPokemonEvolvesTo = $('<div>');
            divClassPokemonEvolvesTo.addClass('pokemon-evolves-to');
            divClassPokemonEvolvesTo.text("Evolves To: " + pokPokemonEvolvedFrom);
            divClassPokemonStats.append(divClassPokemonEvolvesTo);

            divClassPokemon.append(divClassPokemonStats);

            $('.pokemons').append(divClassPokemon);
        }
}

