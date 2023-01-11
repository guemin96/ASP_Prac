//1. Objects

//const name = 'ellie';
//const age = 4;
//print(name, age);

const obj1 = {};
const obj2 = new Object();

function print(person){
  console.log(person.name);
  console.log(person.age);
}

const ellie = {name: 'ellie',age:4};
print(ellie);

ellie.hasJob = true;

console.log(ellie.hasJob);

delete ellie.hasJob;
console.log(ellie.hasJob);

// 2. Computed properties
console.log(ellie.name);
console.log(ellie['name']);