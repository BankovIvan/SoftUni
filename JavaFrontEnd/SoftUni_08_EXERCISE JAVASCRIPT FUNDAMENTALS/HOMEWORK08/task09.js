//9.	Set Values to Indexes in an Array

let arrInput = [
    ["3", "0 - 5", "1 - 6", "2 - 7"],
    ["2", "0 - 5", "0 - 6", "0 - 7"],
    ["5", "0 - 3", "3 - -1", "4 - 2"]
];

function SetIndexedValues(arrN){

    //Create result array;
    var arrResult = Array(Number(arrN[0]));

    //Init result array;
    for(var j = 0; j < arrResult.length; j++){
        arrResult[j] = 0;
    }

    //Read and set index/value pairs;
    for(var j = 1; j < arrN.length; j++){

        var arrSplit = String(arrN[j]).split(" - ");
        arrResult[Number(arrSplit[0])] = arrSplit[1];
    }

    //Print result
    for(var j = 0; j < arrResult.length; j++){
        console.log(arrResult[j]);
    }

    return;
}

for (let i = 0; i < arrInput.length; i++){
    SetIndexedValues(arrInput[i]);
    console.log();
}

