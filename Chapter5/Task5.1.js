const punctuationChars = ['(','?','!',':',';',',','.',')'];


function charRemover(inputString){
    let repeatedChars = [];
    let startIndex = 0;
    for (let i = 0; i <= inputString.length; i++) {
        if(inputString[i] === ' ' || i === inputString.length){
            let temp = getRepeatedCharsInWord(inputString.slice(startIndex, i));
            if(temp.length !== 0){
                temp.forEach((item) => {repeatedChars.push(item);});
            }
            startIndex = i + 1;
        }
    }
    let outputString = "";
    for(let i = 0; i < inputString.length; i++){
        if(!repeatedChars.includes(inputString[i].toLowerCase())){
            outputString += inputString[i];
        }
    }
    console.log(outputString);
}

function getRepeatedCharsInWord(word){
    let result = [];
    for(let i = 0; i < word.length; i++){
        if(punctuationChars.includes(word[i])){
            continue;
        }
        else{
            if(!(word.lastIndexOf(word[i]) === word.indexOf(word[i])) && !result.includes(word[i])){
                result.push(word[i].toLowerCase());
            }
        }
    }
    return result;
}

charRemover("У меня была гитара, я её продал. А молодец! У меня была подружка, я её прогнал. А так и надо!" +
            " У меня была вертушка, я её пропил. Давай-давай! У меня была мечта, но я её забыл, Забыл...");