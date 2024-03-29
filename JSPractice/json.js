// Json
// JavaScript Object Notation

// 1. Object to JSON
// stringfy(obj)
let json = JSON.stringify(true);
console.log(json);

json = JSON.stringify(['apple','banana']);
console.log(json);

const rabbit = {
  name:'tori',
  color:'white',
  size: null,
  birthDate: new Date(),
  //symbol: Symbol('id'),
  jump: () =>{
    console.log(`${name} can jump!`);
  },
}
json = JSON.stringify(rabbit);
console.log(json);

json = JSON.stringify(rabbit,["name"]);//원하는 속성만 json데이터로 뽑아낼 수 있음
console.log(json);

json = JSON.stringify(rabbit,(key,value)=>{
  console.log(`key: ${key}, value : ${value}`);
  return value;
});
console.log(json);


// 2. JSON to Object
// parse(json)

console.clear();
json = JSON.stringify(rabbit);
const obj = JSON.parse(json,(key,value)=>{
  console.log(`key: ${key}, value : ${value}`);
  return key ==='birthDate' ? new Date(value): value;
}); 
  
console.log(obj);
rabbit.jump();

console.log(rabbit.birthDate.getDate());

console.log(obj.birthDate);
console.log(obj.birthDate.getDate());


