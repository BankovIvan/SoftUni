/////////////////////////////////////////////////////////////////////////////////////////////
//   PROBLEM 1
/////////////////////////////////////////////////////////////////////////////////////////////
let continents1 = {
    Europe: {
        name: "Europe",
        countries: {
            Bulgaria: {
                name: "Bulgaria",
                capital: "Sofia",
                officialLanguage: "Bulgarian",
                population: 7000000,
                area: 111000,
                politicalStatus: "Republic",
                president: "Rumen Radev",
                officialCurrency: "LEV(BGN)"
            },
            Vatican: {
                name: "Vatican",
                capital: "Vatican City",
                officialLanguage: "Italian",
                population: 1000,
                area: 0.44,
                politicalStatus: "Monarchy",
                monarch: "Francis",
                officialCurrency: "Euro(EUR)"
            }
        }
    },
    Asia: {
        name: "Asia",
        countries: {
            Russia: {
                name: "Russia",
                capital: "Moscow",
                officialLanguage: "Russian",
                population: 144463451,
                area: 17075200,
                politicalStatus: "Republic",
                president: "Vladimir Putin",
                officialCurrency: "Russian ruble(RUB)"
            },
            China: {
                name: "China",
                capital: "Beijing",
                officialLanguage: "Chinese",
                population: 1403500365,
                area: 9596961,
                politicalStatus: "Republic",
                president: "Xi Jinping",
                officialCurrency: "Renminbi(CNY)"
            }
        }
    }
};

//renderAllContinents(continents1);
//renderSingleContinent(continents1['Europe']);
//renderSingleCountry(continents1['Europe']['countries']['Bulgaria']);
//renderSingleCountry(continents1['Europe']['countries']['Vatican']);

function renderAllContinents(continents) {
    //TODO: Implement me ...
    for(var currContinent in continents){
        console.log(continents[currContinent]['name']);
    }
}

function renderSingleContinent(continent) {
    //TODO: Implement me ...
    console.log(continent['name']);
    console.log("Countries:");
    for(var currContry in continent['countries']){
        console.log("$$$" + continent['countries'][currContry]['name']);
    }
}

function renderSingleCountry(country) {
    //TODO: Implement me ...
    console.log(country['name']);
    console.log("Capital: " + country['capital']);
    console.log("Official Language: " + country['officialLanguage']);
    console.log("Population: " + country['population']);
    console.log("Area: " + country['area'] + " km2");
    console.log("Political Status: " + country['politicalStatus']);
    if(country['politicalStatus'] === "Republic"){
        console.log("President: " + country['president']);
    }else{
        console.log("Monarch: " + country['monarch']);
    }
    console.log("Official Currency: " + country['officialCurrency']);

}

/////////////////////////////////////////////////////////////////////////////////////////////
//   PROBLEM 2
/////////////////////////////////////////////////////////////////////////////////////////////
let continents2 = {
    Europe: {
        name: "Europe",
        countries: {
            Bulgaria: {
                name: "Bulgaria",
                capital: "Sofia",
                officialLanguage: "Bulgarian",
                population: 7000000,
                area: 111000,
                politicalStatus: "Republic",
                president: "Rumen Radev",
                officialCurrency: "LEV(BGN)"
            }
        }
    }
};

//renderDataInHTML(continents2);

function renderDataInHTML(continentsData) {
    //TODO: Implement me ...
    renderContinentsInHTML(continentsData);

    for(var currContinent in continentsData){
        renderContinentDataInHTML(continentsData[currContinent]);

        for(var currCountry in continentsData[currContinent]['countries']) {
            renderContinentCountryInHTML(continentsData[currContinent]['countries'][currCountry]);
        }
    }
}

function renderContinentsInHTML(continentsData){
    //console.log("renderContinentsInHTML -> " + continentsData);
    for(var currContinent in continentsData){
        //console.log("renderContinentsInHTML -> currContinent=" + currContinent);

        ////////////////////////////////
        //<div class="continents">
        ////////////////////////////////
        var divContinents = $('.continents');
        //divContinents.empty();

        var divContinent = $('<div>');
        divContinent.addClass('continent');
        var h5ContinentTitle = $('<h5>');
        h5ContinentTitle.addClass('continent-title');
        h5ContinentTitle.text(continentsData[currContinent]['name']);

        divContinent.append(h5ContinentTitle);
        divContinents.append(divContinent);

    }
}

