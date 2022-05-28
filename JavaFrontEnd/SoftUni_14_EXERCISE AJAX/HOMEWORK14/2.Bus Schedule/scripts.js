function solve() {
    // TODO ...

    let busStop = "depot"
    let baseServiceUrl = "https://judgetests.firebaseio.com/schedule/" + busStop + ".json";

    function depart(){
        baseServiceUrl = "https://judgetests.firebaseio.com/schedule/" + busStop + ".json";
        $.get(baseServiceUrl)
            .then(displayBuStopDepart)
            .catch(displayError);

    }

    function arrive(){
        baseServiceUrl = "https://judgetests.firebaseio.com/schedule/" + busStop + ".json";
        $.get(baseServiceUrl)
            .then(displayBuStopArrive)
            .catch(displayError);

    }

    function displayBuStopDepart(nextBusStop) {
        //$("#phonebook").append($("<li>Error</li>"));

        var stopName = nextBusStop['name'];
        busStop = nextBusStop['next'];

        $('#info').text("Next stop " + stopName);

        $('#arrive').removeAttr('disabled');
        $('#depart').attr('disabled', "true");


    }

    function displayBuStopArrive(nextBusStop) {
        //$("#phonebook").append($("<li>Error</li>"));

        var stopName = nextBusStop['name'];
        busStop = nextBusStop['next'];

        $('#info').text("Arriving at " + stopName);

        $('#depart').removeAttr('disabled');
        $('#arrive').attr('disabled', "true");

    }

    function displayError(err) {
        $("#info").text("Error");

    }

    return {
        depart,
        arrive
    };
}

let result = solve();
