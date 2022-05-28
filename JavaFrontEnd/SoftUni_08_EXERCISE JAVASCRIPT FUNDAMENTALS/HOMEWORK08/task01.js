//1.  Multiply a Number by 2

let numbers = ["2", '3', '30', "13"];

function mul2(nums){
    if(Array.isArray(nums)){
        var num1 = Number(nums[0]);
    }
    else{
        var num1 = Number(nums);
    }

    return num1 * 2;
}

for (let i in numbers)
    console.log(mul2(numbers[i]));