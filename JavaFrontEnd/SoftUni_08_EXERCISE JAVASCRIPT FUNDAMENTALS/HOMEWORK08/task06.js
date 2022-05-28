//6.	Print Numbers from N to 1

let arrN = ["5", "2"];

function PrintNumbersTo1(N){
    for(var j = N; j > 0; j--){
        console.log(j);
    }
    return;
}

for (let i in arrN){
    PrintNumbersTo1(arrN[i]);
    console.log();
}

