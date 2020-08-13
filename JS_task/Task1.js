function charRemover(inputString){
    let outputString = "";
    let startIndex = 0;
    for (let i = 0; i <= inputString.length; i++) {
        if(inputString[i] === ' ' || i === inputString.length){
            wordCharRemover(inputString.slice(startIndex, i));
            startIndex = i + 1;
        }
    }
    
}

function wordCharRemover(word){
    return console.log(word);
}

charRemover("Hello, how are u?ф")