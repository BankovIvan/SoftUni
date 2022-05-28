//13.	Storing Objects

let arrInput = ["Pesho -> 13 -> 6.00", "Ivan -> 12 -> 5.57", "Toni -> 13 -> 4.90"];

function StoreObject(strData){

    //Create result array;
    var objResult = {};
    var arrSplit = String(strData).split(" -> ");
    objResult['Name'] = String(arrSplit[0]);
    objResult['Age'] = String(arrSplit[1]);
    objResult['Grade'] = String(arrSplit[2]);

    console.log("Name: " + objResult['Name']);
    console.log("Age: " + objResult['Age']);
    console.log("Grade: " + objResult['Grade']);

    return;
}

for (let i = 0; i < arrInput.length; i++){
    StoreObject(arrInput[i]);
    console.log();
}

