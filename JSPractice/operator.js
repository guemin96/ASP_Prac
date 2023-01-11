// 1. String concatenation

console.log('my'+' cat');
console.log('1' + 2);
console.log(`string literals: 1+2 = ${1+2}`);

// 2. Numeric operators
console.log(1 + 1);
console.log(1 - 1);
console.log(1 / 1);
console.log(1 * 1);
console.log(5 % 2);
console.log(3 ** 2);

// 3. Increment and decrement operators
let counter = 2;
const preIncrement = ++counter;
//counter = counter +1;
//preIncrement = counter;
console.log(`preIncrement: ${preIncrement}, counter: ${counter}`);
const postIncrement = counter++;
// postIncrement = counter;
//counter = counter + 1;

//

//6. Logical operators: || (or), &&(and), !(not)
const value1 = false;
const value2 = 4 < 2;

// || or
console.log(`or: ${value1 || value2 || check()}`);

function check(){
  for(let i = 0; i < 10; i++)
  {
    //wasting time
    console.log('wow');
  }
  return true;
}

//7. Equality
const stringFive = '5';
const numberFive = 5;

// == loose equality, with type conversion
console.log(stringFive == numberFive);
console.log(stringFive != numberFive);

// === strict equality, no type conversion
console.log(stringFive === numberFive);
console.log(stringFive !== numberFive);

// object equality by reference 
const ellie1 = {name: 'ellie'};
const ellie2 = {name: 'ellie'};
const ellie3 = ellie1;
console.log('ellie true || false');
console.log(ellie1 == ellie2);
console.log(ellie1 === ellie2);
console.log(ellie1 == ellie3);
console.log(ellie1 === ellie3);

console.log('~~~~~~~~~~~~~~~~~~~~~~~~test~~~~~~~~~~~~~~~~~~~~~~~~~');
console.log(0 == false);
console.log(0 === false);
console.log('' == false);
console.log('' === false);
console.log(null == undefined);
console.log(null === undefined);

//8. Confitional operators : if
// if, else if, else
const name = 'df';
