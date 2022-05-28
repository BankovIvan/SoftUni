/*$(document).ready(function() {
    $("button").click(function(event) {
        alert("Link forbidden!");
        event.preventDefault();
    });
});*/

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
