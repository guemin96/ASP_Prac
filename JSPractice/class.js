'use strict';

//JavaScript classes

//1. Class declarations
class Person{
  constructor(name, age){
    this.name = name;
    this.age = age;
  }
  speak(){
    console.log(`${this.name}: hello!`);
  }
}
const ellie = new Person('ellie',20);
console.log(ellie.name);
console.log(ellie.age);


//2. Getter and Setters
class User{
  constructor(firstName, lastName, age){
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
  }
  get age(){
    return this._age;
  }
  set age(value){
    this._age = value<0 ? 0 : value;
  }
}
const user1 = new User('Steve','Job',-1);
console.log(user1.age);


//4. Static properties and methods
//Too soon!
class Article{
  static publisher = 'Dream coding';
  constructor(articleNumber){
    this.articleNumber = articleNumber;
  }
  static printPublisher(){
    console.log(Article.publisher);
  }
}
const articles1 = new Article(1);
const articles2 = new Article(2);
console.log(articles1.articleNumber); 
console.log(articles2.articleNumber);
Article.printPublisher();
//articles1.printPublisher();
//articles2.printPublisher();



//5. 
class Shape{
  constructor(width, height, color){
    this.width = width;
    this.height = height;
    this.color = color;
  }
  draw(){
    console.log(`drawing ${this.color} color!`);
  }
  getArea(){
    return this.width * this.height;
  }
}
class Rectangle extends Shape{}
class Triangle extends Shape{
  getArea(){
    return (this.width * this.height)/2;
  }
}

const rectangle = new Rectangle(20,20,'blue');
rectangle.draw();
console.log(rectangle.getArea());
const triangle = new Triangle(20,20,'red');
triangle.draw();
console.log(triangle.getArea());

// 6. class checking: instanceOf
console.log(rectangle instanceof Rectangle);
console.log(triangle instanceof Rectangle);
console.log(triangle instanceof Triangle);
console.log(triangle instanceof Shape);
console.log(triangle instanceof Object);