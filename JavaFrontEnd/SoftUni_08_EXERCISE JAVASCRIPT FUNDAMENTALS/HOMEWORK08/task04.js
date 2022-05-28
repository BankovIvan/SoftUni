//4.	Product of 3 Numbers

let arrX = ["2", "5", "-3"]
let arrY = ["3", "4", "-4"];
let arrZ = ["-1", "3", "5"];

function ProductOf3Numbers(X, Y, Z){
    var ret = true;

    if(X != 0 && Y != 0 && Z != 0){
        if(X < 0) ret = !ret;
        if(Y < 0) ret = !ret;
        if(Z < 0) ret = !ret;
    }

    return ret;
}

for (let i in arrX){
    if(ProductOf3Numbers(arrX[i], arrY[i], arrZ[i]) == true){
        console.log("Positive");
    }
    else{
        console.log("Negative");
    }
}

