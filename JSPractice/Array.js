'use strict';

// Array

// 1. Declaration
const arr1 = new Array();
const arr2 = [1,2];

// 2. Index position
const fruits = ['apple','banana'];
console.log(fruits);
console.log(fruits.length);
console.log(fruits['name']);

// 3. Looping over an array
// print all fruits

for(let i = 0; i < fruits.length; i++)
{
    console.log(fruits[i]);
}

fruits.forEach(function(fruit,Index,array){
//console.length('he');
console.log(fruit,Index,array);
});

fruits.forEach((fruit)=> console.log(fruit));


// 4. Addtion, deletion, copy
// push: add an item to the end
 
fruits.push('peach','strawberry');
console.log(fruits);

// pop: remove an item from the end
fruits.pop();
console.log(fruits);

// unshift: add an item to the beginning

fruits.unshift('peach','strawberry');
console.log(fruits);

// shift :
fruits.shift();
fruits.shift();
console.log(fruits);

//remove an item by index position
fruits.splice(1,1);
console.log(fruits);

fruits.splice(1,1,'watermelon','melon');
console.log(fruits);

//combine two arrays
const fruits2 = ['grapes','tomato'];
const newFruits = fruits.concat(fruits2);
console.log(newFruits);


// 5. searching
// find the index

console.log(fruits);
console.log(fruits.indexOf('apple'));
console.log(fruits.indexOf('melon'));
console.log(fruits.includes('watermelon'));
console.log(fruits.includes('peach'));


//lastIndexOf
console.clear();
fruits.push('apple');
console.log(fruits);
console.log(fruits.indexOf('apple'));
console.log(fruits.lastIndexOf('apple'));


console.log(fruits.join('-'));

//slice
console.log(fruits.slice(1,3));
//console.log(fruits);

console.log( fruits.every(num => num.length>6));
console.log( fruits.some(num => num.length>4));


console.log(fruits.map(function(element){
    return element + '?'
}));
console.log(fruits);