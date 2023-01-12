'use strict';

//js 내장되어 있는 오브젝트
// Promist is a JavaScript object for asynchronous operation.
// state : pending -> fulfilled or rejected

// Producer vs Consumer

// 1. Producer
 //resolve : 마지막에 최종 데이터를 전달, reject : 중간에 문제가 생기면 호출 파라미터
 //excuter가 바로 실행됨(when new Promise is created, the executor runs automatically)
 const promise = new Promise((resolve,reject)=>{
  //doing some heavy work(network, read files)
  console.log('doing something....');
  setTimeout(()=>{
    resolve('ellie')
    reject(new Error('no network'))
  },2000);
 });

 // 2. Consumers: then, catch, finally
 promise
 .then((value)=>{
    console.log(value);
 })
 .catch(error=>{
  console.log(error);
 })
 .finally(()=>{console.log('finally')});

 // 3. Promise chaining
 console.clear();
 const fetchNumber = new Promise((resolve,reject)=>{
  setTimeout(()=>
  resolve(1),1000)
 });
 fetchNumber
 .then(num=>num*50)
 .then(num=>num*3)
 .then(num=>{
    return new Promise((resolve,reject)=>{
      setTimeout(()=> resolve(num-1),1000);
    });
 })
 .then(num=>console.log(num));

 // 4. Error Handling
 const getHen = () =>
 new Promise((resolve,reject)=>{
  setTimeout(() => { resolve('HEN')}, 1000);
 });
 const getEgg = hen => 
 new Promise((resolve,reject)=>{
  setTimeout(()=> {resolve(`${hen} => EGG`),1000});
 });
 const cook = egg =>
 new Promise((resolve,reject)=>{
  setTimeout(()=>{resolve(`${egg} => chicken`),1000});
 });

getHen()
 .then(hen=>getEgg(hen))
 .then(egg=>cook(egg))
 .then(meal=>console.log(meal));




