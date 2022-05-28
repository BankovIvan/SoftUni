//3.	Multiply / Divide a Number by a Given Second Number

let arrN = ["2", "13", "3", "144"];
let arrX = ["3", "13", "2", "12"]

function MultiplyDivide(N, X){
    var ret;
    var n = Number(N);
    var x = Number(X);

    if(x >= n){
        ret = n * x;
    }
    else{
        ret = n / x;
    }

    return ret;
}

for (let i in arrN)
    console.log(MultiplyDivide(arrN[i], arrX[i]));
