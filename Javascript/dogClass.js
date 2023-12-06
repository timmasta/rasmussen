/*dogClass.js, Module 04 assignment*/
/*Gecko	generic	Duckman	Duckman's purple dog; based on characters created by Everett Peck in his Dark Horse publication.*/

// Define the object literal
const dog = {
    name: 'Gecko',    
    creator: 'Duckman',
    mySound: "My real name is Sparky, Duckman stole me and changed my name to Gecko",
    breed: "Mutt",

    // Method to display information about the character
    displayInfo: function () {
        // Using template literals to create a text paragraph
        const paragraph = `This is the object literal version of the dog:\
                           \nHi my name is ${this.name}. When I bark I am saying "${this.mySound}".\
                           \nI starred in the animated TV show Duckman. I have been told by Duckman that my breed is '${this.breed}'.\
                           \nI was the family dog in Duckman's house in the TV show.`;        
        console.log(paragraph);
        alert(paragraph);
    },
};

// Define the constructor function
function Dog(name, creator, mySound, breed, canTalk) {
    this.name = name;
    this.creator = creator;
    this.mySound = mySound;
    this.breed = breed;
    this.canTalk = canTalk;

    // Method to display information about the character
    this.displayInfo = function () {
        // Using template literals to create a text paragraph
        const paragraph = `Hi my name is ${this.name}. When I bark I am saying "${this.mySound}".\
                           \nI starred in the animated TV show Duckman. I have been told by Duckman that my breed is '${this.breed}'.\
                           \nI was the family dog in Duckman's house in the TV show.`;

        console.log(paragraph);
        alert(paragraph);
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
function createDogInstance(){
    // Create an instance of the Dog constructor
    const myDogConst = new Dog('Gecko', 'Duckman', "My real name is Sparky, Duckman stole me and changed my name to Gecko", 'Mutt', true);

    // Call the displayInfo method
    myDogConst.displayInfo();

    // Call the myGreeting method
    myDogConst.myGreeting();
}


