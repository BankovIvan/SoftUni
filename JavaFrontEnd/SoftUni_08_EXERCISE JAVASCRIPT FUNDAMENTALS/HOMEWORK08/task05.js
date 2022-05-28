//5.	Print Numbers from 1 to N

let arrN = ["5", "2"];

function PrintNumbersToN(N){
    for(var j = 1; j <= N; j++){
        console.log(j);
    }
    return;
}

for (let i in arrN){
    PrintNumbersToN(arrN[i]);
    console.log();
}

