//15.	Turn Object into JSON String

let arrInput = [["name -> Angel", "surname -> Georgiev", "age -> 20", "grade -> 6.00", "date -> 23/05/1995", "town -> Sofia"]];

function StoreObjectJSON(arrN){

    //Create result array;
    var objResult = {};

    for(var element of arrN){
        var arrSplit = String(element).split(" -> ");
        objResult[String(arrSplit[0])] = arrSplit[1];
    }

    var strResult = JSON.stringify(objResult);
    console.log(strResult);

    return;
}

for (let i = 0; i < arrInput.length; i++){
    StoreObjectJSON(arrInput[i]);
    console.log();
}

