//serviceScript.js
/*
Create a script that calculates the amount of tip to leave for a service.

Prompt the user to enter the dollar amount of the service and ask if the service quality was great, ok, or poor 
    (assume great service gets a 20% tip, Ok service 15%, poor service 10%).
Create a function to verify a valid service quality was entered.
If an invalid value is entered, display a message and end the code.
Create a function to verify a service amount between $5.00 and $500.00 was entered.
If an invalid value is entered, display a message and end the code.
Create a function to calculate the tip amount and return the value.
If valid values are entered, call the function to calculate the tip. 
    The tip amount is displayed to the user in a descriptive message that includes the service amount,
    the recommended tip, and the service quality the tip is based on.
*/
var tipRate = 0;
function greetUser() {    
    var dollarAmount = prompt("Enter the dollar amount of the service");
    if (checkDollarAmount(dollarAmount)) {
        let serviceQuality = prompt("Was the service quality great, ok, or poor?").toLowerCase();
        if (checkServiceQuality(serviceQuality)) {            
            let tipAmount = calculateTip(parseFloat(dollarAmount), serviceQuality);
            displayTipAndTotal(tipAmount, parseFloat(dollarAmount), serviceQuality)
        }
        else {
            alert("Invalid service quality entered, exiting");
        }
    }
    else {
        alert("Invalid dollar amount. Value should be between $5.00 and $500.00, exiting.");
    }
}
function checkServiceQuality(quality) {
    const serviceQualities = ["great", "ok", "poor"];
    if (serviceQualities.includes(quality)) {
        return true;
    }
    else {        
        return false;
    }
    
}

function checkDollarAmount(amount) {
    // Use parseFloat to handle potential non-numeric input
    amount = parseFloat(amount);

    // Check if the amount is a valid number and within the specified range - returns true if the number is in range
    return !isNaN(amount) && amount >= 5 && amount <= 500;
}

function calculateTip(checkAmount, quality) {
    //great 20% tip, Ok service 15%, poor service 10%
    if (quality === 'great') {
        tipRate = .2;
    }
    else if (quality === 'ok') {
        tipRate = .15;
    }
    else {
        tipRate = .1;
    }    
    return checkAmount * tipRate;
}

function displayTipAndTotal(tip, total, quality) {
    alert("The bill amount was: $" + total.toFixed(2) +
          "\nBased on the " + quality + " service " +
          "\nThe tip amount should be: $" + tip.toFixed(2));
}
