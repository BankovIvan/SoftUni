//2.	Multiply Two Numbers

let arrX = ["2", "13", "1", "0"];
let arrY = ["3", "13", "2", "50"]

function MulTwoNumbers(numsX, numsY){
    if(Array.isArray(numsX)){
        var X = Number(numsX[0]);
    }
    else{
        var X = Number(numsX);
    }

    if(Array.isArray(numsY)){
        var Y = Number(numsY[0]);
    }
    else{
        var Y = Number(numsY);
    }

    return X * Y;
}

for (let i in arrX)
    console.log(MulTwoNumbers(arrX[i], arrY[i]));