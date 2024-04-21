
function solve() {
const toElement = document.getElementById('selectMenuTo');
const numberElement = document.getElementById('input');
const buttonElement = document.querySelector('button');
const resultElement = document.getElementById('result');

let optionHexa = document.querySelector('#selectMenuTo option');
let optionBinary = document.createElement('option');
optionHexa.value = 'hexadecimal';
optionBinary.value = 'binary';
optionBinary.textContent = 'Binary';
optionHexa.textContent = 'Hexadecimal';
toElement.add(optionBinary,0);

buttonElement.onclick = function() { 
    convert() 
}; 
function convert(){
    let number = parseInt(numberElement.value);
    let output ='';
    if(toElement.value==='binary'){
       output = number.toString(2);
    }else if(toElement.value==='hexadecimal'){
       output = number.toString(16).toUpperCase();
    }
    resultElement.value = output;
}
}