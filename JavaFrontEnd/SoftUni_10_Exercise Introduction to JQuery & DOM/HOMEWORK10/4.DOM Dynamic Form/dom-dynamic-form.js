function domDynamicForm(selector) {
    // TODO

    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let formContainer = $('<form>');
    let divAddFieldContainer = $('<div>');
    let labelAddField = $('<label>');
    let inputAddField = $('<input>');
    let anchorAddField = $('<a>');

    //Search is omitted as per the lector instructions;

    let divRsultFieldContainer = $('<div>');
    let ulResultField = $('<ul>');

    //Customization - Add Fields
    divAddFieldContainer.addClass("add-controls");
        //As per the instruction in the homework document,
        // all though add-controls class does not exist;

    labelAddField.text("Enter text:");

    anchorAddField.addClass("button");
        //CSS absolute position given in button class, overlaps with the input object;
    anchorAddField.text("Add");

    //Customization - Result Fields
    divRsultFieldContainer.addClass("result-controls");

    ulResultField.addClass("items-list");
        //Again, items-list class does not exist!


    //Add button script;
    $(anchorAddField).on("click", function () {

        var liResultLiField = $('<li>');
        var aResultLiField = $('<a>');
        var strongResultLiField = $('<strong>');

        //liResultField.text($(this).parents('form').find('input').val());
        liResultLiField.addClass("list-item");

        aResultLiField.addClass("button");
        aResultLiField.text("X");

        strongResultLiField.text($(this).parents('form').find('input').val());

        aResultLiField.appendTo(liResultLiField);
        strongResultLiField.appendTo(liResultLiField);
        liResultLiField.appendTo($(this).parents('form').find('ul'));
    });

    //Append the new HTML code;
    formContainer.appendTo(fragment);
    divAddFieldContainer.appendTo(formContainer);
    labelAddField.appendTo(divAddFieldContainer);
    inputAddField.appendTo(divAddFieldContainer);
    anchorAddField.appendTo(divAddFieldContainer);

    divRsultFieldContainer.appendTo(formContainer);
    ulResultField.appendTo(divRsultFieldContainer);

    container.append(fragment);

    //Remove li script:
    $('body').on('click', 'li', function () {
        $(this).remove();
    })

}

