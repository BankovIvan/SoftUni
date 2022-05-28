attachEvents();

function attachEvents() {
    //TODO: Implement me...
    //console.log("attachEvents");
    $('button:contains(Load)').on("click", function(e){
        e.preventDefault();
        getPokemonInfo();
    });

    //Acordion
    $('body').on('click', 'div.pokemon-title', function () {
        var pokemonDisplayElement = $(this).parent().children('.pokemon-stats');
        if(pokemonDisplayElement.css('display') == "none"){
            $(this).parent().parent().find('.pokemon-stats').slideUp("slow");
            pokemonDisplayElement.slideDown("slow");
        }
        else{
            pokemonDisplayElement.slideUp("slow");
        }
    })
}

function getPokemonInfo() {
    // TODO ...
    var pokLocation = $("input.location-input").val();
    if(pokLocation == ""){
        return;
    }

    let pokServiceUrl = "https://pokemoncodex.firebaseio.com/locations/" + pokLocation + ".json";
    //console.log("getPokemonInfo pokServiceUrl=" + pokServiceUrl);

    $("input.location-input").val("");

    $.get(pokServiceUrl)
        .then(renderDataInHTML)
        .catch(displayError);

    function renderDataInHTML(pokData){
        //Get location data;
        var pokLocationName = pokData['name'];
        //console.log("renderDataInHTML pokLocationName=" + pokLocationName);
        var pokLocationLongitude = pokData['longitude'];
        var pokLocationLatitude = pokData['latitude'];
        var pokLocationPokemons = pokData['pokemons'];

        //Clear Pokemon DIVs;
        var divResult = $('.result');
        divResult.empty();
        //divResult.css('display',"inherit");
        divResult.show();

        var divLocation = $('<div>');
        divLocation.addClass('location');
        var divLocationName = $('<h1>');
        divLocationName.text("Location: " + pokLocationName);
        divLocationName.addClass('location-name');
        var divLocationCoordinates = $('<div>');
        divLocationCoordinates.addClass('location-coordinates');
        var divLocationLongitude = $('<h2>');
        divLocationLongitude.text("Longitude: " + pokLocationLongitude);
        divLocationLongitude.addClass('location-longitude');
        var divLocationLatitude = $('<h2>');
        divLocationLatitude.text("Latitude: " + pokLocationLatitude);
        divLocationLatitude.addClass('location-latitude');

        divLocationCoordinates.append(divLocationLongitude);
        divLocationCoordinates.append(divLocationLatitude);
        divLocation.append(divLocationName);
        divLocation.append(divLocationCoordinates);
        divResult.append(divLocation);

        //Append Pokemon;
        var divClassPokemonS = $('<div>');
        divClassPokemonS.addClass('pokemons');
        divResult.append(divClassPokemonS);

        for(var pokPokemon in pokLocationPokemons){
            //Get Pokemon data;
            var pokPokemonName = pokLocationPokemons[pokPokemon]['name'];
            //console.log("renderDataInHTML pokPokemonName=" + pokPokemonName);
            var pokPokemonPower = pokLocationPokemons[pokPokemon]['power'];
            var pokPokemonEvolvedFrom = pokLocationPokemons[pokPokemon]['evolvedFrom'];
            var pokPokemonEvolvesTo = pokLocationPokemons[pokPokemon]['evolvesTo'];

            //Render Pokemon data;
            var divClassPokemon = $('<div>');
            divClassPokemon.addClass('pokemon');

            var divClassPokemonTitle = $('<div>');
            divClassPokemonTitle.addClass('pokemon-title');
            divClassPokemonTitle.text(pokPokemonName);

            var divClassPokemonStats = $('<div>');
            divClassPokemonStats.addClass('pokemon-stats');

            var divClassPokemonName = $('<div>');
            divClassPokemonName.addClass('pokemon-name');
            divClassPokemonName.text("Name: " + pokPokemonName);


            var divClassPokemonPower = $('<div>');
            divClassPokemonPower.addClass('pokemon-power');
            divClassPokemonPower.text("Power: " + pokPokemonPower + "pp");


            var divClassPokemonEvolvedFrom = $('<div>');
            divClassPokemonEvolvedFrom.addClass('pokemon-evolved-from');
            divClassPokemonEvolvedFrom.text("Evolved From: " + pokPokemonEvolvedFrom);


            var divClassPokemonEvolvesTo = $('<div>');
            divClassPokemonEvolvesTo.addClass('pokemon-evolves-to');
            divClassPokemonEvolvesTo.text("Evolves To: " + pokPokemonEvolvedFrom);

            divClassPokemon.append(divClassPokemonTitle);

            divClassPokemonStats.append(divClassPokemonName);
            divClassPokemonStats.append(divClassPokemonPower);
            divClassPokemonStats.append(divClassPokemonEvolvedFrom);
            divClassPokemonStats.append(divClassPokemonEvolvesTo);
            divClassPokemon.append(divClassPokemonStats);

            divClassPokemonS.append(divClassPokemon);
        }
    }

    function displayError(err) {
        //Clear Pokemon DIVs and display error message;
        //console.log("displayError(err)");
        var divResult = $('.result');
        var divError = $('<div>');
        divError.text("Error loading location.");
        divError.addClass('error');

        divResult.empty();
        divResult.append(divError);
        //divResult.css('display',"inherit");
        divResult.show();
    }
}
