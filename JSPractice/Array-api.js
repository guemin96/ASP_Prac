// 01. make a string out of an array
{
    const fruits = ['apple','banana','orange'];
    console.log(fruits.join('-'));
}
// 02. make an array out of a string
{
    const fruits = 'apple, banana, orange';
    console.log(fruits.split(',',2));

}
// 03. make this array look like this : [5,4,3,2,1]
{
    const array = [1,2,3,4,5];
    console.log(array.reverse());
}
// 04. make new array without the first two elements
{
    const array = [1,2,3,4,5];
    console.log(array.slice(2,5));
    console.log(array.splice(0,2));
    console.log(array);
}

class Student{
    constructor(name, age, enrolled, score){
        this.name = name;
        this.age = age;
        this.enrolled = enrolled;
        this.score = score;
    }
}
const students = [
    new Student('A', 29, true, 45),
    new Student('B', 28, false, 80),
    new Student('C', 30, true, 90),
    new Student('D', 40, false, 66),
    new Student('E', 18, true, 88),
]
// 05. find a student with the score 90
{
    // My Code
    students.forEach(element => {
        if(element.score>=90)
        {
            console.log(element);
        }
    });
    //Answer
    console.log(students.find(element=>element.score===80));
    console.clear();
    console.log(
        students.find(function(student,index){
            return student.score === 90
        })
    )

}
// 06. make an array of enrolled students
{
    console.clear();
    const result = students.filter(function(student,index) {
       return student.enrolled;
    })
    console.log(result);
}

// 07. make an array containing only the student's score
// result should be : [45,80,90,66,88]
{
    console.clear();
    const result = students.map(student=>student.score);
    console.log(result);
}

// 08. check if there is a student with the score lower than 50
{
    console.clear();
    const result = students.some(student=>student.score<50);
    console.log(result);
}
// 09. compute students' average score
{
    console.clear();
    const result = students.reduce((prev,curr)=>{
        console.log('--------');
        console.log(prev);
        console.log(curr);
        return prev + curr.score;
    },0);
    console.log(result/students.length);
}
// 10. make a string containing all the scores
{
    console.clear();
    const result = students.map(student => student.score).filter(score=>score>=50).sort((a,b)=>b-a).join();
    //console.log(result.toString());
    console.log(result);
}