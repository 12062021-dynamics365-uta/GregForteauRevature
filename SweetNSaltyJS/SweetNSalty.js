let i =1; // iterator for loop
let b =1; // iterator for 20 loop
let sweet = 0;
let salty = 0;
let sweetNsalty = 0;
var array = new Array();

while(i < 1001){

    while(b <= 20)
    {
        if(i % 3 == 0 && i % 5 == 0)
        {
            array.push("sweetNsalty");
            sweetNsalty++;

        }
        else if(i % 3 == 0)
        {
            array.push("sweet");
            sweet++;
        }
        else if(i % 5 == 0)
        {
            array.push("salty");
            salty++;
    }
    else
    {
        array.push(i);
    }
    b++;
    i++;
}
b = 1; // restart the 20
console.log(array.toString());
array = []
}
// count of strings 

console.log('There is ' + sweet + ' sweet count.');
console.log('There is ' + salty +' salty count');
console.log('There is ' + sweetNsalty + ' sweetNsalty count');