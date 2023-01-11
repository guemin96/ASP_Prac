// Function

// 1. Function declaration

function printHello(){
  console.log('Hello');
}
printHello();

function log(message){
  console.log(message);
}
log('Hello@');
log(1234);

// 2. Parameters
function changeName(obj){
  obj.name = 'coder';
}

const ellie = {name:'ellie'};
console.log(ellie);
changeName(ellie);
console.log(ellie);

// 3. Default parameters (added in ES6)
function showMessage(message, from = 'PGM'){
  console.log(`${message} by ${from}`);
}
showMessage('Hi!');

// 4. Rest parameters (added in ES6)
function printAll(...args){
  for(let i = 0; i < args.length; i++){
    console.log(args[i]);
  }

  for(const arg of args)
  {
    console.log(arg);
  }

}
printAll('Park',' Gyu','Min');

// 5. Local scope
let globalMessage = 'global';
function printMessage(){
  let message = 'hello';
  console.log(message);
  console.log(globalMessage);
}
printMessage();

// 6. Return a value
function sum(a,b){
  return a+ b;
}
const result = sum(1,2);
const sumAgain = sum;
console.log(sumAgain(1,3));



// First - class function

// 1. Function expression
const print = function(){
  console.log('print');
}
print();
const printAgain = print;
printAgain();


// 2. Callback function using  function expression
function randomQuiz(answer, printYes, printNo){
  if( answer ==='love you')
  {
    printYes();
  }
  else
  {
    printNo();
  }
}
// anonymous function
const printYes = function(){
  console.log('yes!');
}
// named function
const printNo = function print(){
  console.log('No!');
}
randomQuiz('wrong',printYes,printNo);
randomQuiz('love you', printYes,printNo);

// arrow function

const simplePrint = function(){
  console.log('simplePrinn!');
};
const simplePrint2 = () =>console.log('simplyPrint');
const add = (a,b) => a + b;

const simpleMultiply = (a,b) => {
  return a * b;
};

(function hello(){
  console.log('IIFE');
})();

function calculate(command, a,b)
{
  let result;
  switch (command){
    case 'add':
        result = a+b;
      break;
    case 'substract':
      result = a-b;
      
      break;
    case 'divide':
      result = a/b;

      break;
    case 'multiply':
      result = a*b;

      break;
    case 'remainde':
      result = a%b;

      break;
    default:
      result ='command가 잘못되었습니다.'
    break;
    
  }
  return console.log(result);
}
calculate('add',100,2);
calculate('substract',100,2);
calculate('divide',100,2);
calculate('multiply',100,2);
calculate('remainde',100,2);
calculate('???',100,2);