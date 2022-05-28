//8.	Print Numbers in Reversed Order

let arrInput = [
    [10, 15, 20],
    [5, 5.5, 24, -3],
    [20, 1, 20, 1, 20]
];

function PrintNumbersReverse(arrN){
    for(var j = arrN.length - 1; j >= 0; j--){
        console.log(arrN[j]);
    }
    return;
}

for (let i = 0; i < arrInput.length; i++){
    PrintNumbersReverse(arrInput[i]);
    console.log();
}

