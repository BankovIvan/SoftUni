//7.	Print Lines

let arrInput = [
    ["Line 1", "Line 2", "Line 3", "Stop"],
    [3, 6, 5, 4, "Stop", 10, 12]
];

function PrintLinesTillStop(arrN){
    for(var j = 0; j < arrN.length; j++){
        if(arrN[j] == "Stop") break;
        console.log(arrN[j]);
    }
    return;
}

for (let i = 0; i < arrInput.length; i++){
    PrintLinesTillStop(arrInput[i]);
    console.log();
}

