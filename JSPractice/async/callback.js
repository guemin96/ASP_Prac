'use strict';

//JavaScript is synchronous.
//Execute the code block by orger after hoisting.
//hoisting: var, function declaration이 가장 위로 올라가는것

function printImmediately(print){
  print();
}

function printWithDelay (print, timeout){
  setTimeout(print,timeout);
}

//console.log('1');
//setTimeout(()=>
//  console.log('2')
//,2000);
//console.log('3');
//console.log('4');

// Synchronous callback

printImmediately(()=> console.log('hello'));

// Asynchronous callback

printWithDelay(()=> console.log('async callback'), 2000);

//Callback Hell example
class UserStorage
{
  //사용자 로그인 api 
  loginUser(id, password, onSuccess, onError){
    setTimeout(() => {
      if (
        (id === 'ellie' && password ==='dream') ||
        (id === 'coder' && password ==='academy')
      )
      {
        onSuccess(id);
      }
      else{
        onError(new Error('not found'));
      }
    }, 2000);
  }
  // 사용자마다 가지고 있는 역할에 대한 정보
  getRoles(user, onSuccess, onError){
    setTimeout(()=>{
      if(user === 'ellie')
      {
        onSuccess({name: 'ellie', role: 'admin'});
      }
      else{
        onError(new Error('no access'));
      }
    })
  }
}

console.clear();

let test = new UserStorage();
const id = prompt('enter your id');
const password = prompt('enter your password');

//콜백 함수 디버깅으로 잘까보기
test.loginUser(
  id,
  password,
  user =>{
    test.getRoles(
      user,
      (userwithRole)=>{
        alert(`Hello ${userwithRole.name}, you have a ${userwithRole.role} role`);
      }, 
      (error=>{
        console.log(error);
      }
      )
    );
  },
  error => {
    console.log(error);
  }
);