function renderContinentDataInHTML(continentData){
    //console.log("renderContinentDataInHTML -> " + continentData['name']);

    ////////////////////////////////
    //<div class="continent-data">
    ////////////////////////////////

    var divContinentData = $('.continent-data');
    divContinentData.empty();

    var h2ContinentTitle = $('<h2>');
    h2ContinentTitle.addClass('continent-title');
    h2ContinentTitle.text(continentData['name']);
    var h3CountriesTitle = $('<h3>');
    h3CountriesTitle.addClass('countries-title');
    h3CountriesTitle.text("Countries");
    var divCountries = $('<div>');
    divCountries.addClass('countries');
    var selectDropdownSelect = $('<select>');
    selectDropdownSelect.addClass('dropdown-select');
    var optionDropdownSelect = $('<option disabled selected value>');
    optionDropdownSelect.text(" -- select an option -- ");

    selectDropdownSelect.append(optionDropdownSelect);

    for(var currCountry in continentData['countries']){
        //console.log("$$$" + currContry);
        var optionDropdownValue = $('<option>');
        optionDropdownValue.attr('value', continentData['countries'][currCountry]['name']);
        optionDropdownValue.text(continentData['countries'][currCountry]['name']);

        selectDropdownSelect.append(optionDropdownValue);

    }

    var divContinentImage = $('<div>');
    divContinentImage.addClass('continent-image');
    var imgContinentImage = $('<img>');
    imgContinentImage.attr('src', "images/" + continentData['name'].toLowerCase() + ".png");

    divContinentData.append(h2ContinentTitle);
    divContinentData.append(h3CountriesTitle);
    divCountries.append(selectDropdownSelect);
    divContinentData.append(divCountries);
    divContinentImage.append(imgContinentImage);
    divContinentData.append(divContinentImage);

}

function renderContinentCountryInHTML(continentCountryData){
    //console.log("renderContinentCountryInHTML -> " + continentCountryData['name']);

    ////////////////////////////////
    //<div class="continent-country">
    ////////////////////////////////

    var divContinentCountry = $('.continent-country');
    divContinentCountry.empty();

    var divCountryTitle = $('<div>');
    divCountryTitle.addClass('country-title');
    var h2CountryTitle = $('<h2>');
    h2CountryTitle.text(continentCountryData['name']);

    var divCountryData = $('<div>');
    divCountryData.addClass('country-data');
    var divCountryCapital =
        $("<div><strong>Capital:</strong> <div> " + continentCountryData['capital'] + "</div></div>");
    divCountryCapital.addClass('country-capital');
    var divCountryOfficialLanguage =
        $("<div><strong>Official Language:</strong> <div> " + continentCountryData['officialLanguage'] + "</div></div>");
    divCountryOfficialLanguage.addClass('country-official-language');
    var divCountryPopulation =
        $("<div><strong>Population:</strong> <div> " + continentCountryData['population'] + "</div></div>");
    divCountryPopulation.addClass('country-population');
    var divCountryArea =
        $("<div><strong>Area:</strong> <div> " + continentCountryData['area'] + " km" + "<sup>2</sup></div></div>");
    divCountryArea.addClass('country-area');
    var divCountryPoliticalStatus =
        $("<div><strong>Political Status:</strong> <div> " + continentCountryData['politicalStatus'] + "</div></div>");
    divCountryPoliticalStatus.addClass('country-political-status');
    var divCountryPresident;
    if(continentCountryData['politicalStatus'] === "Republic"){
        divCountryPresident =
            $("<div><strong>President:</strong> <div> " + continentCountryData['president'] + "</div></div>");
    }else{
        divCountryPresident =
            $("<div><strong>Monarch:</strong> <div> " + continentCountryData['monarch'] + "</div></div>");

    }
    divCountryPresident.addClass('country-president');
    var divCountryOfficialCurrency =
        $("<div><strong>Official Currency:</strong> <div> " + continentCountryData['officialCurrency'] + "</div></div>");
    divCountryOfficialCurrency.addClass('country-official-currency');

    divCountryTitle.append(h2CountryTitle);
    divContinentCountry.append(divCountryTitle);

    divCountryData.append(divCountryCapital);
    divCountryData.append(divCountryOfficialLanguage);
    divCountryData.append(divCountryPopulation);
    divCountryData.append(divCountryArea);
    divCountryData.append(divCountryPoliticalStatus);
    divCountryData.append(divCountryPresident);
    divCountryData.append(divCountryOfficialCurrency);
    divContinentCountry.append(divCountryData);

}

/////////////////////////////////////////////////////////////////////////////////////////////
//   PROBLEM 3
/////////////////////////////////////////////////////////////////////////////////////////////
let continents3 = {
    Europe: {
        name: "Europe",
        countries: {
            Bulgaria: {
                name: "Bulgaria",
                capital: "Sofia",
                officialLanguage: "Bulgarian",
                population: 7000000,
                area: 111000,
                politicalStatus: "Republic",
                president: "Rumen Radev",
                officialCurrency: "LEV(BGN)"
            },
            Vatican: {
                name: "Vatican",
                capital: "Vatican City",
                officialLanguage: "Italian",
                population: 1000,
                area: 0.44,
                politicalStatus: "Monarchy",
                monarch: "Francis",
                officialCurrency: "Euro(EUR)"
            }
        }
    },
    Asia: {
        name: "Asia",
        countries: {
            Russia: {
                name: "Russia",
                capital: "Moscow",
                officialLanguage: "Russian",
                population: 144463451,
                area: 17075200,
                politicalStatus: "Republic",
                president: "Vladimir Putin",
                officialCurrency: "Russian ruble(RUB)"
            },
            China: {
                name: "China",
                capital: "Beijing",
                officialLanguage: "Chinese",
                population: 1403500365,
                area: 9596961,
                politicalStatus: "Republic",
                president: "Xi Jinping",
                officialCurrency: "Renminbi(CNY)"
            }
        }
    }
};

