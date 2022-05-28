let punshes = {
    0: {
        name: "Punsh - The American Pie",
        type: "Strong",
        contents: "Some Apple Pie, Whiskey, Vodka, Orange Juice and some other things...",
        description: "By original recipe from the American Pie franchise, this punsh includes everything you would want in a college/university party."
    },
    1: {
        name: "Brendy Punsh",
        type: "Medium",
        contents: "Brendy, Apple Juice, Ice, Avocado Juice, some other strange fruits...",
        description: "The casual Brendy Punsh, quite expensive, nothing interesting here..."
    },
    2: {
        name: "Just Punsh it",
        type: "Sweet",
        contents: "Very Little Vodka, Orange Juice, Apple Juice, Banana Juice, Ice.",
        description: "A very comfortable taste for the lovers of weakly alchoholic drinks. The Just Pinsh It punsh is a sweet multi-vitamol drink, which cannot drunk you."
    }
};

renderAllPunshesInHTML(punshes);
//renderSinglePunshInHTML(punshes, "Punsh – The American Pie"); //////// NOT WORKING!!!!!!!!!!!!!!!!!!!!!
renderSinglePunshInHTML(punshes, "Punsh - The American Pie");

function renderAllPunshesInHTML(punshes) {
    //TODO: Implement me ...

    let data_punshName;

    let div_Navbar = $('div.navbar');
    //console.log(div_Navbar.html());

    //let hr_SectionDivider = $('<hr>');
    //hr_SectionDivider.addClass('section-divider');
    let div_NavbarItems = $('<div>');
    div_NavbarItems.addClass('navbar-items');

    //div_Navbar.append(hr_SectionDivider);
    div_Navbar.append(div_NavbarItems);

    for(let data_punshItem in punshes){
        data_punshName = punshes[data_punshItem]['name'];
        //console.log(data_punshName);

        let div_NavbarItem = $('<div>');
        div_NavbarItem.addClass('navbar-item');
        let h4_NavbarItem = $('<h4>');
        h4_NavbarItem.text(data_punshName);

        div_NavbarItem.append(h4_NavbarItem);
        div_NavbarItems.append(div_NavbarItem);
    }
}

function renderSinglePunshInHTML(punshes, punshName) {
    //TODO: Implement me ...

    let data_punshName;
    let data_punshType;
    let data_punshContents;
    let data_punshDescription;

    let div_Content = $('div.content');

    for(let data_punshItem in punshes){
        //data_punshName = punshes[data_punshItem]['name'];
        //console.log(data_punshItem);

        if(punshes[data_punshItem]['name'] === punshName){
            //console.log(punshes[data_punshItem]['name']);
            data_punshName = punshes[data_punshItem]['name'];
            data_punshType = punshes[data_punshItem]['type'];
            data_punshContents = punshes[data_punshItem]['contents'];
            data_punshDescription = punshes[data_punshItem]['description'];

            let div_ContentHeader = $('<div>');
            div_ContentHeader.addClass('content-header');

            let div_ContentHeading = $('<div>');
            div_ContentHeading.addClass('content-heading');
            div_ContentHeading.text(data_punshName);
            div_ContentHeading.css('cursor', "pointer");

            div_ContentHeader.append(div_ContentHeading);
            div_Content.append(div_ContentHeader);


            let div_PunshData = $('<div>');
            div_PunshData.addClass('punsh-data');

            let div_PunshType = $('<div>');
            div_PunshType.addClass('punsh-type');
            let label_PunshType = $('<label>');
            label_PunshType.text("Type: ");
            let h6_PunshType = $('<h6>');
            h6_PunshType.text(data_punshType);

            div_PunshType.append(label_PunshType);
            div_PunshType.append(h6_PunshType);

            let div_PunshContents = $('<div>');
            div_PunshContents.addClass('punsh-contents');
            let label_PunshContents = $('<label>');
            label_PunshContents.text("Contents: ");
            let p_PunshContents = $('<p>');
            p_PunshContents.text(data_punshContents);

            div_PunshContents.append(label_PunshContents);
            div_PunshContents.append(p_PunshContents);

            let div_PunshDescription = $('<div>');
            div_PunshDescription.addClass('punsh-description');
            let label_PunshDescription = $('<label>');
            label_PunshDescription.text("Description: ");
            let p_PunshDescription = $('<p>');
            p_PunshDescription.text(data_punshDescription);

            div_PunshDescription.append(label_PunshDescription);
            div_PunshDescription.append(p_PunshDescription);

            div_PunshData.append(div_PunshType);
            div_PunshData.append(div_PunshContents);
            div_PunshData.append(div_PunshDescription);

            div_Content.append(div_PunshData);

            break;
        }
    }
}