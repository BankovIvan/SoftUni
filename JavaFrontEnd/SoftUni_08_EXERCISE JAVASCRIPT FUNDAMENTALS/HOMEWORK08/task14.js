//14.	Parse JSON Objects

let arrInput = [
    "{\"name\":\"Gosho\",\"age\":10,\"date\":\"19/06/2005\"}",
    "{\"name\":\"Gosho\",\"age\":10,\"date\":\"19/06/2005\"}"
];

function ReadObjectJSON(strData){

    //Create result array;
    var objResult = JSON.parse(strData);

    for(var propertyName in objResult) {
        // propertyName is what you want
        // you can get the value like this: myObject[propertyName]
        console.log(propertyName + ": " + objResult[propertyName]);
    }

    return;
}

for (let i = 0; i < arrInput.length; i++){
    ReadObjectJSON(arrInput[i]);
    console.log();
}

