const mathOperators = ['+','-','/','*','='];


function mathCalculator(expression){
    let result = 0,
        startIndex = 0;
        iterOperators = [],
        numbers = [];

    for(let i = 0; i < expression.length; i++){
        if(mathOperators.includes(expression[i])){
            iterOperators.push(i);
        }
    }

    for(let i = 0; i < iterOperators.length; i++){   
        let number = +expression.slice(startIndex, iterOperators[i]);
        startIndex = iterOperators[i] + 1;
        numbers.push(number);
    }

    result = numbers[0];
    for(let i = 0; i < iterOperators.length - 1; i++){
        result = myEval(expression[iterOperators[i]], result, numbers[i + 1]);
    }
    return result.toFixed(2);
    
}

function myEval(char, firstNum, secondNum){
    switch(char){
        case '+':
            return firstNum + secondNum;
        case '-':
            return firstNum - secondNum;
        case '*':
            return firstNum * secondNum;
        case '/':
            return firstNum / secondNum;
        default:
            console.log('Something wrong, I can feel it...');
    }
}

console.log(mathCalculator('3.5 +4*10-5.3 /5 ='));