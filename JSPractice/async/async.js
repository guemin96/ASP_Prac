// async & await
// clear style of using promise

// 1. async
// function fetchUser(){
//     // do network request in 10 secs.....

//     return new Promise((resolve,reject)=>{

//         resolve('ellie')

//     });
// }

async function fetchUser(){
    return 'ellie';
}



const user = fetchUser();
//console.log(user);
user.then(console.log);
console.log(user);


// 2. await
function delay(ms){
    return new Promise(resolve => setTimeout(resolve,ms));
}

async function getApple(){
    await delay(4000);
    //throw 'error';
    return 'apple';
}
async function getBanana(){
    await delay(2000);
    //throw 'error';
    return 'banana';
}

// function pickFruits(){
//     return getApple()
//     .then(apple => {
//         return getBanana()
//         .then(banana =>`${apple} + ${banana}`);
//     });
// }

async function pickFruits(){

    // const applePromise = getApple();
    // const bananaPromise = getBanana();
    // const apple = await applePromise;
    // const banana = await bananaPromise;

    const apple = await getApple();
    const banana = await getBanana();

    return `${apple}+${banana}`;


    //return `${apple}+${banana}`;
}

pickFruits().then(console.log)



// 3. useful Promise APIs
function pickAllFruits(){
    return Promise.all([getApple(),getBanana()])
    .then(fruits => fruits.join('+'));
}

pickAllFruits().then(console.log)


function pickOnlyOne(){
    return Promise.race([getApple(),getBanana()]);
}
pickOnlyOne().then(console.log);