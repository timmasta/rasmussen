/*dogClass.js, Module 05 assignment*/
/*3 dogs from TV shows.*/



// Define the constructor function
function Dog(name, creator, mySound, breed, canTalk) {
    this.name = name;
    this.creator = creator;
    this.mySound = mySound;
    this.breed = breed;
    this.canTalk = canTalk;

    //Method to display each property with a for loop
    this.displayProperties = function () {
        // Create a table element
        document.write("<table border='1'>");

        // Create a table header with the 'name' property
        let title = this.name;
        document.write(`<thead><tr><th>${title}</th></tr></thead>`);

        // Iterate over each property and create a table row for it
        for (let prop in this) {
            if (this.hasOwnProperty(prop)) {
                document.write("<tr>");
                // Create table data cells for property name and value
                document.write(`<td>${prop}</td><td>${this[prop]}</td>`);
                document.write("</tr>");
            }
        }

        // Close the table element
        document.write("</table>");
    };  

    // Method to display a greeting which varies based on the boolean argument passed in
    this.myGreeting = function () {
        if (this.canTalk) {
            console.log(`Hello, I can talk! My name is ${this.name}.`);
            alert(`Hello, I can talk! My name is ${this.name}.`);
        } else {
            console.log(`Hello, I cannot talk, but I'm still awesome. My name is ${this.name}.`);
            alert(`Hello, I cannot talk, but I'm still awesome. My name is ${this.name}.`);
        }
    };
}

//Instantiate new Dog and call both methods (from object literal and from the Dog class)
//This is all in one function so it can be called when the page is loaded
function createDogInstance(name, show, phrase, breed, canTalk){
    // Create an instance of the Dog constructor
    const myDogConst = new Dog(name, show, phrase, breed, canTalk);

    // Call the myGreeting method
    myDogConst.myGreeting();

   //return the created instance for use elsewhere
    return myDogConst;
    
    
}

