let bookID = 1;

function createBook(selector, titleName, authorName, isbn) {
    // TODO
    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let bookContainer = $('<div>');
    let bookTitle = $('<p>');
    let bookAuthor = $('<p>');
    let bookISBN = $('<p>');
    let selectButton = $('<button>Select</button>');
    let deselectButton = $('<button>Deselect</button>');

    let currentBookID = "book" + bookID;

    //<DIV>
    bookContainer.attr("id", currentBookID);
    bookContainer.css("border", "medium none");

    //Title
    bookTitle.text(titleName);
    bookTitle.addClass("title");

    //Author
    bookAuthor.text(authorName);
    bookAuthor.addClass("author");

    //ISBN
    bookISBN.text(isbn);
    bookISBN.addClass("isbn");

    //Select button script;
    $(selectButton).on("click", function () {
        $(`#${currentBookID}`).css("border", "2px solid blue");
    });

    //Deselect button script;
    $(deselectButton).on("click", function () {
        $(`#${currentBookID}`).css("border", "none");
    });

    //Append the new HTML code;
    bookContainer.appendTo(fragment);
    bookTitle.appendTo(bookContainer);
    bookAuthor.appendTo(bookContainer);
    bookISBN.appendTo(bookContainer);
    selectButton.appendTo(bookContainer);
    deselectButton.appendTo(bookContainer);

    container.append(fragment);

    //Update global counter;
    bookID++;

    return;
}
