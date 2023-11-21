/*numbers.js*/

function evenOrOdd(count) {
    //Print a header
    document.write("<h3>Count to 10 and print if the number is even or odd:</h3>");
    for (var i = 1; i < (count + 1); i++) {
        if (i % 2 === 0) {
            document.write("Count " + i + " is even");
            document.write("<br>");
        }
        else {
            document.write("Count " + i + " is odd");
            document.write("<br>");
        }
    }
    //add a line break to improve the page's appearance
    document.write("<br>");
}

function enterNumber() {
    var valid = false;
    var input;
    var counter = 1;
    while (!valid) {
        input = prompt("Enter a number between 5 and 20");
        input = parseInt(input);//convert the string input to an integer
        if ((input >= 5) && (input <= 20)) {
            valid = true;
        }
        else {
            valid = false;
        }
    }
    //The user entered value is between 5 and 20 so we move on

    //Print a header
    document.write("<h3>Display all numbers before and including the number entered by the user:</h3>");
    do {
        document.write("Counter is: " + counter);
        document.write("<br>");
        counter += 1;
    }
    while (counter < (input + 1));//last loop is the user entered number

    //add a line break to improve the page's appearance
    document.write("<br>");
}

function showSubjects() {
    const subjects = ["Accounting", "Algebra", "Programming", "Art", "Data Analytics"];
    let text = "";

    //Print a header
    document.write("<h3>Display the list of subjects from the array:</h3>");

    //Print an intro line before the subject array values
    document.write("The subject list is: ");

    //Print each string in the array with a comma separating them
    subjects.forEach(function (element, index) {
        document.write(element);

        // Check if it's the last element before adding a comma
        if (index < subjects.length - 1) {
            document.write(", ");
        }

    });
}
