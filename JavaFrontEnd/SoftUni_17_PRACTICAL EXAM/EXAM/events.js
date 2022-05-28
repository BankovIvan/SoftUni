let punshes = {
    0: {
        name: "One Punsh Man",
        type: "Strong",
        contents: "Very little Vodka, Very little Brendy, Very little Wine, Very little Whiskey, Very little Tequila and a lot of Watermelon Juice.",
        description: "This punsh was discovered in an unknown house party, when there was almost no alcohol left, and the people had to combine a little from every alchohol. One Punsh of this is enough to knock you down for good, hence the name."
    },
    1: {
        name: "Wine Punsh",
        type: "Sweet",
        contents: "Wine, Apple Juice, Ice.",
        description: "Casual Wine Punsh, for the ladies that love wine. It is not very strong, it is actually sweet. Sweet enough to make them sweetly drunk and playful."
    },
    2: {
        name: "Punsh Out",
        type: "Sweet",
        contents: "Champagne, Watermellon Juice, Ice.",
        description: "This is a very sweet, almost non-alchoholic, punsh. Very suitable for ladies, which want to keep their manners but have a little fun at a party."
    }
};

attachPunshesEvents(punshes);

//REUSED renderAllPunshesInHTML with added click event!!!
function attachPunshesEvents(punshes) {
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
        div_NavbarItem.on('click', {punshName: data_punshName}, function (event) {
            //console.log("function event.data.punshName=" + event.data.punshName);
            event.preventDefault();
            singlePunshEvent(event.data.punshName);

        });
        let h4_NavbarItem = $('<h4>');
        h4_NavbarItem.text(data_punshName);

        div_NavbarItem.append(h4_NavbarItem);
        div_NavbarItems.append(div_NavbarItem);
    }
}

//REUSED renderSinglePunshInHTML with added click event!!!
function attachBackEvents(punshes, punshName) {
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
            div_ContentHeading.on('click', function (event) {
                //console.log("function");
                event.preventDefault();
                singleContentEvent();
            });

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

function singlePunshEvent(punshName){
    //console.log("singlePunshEvent -> punshName=" + punshName);

    $('div.navbar-items').remove();
    attachBackEvents(punshes, punshName);
}

function singleContentEvent(){
    //console.log("singlePunshEvent -> punshName=" + punshName);

    $('div.content').empty();
    attachPunshesEvents(punshes);
}