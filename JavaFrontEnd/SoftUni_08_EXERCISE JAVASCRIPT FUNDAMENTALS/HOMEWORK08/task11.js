//11.	Working with Key-Value Pairs

let arrInput = [
    ["key value", "key eulav", "test test", "key"],
    ["3 test", "3 test1", "4 test2", "4 test3", "4 test5", "4"],
    ["3 bla", "3 abl", "2"]
];

function KeyValueAddSingle(arrN){

    //Create result array;
    var objResult = {};

    //Read command and set key/value pairs;
    for(var j = 0; j < arrN.length - 1; j++){

        var arrSplit = String(arrN[j]).split(" ");

        var key = String(arrSplit[0]);
        var value = arrSplit[1];

        objResult[key] = value;
    }

    //Print result
    var key = String(arrN[arrN.length - 1]);
    if(objResult[key] === undefined){
        console.log("None");
    }
    else{
        console.log(objResult[key]);
    }

    return;
}

for (let i = 0; i < arrInput.length; i++){
    KeyValueAddSingle(arrInput[i]);
    console.log();
}

