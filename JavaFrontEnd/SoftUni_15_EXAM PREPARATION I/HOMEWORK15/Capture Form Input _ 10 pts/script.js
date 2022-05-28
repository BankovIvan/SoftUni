/*
$(document).ready(function() {
    console.log("document.ready");
    $('button:contains(Load)').on("click", function(e){
        e.preventDefault();
        addFormElement();

    });
});
*/

attachEvents();

function attachEvents() {
    //TODO: Implement me...
    //console.log("attachEvents");

    $('button:contains(Load)').on("click", function(e){
        e.preventDefault();
        addFormElement();

    });

    /* WORKING!!!
    $('.location-form>button').click(function(e) {
        e.preventDefault();
        let inputValue = $('.location-input').val();
        $('.result').append(inputValue);
    });
    */

    /* Also Working!
    $('.location-form>button').click(function(e) {
        e.preventDefault();
        //let inputValue = $('.location-input').val();
        //$('.result').append(inputValue);
        addFormElement();
    });
    */
}

function addFormElement(){
    //console.log("addFormElement");
    var textToAppend = $('input.location-input');
    //console.log("addFormElement textToAppend.val()=" + textToAppend.val());

    if(!(textToAppend.val() === undefined)){
        if(textToAppend.val() != ""){
            //console.log("addFormElement ---> Append");
            var divParent = $('div.result');
            var divChild = $('<div>');
            divChild.addClass('result-element');
            divChild.text(textToAppend.val());
            divParent.append(divChild);
            textToAppend.val("");
        }
    }
}

