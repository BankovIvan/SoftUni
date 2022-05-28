function getInfo() {
    // TODO ...

    //Empty UL
    $("#buses").empty();

    let stopId = $("#stopId").val();
    let baseServiceUrl = "https://judgetests.firebaseio.com/businfo/" + stopId + ".json";

    //console.log("getInfo baseServiceUrl=" + baseServiceUrl);

    $.get(baseServiceUrl)
        .then(displayBuses)
        .catch(displayError);

    function displayBuses(busInfo) {

        //console.log("displayBuses busInfo=" + busInfo);
        var stopNameData = busInfo['name'];
        //console.log("displayBuses stopNameData=" + stopNameData);
        $("#stopName").text(stopNameData);

        var stopBusesData = busInfo['buses'];
        //console.log("displayBuses stopBusesData=" + stopBusesData);

        for (var busNumber in stopBusesData) {
            //console.log("displayBuses busNumber=" + busNumber);

            var busTime = stopBusesData[busNumber];
            //console.log("displayBuses busTime=" + busTime);

            var busText = "Bus " + busNumber + " arrives in " + busTime + "minutes";
            console.log("displayBuses busText=" + busText);

            //let person = contacts[key]['person'];
            //let phone = contacts[key]['phone'];
            var li = $("<li>");
            li.text(busText);
            $("#buses").append(li);
        }
    }

    function displayError(err) {
        $("#stopName").text("Error");

    }
}

/*
$(function () {
    $('#btnLoad').click(loadContacts);
    $('#btnCreate').click(createContact);
    let baseServiceUrl =
        'https://softuni-phonebook-homework.firebaseio.com/Phonebook';

    function loadContacts() {

        console.log("loadContacts baseServiceUrl=" + baseServiceUrl);

        $("#phonebook").empty();
        $.get(baseServiceUrl + '.json')
            .then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contacts) {

        console.log("displayContacts contacts=" + contacts);

        for (let key in contacts) {
            let person = contacts[key]['person'];
            let phone = contacts[key]['phone'];
            let li = $("<li>");
            li.text(person + ': ' + phone + ' ');
            $("#phonebook").append(li);
            li.append($("<button>Delete</button>").click(deleteContact.bind(this, key)));
        }

        console.log("displayContacts contacts=" + contacts);

    }

    function displayError(err) {
        $("#phonebook").append($("<li>Error</li>"));

    }
    function createContact() {
        let newContactJSON = JSON.stringify({
            person: $('#person').val(),
            phone: $('#phone').val()
        });
        $.post(baseServiceUrl + '.json', newContactJSON)
            .then(loadContacts)
            .catch(displayError);
        $('#person').val('');
        $('#phone').val('');


    }
    function deleteContact(key) {
        let request = {
            method: 'DELETE',
            url: baseServiceUrl + '/' + key + '.json'
        };
        $.ajax(request)
            .then(loadContacts)
            .catch(displayError);

    }
});
*/