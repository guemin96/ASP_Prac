'use strict';

//JavaScript is synchronous.
//Execute the code block by orger after hoisting.
//hoisting: var, function declaration이 가장 위로 올라가는것


//Callback Hell example
class UserStorage
{
  //사용자 로그인 api 
  loginUser(id, password){
    return new Promise((resolve,reject)=>{
      setTimeout(() => {
        if (
          (id === 'ellie' && password ==='dream') ||
          (id === 'coder' && password ==='academy')
        )
        {
          resolve(id);
        }
        else{
          reject(new Error('not found'));
        }
      }, 2000);
    });
  }
  // 사용자마다 가지고 있는 역할에 대한 정보
  getRoles(user){
    return new Promise((resolve, reject)=>{
      setTimeout(()=>{
        if(user === 'ellie')
        {
          resolve({name:'ellie',role:'admin'});
        }
        else{
          reject(new Error('no access'));
        }
      },1000);
    });
  }
}

const userStorage = new UserStorage();
const id = prompt('enter your id');
const password = prompt('enter your password');

async function checkUser(){
    try{
        const userID = await userStorage.loginUser(id,password);
        const user = await userStorage.getRoles(userID);
        alert(`Hello ${user.name}, you have a ${user.role}`);

    }
    catch{
        console.log('error');
    }
};

checkUser();

// userStorage.loginUser(id,password)
// .then(userStorage.getRoles)
// .then(userwithRole => alert(`Hello ${userwithRole.name}, you have a ${userwithRole.role} role`))
// .catch(console.log('전송실패'));


