// variables list

let instruct = document.createElement('h3');
let userInput = document.createElement('input');
let nextButton = document.createElement('button');
let goButton = document.createElement('button');
let newLine = document.createElement('p');
let start = 0;
let end = 0;
let sweet = document.createElement('p');
let salty = document.createElement('p');
let sweetNsalty = document.createElement('p');

let title = document.createElement('h1');
document.body.appendChild(title);
title.innerText = 'sweetNsalty COUNTER';

let startButton = document.createElement('button');
document.body.appendChild(startButton);
startButton.innerText = 'Click to proceed';

//enter first number
startButton.addEventListener('click', (e) => {
    document.body.innerHTML = '';
    document.body.appendChild(instruct);
    instruct.innerText = 'Enter initial number in field';
    document.body.appendChild(userInput);
    document.body.appendChild(nextButton);
    nextButton.innerText = 'Click button to proceed'
})
//enter second number
   nextButton.addEventListener('click', (e) => {
    document.body.innerHTML = '';
    start = parseInt(userInput.value);
    userInput.value = '';
    document.body.appendChild(instruct);
    instruct.innerText = 'Enter secondary number';
    document.body.appendChild(userInput);
    document.body.appendChild(goButton);
    goButton.innerText = 'Click button to proceed'
})

goButton.addEventListener('click', (e) => {
    document.body.innerHTML = '';
    end = parseInt(userInput.value);
    userInput.value = '';
    if (checkInputs(start, end)){
        counter(start, end);
    }
    else document.write('Something not right')
})

//function to validate input range

function checkInputs(start, end){
    if ((end - start) < 200){
        alert('Invalid, number should be more than 200 ')
        return false;
    }
    else if ((end - start) > 10000){
        alert('Invalid, range from 200 to 10000')
        return false;
    }
    else if (start < 0 || end < 0){
        alert('Number must be a positive number')
        return false;
    }
    return true;
}
//while loop function of sweetNsalty
function counter(start, end){
    let i = start; 
    let b = 1; 
    var sweet = 0; //  total number of sweet
    var salty = 0; // total number of salty
    var sweetNsalty = 0; 
    let array = new Array();
    
    while (i <= end) //  loop to 10000
    {
        document.body.appendChild(newLine)
        while (b <= 40) // While loop for line segments
        {
            if (i % 3 == 0 && i % 5 == 0) // number is divisible by 3 and 5
            {
                array.push("sweetNsalty"); 
                sweetNsalty++; 
            }
            else if (i % 3 == 0) 
            {
                array.push("sweet"); // Writes sweet 
                sweet++; 
            }
            else if (i % 5 == 0) // number is divisible by 5
            {
                array.push("salty"); // Writes salty
                salty++; 
            }
            else
            {
                array.push(i); // Writes the number
            }
            b++; 
            i++; 
        }
        b = 1; // Restarts the line iterator
        console.log(array.toString()); // Breaks the line to go to the next line
        newLine.innerText = array.toLocaleString();
        array = [];
    }
    console.log(`There were ${sweet} sweet numbers.`); //write the number of sweet
    console.log(`There were ${salty} salty numbers.`); //  write the number of salty    
    console.log(`There were ${sweetNsalty} sweetNsalty numbers.`); //  write the number of sweetNsalty 
    
}