//attachEvents(continents3); //pass the continents object

function attachEvents(continentsData){
    //console.log("attachEvents");
    renderContinentsInHTML(continentsData);

    //Acordion
    $('body').on('click', 'div.continent', function (event) {
        //console.log("body -> div.continent -> click");
        event.preventDefault();

        var nameDisplayContinent = $(this).find('h5.continent-title').text();
        //console.log("body -> div.continent -> nameDisplayContinent=" + nameDisplayContinent);
        var divDisplayContinent = $(this).parent().parent().find('.continent-data');
        //console.log("body -> div.continent -> divDisplayContinent=" + divDisplayContinent.parent().html());
        var divDisplayCountry = $(this).parent().parent().find('.continent-country');
        //console.log("body -> div.continent -> divDisplayCountry=" + divDisplayCountry.parent().html());
        if(divDisplayContinent.css('display') == "none"){
            renderContinentDataInHTML(continentsData[nameDisplayContinent]);
            divDisplayCountry.empty();
            divDisplayCountry.show();
            divDisplayContinent.show();
        }
        else{
            var nameCurrentContinent = divDisplayContinent.find('h2.continent-title').text();
            //console.log("body -> div.continent -> nameCurrentContinent=" + nameCurrentContinent);
            if(nameDisplayContinent == nameCurrentContinent){
                divDisplayContinent.hide();
                divDisplayCountry.hide();
                divDisplayCountry.empty();
            }
            else{
                divDisplayCountry.empty();
                renderContinentDataInHTML(continentsData[nameDisplayContinent]);
            }
        }
    })

    //Selector
    $('body').on('change', 'select.dropdown-select', function (event) {
        //console.log("body -> select.dropdown-select -> change");
        //event.preventDefault();

        var nameCurrentCountry = this.value;
        //console.log("body -> select.dropdown-select -> nameCurrentCountry=" + nameCurrentCountry);
        var nameCurrentContinent = $(this).parent().parent().find('h2.continent-title').text();
        //console.log("body -> select.dropdown-select -> nameCurrentContinent=" + nameCurrentContinent);

        renderContinentCountryInHTML(continentsData[nameCurrentContinent]['countries'][nameCurrentCountry]);

    })
}

/////////////////////////////////////////////////////////////////////////////////////////////
//   PROBLEM 4
/////////////////////////////////////////////////////////////////////////////////////////////
attachEvents4();

function attachEvents4(){

    var continentsServiceUrl = "https://continental-drift.firebaseio.com/continents.json";

    $.get(continentsServiceUrl)
        .then(renderContinentsInHTML)
        .catch(function() {
            $('.continents').empty();
            $('.continents').text("Error!");
            $('.continent-data').empty();
            $('.continent-country').empty();
        });

    //Accordion
    $('body').on('click', 'div.continent', function (event) {
        //console.log("body -> div.continent -> click");
        event.preventDefault();

        var nameDisplayContinent = $(this).find('h5.continent-title').text();
        var divDisplayContinent = $(this).parent().parent().find('.continent-data');
        var divDisplayCountry = $(this).parent().parent().find('.continent-country');

        if(divDisplayContinent.css('display') == "none"){

            var continentDataServiceUrl = "https://continental-drift.firebaseio.com/continents/"
                + nameDisplayContinent + ".json";

            $.get(continentDataServiceUrl)
                .then(renderContinentDataInHTML)
                .catch(function() {
                    $('.continent-data').empty();
                    $('.continent-data').text("Error!");
                    $('.continent-country').empty();
                });

            divDisplayCountry.empty();
            divDisplayCountry.show();
            divDisplayContinent.show();
        }
        else{
            var nameCurrentContinent = divDisplayContinent.find('h2.continent-title').text();

            if(nameDisplayContinent == nameCurrentContinent){
                divDisplayContinent.hide();
                divDisplayCountry.hide();
                divDisplayCountry.empty();
            }
            else{
                divDisplayCountry.empty();

                var continentDataServiceUrl = "https://continental-drift.firebaseio.com/continents/" +
                    nameDisplayContinent + ".json";

                $.get(continentDataServiceUrl)
                    .then(renderContinentDataInHTML)
                    .catch(function() {
                        $('.continent-data').empty();
                        $('.continent-data').text("Error!");
                        $('.continent-country').empty();
                    });
            }
        }
    })

    //Selector
    $('body').on('change', 'select.dropdown-select', function (event) {
        //console.log("body -> select.dropdown-select -> change");
        //event.preventDefault();

        var nameCurrentCountry = this.value;
        var nameCurrentContinent = $(this).parent().parent().find('h2.continent-title').text();

        var countryServiceUrl = "https://continental-drift.firebaseio.com/continents/" +
            nameCurrentContinent+ "/countries/" + nameCurrentCountry + ".json";

        $.get(countryServiceUrl)
            .then(renderContinentCountryInHTML)
            .catch(function() {
                $('.continent-country').empty();
                $('.continent-country').text("Error!");
            });
    })
}
