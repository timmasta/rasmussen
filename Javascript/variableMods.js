//variableMods.js
//Varible basics - JavaScript - Tim Mastarone
/*    Ask the user for their first name and store it in the variable Fname. After the user types in their name, display a welcome message that contains the name they entered.
    Create the constant piValue to store the value of Pi to 7 significant digits (3.1415926).
    Ask the user to input their favorite number and store the value in a variable myFavNum
    Calculate the area of a circle using the user’s favorite number as the radius ( r )
    Store the result in a new variable myArea.
    The formula to find the area of a circle is A = πr2. 
    Use the value of Pi stored in the constant myPi.*/
const pi = 3.1415926;
function getUserName() {
    var Fname = prompt("Welcome new user, enter your name:");
    changeNameInHeader(Fname);
    alert("Welcome " + Fname);
    return Fname;
}
function getFavNum() {
    var myFavNum = prompt("Enter your favorite number:");
    return myFavNum;
}

function calcCircle() {
    var radius = parseFloat(getFavNum());
    var myArea = (radius ** 2) * pi;
    addAreaToHeader(myArea);
    alert("The area of a circle with your Favorite number as the radius is: " + myArea);
    
}

function changeNameInHeader(name) {
    // Access the h1 element by tag name
    var myHeader = document.querySelector('h1');

    // Modify the text in the h1 element to display the entered name
    myHeader.innerHTML = "Welcome to JavaScript " + name + "! Click the button to see JavaScript do some math.";
}

function addAreaToHeader(area) {
    // Access the h1 element by tag name
    var mySubHeader = document.querySelector('h2');

    // Modify the text in the h1 element to display the area
    mySubHeader.innerHTML = "The area of a circle with your Favorite number as the radius is " + area;
}
