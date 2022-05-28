//10.	Add / Remove Elements

let arrInput = [
    ["add 3", "add 5", "add 7"],
    ["add 3", "add 5", "remove 1", "add 2"],
    ["add 3", "add 5", "remove 2", "remove 0", "add 7"]
];

function AddRemoveArrayElements(arrN){

    //Create result array;
    var arrResult = [];

    //Read command and set index/value pairs;
    for(var j = 0; j < arrN.length; j++){

        var arrSplit = String(arrN[j]).split(" ");

        var command = String(arrSplit[0]);
        var data = Number(arrSplit[1]);

        if(command == "add"){
            arrResult.push(data);
        }
        else if(data < arrResult.length){
            arrResult.splice(data, 1);
        }
    }

    //Print result
    for(var j = 0; j < arrResult.length; j++){
        console.log(arrResult[j]);
    }

    return;
}

for (let i = 0; i < arrInput.length; i++){
    AddRemoveArrayElements(arrInput[i]);
    console.log();
}

