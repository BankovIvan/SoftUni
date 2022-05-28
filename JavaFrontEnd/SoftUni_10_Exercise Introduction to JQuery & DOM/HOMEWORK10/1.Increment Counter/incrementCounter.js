function increment(selector) {
    // TODO
    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let textArea = $('<textarea>');
    let incrementBtn = $('<button>Increment</button>');
    let addBtn = $('<button>Add</button>');
    let list = $('<ul>');

    //Text Area Format
    textArea.val(0);                    //jQuery HTML / CSS Methods - https://www.w3schools.com/jquery/jquery_ref_html.asp
    textArea.addClass('counter');       //jQuery HTML / CSS Methods - https://www.w3schools.com/jquery/jquery_ref_html.asp
    textArea.attr("disabled", true);    //jQuery HTML / CSS Methods - https://www.w3schools.com/jquery/jquery_ref_html.asp

    //Buttons Formatting
    incrementBtn.addClass('btn');
    incrementBtn.attr('id', 'incrementBtn');
    addBtn.addClass('btn');
    addBtn.attr('id', 'addBtn');

    //List Formatting
    list.addClass('results');

    //Events
    $(incrementBtn).on("click", function () {
       textArea.val(Number(textArea.val()) + 1);
    });

    $(addBtn).on("click", function () {
        let li = $(`<li>${textArea.val()}</li>`);
        li.appendTo(list);
    });

    textArea.appendTo(fragment);
    incrementBtn.appendTo(fragment);
    addBtn.appendTo(fragment);
    list.appendTo(fragment);

    container.append(fragment);
}
