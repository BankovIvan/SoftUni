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

renderAllPunshes(punshes);
renderSinglePunsh(punshes, "Punsh - The American Pie");

function renderAllPunshes(punshes) {
    //TODO: Implement me ...

    let data_punshName;

    for(let data_punshItem in punshes){
        data_punshName = punshes[data_punshItem]['name'];
        console.log(data_punshName);
    }
}

function renderSinglePunsh(punshes, punshName) {
    //TODO: Implement me ...

    let data_punshName;
    let data_punshType;
    let data_punshContents;
    let data_punshDescription;

    for(let data_punshItem in punshes){
        //data_punshName = punshes[data_punshItem]['name'];
        //console.log(data_punshItem);
        if(punshes[data_punshItem]['name'] === punshName){
            data_punshName = punshes[data_punshItem]['name'];
            data_punshType = punshes[data_punshItem]['type'];
            data_punshContents = punshes[data_punshItem]['contents'];
            data_punshDescription = punshes[data_punshItem]['description'];
            break;
        }
    }

    console.log(data_punshName);
    console.log("Type: " + data_punshType);
    console.log("Contents: " + data_punshContents);
    console.log("Description: " + data_punshDescription);

}

