var helloWorldBtn = document.getElementById("btn-submit");
helloWorldBtn.addEventListener("click", function() {
    // Function to alert user and greet with name
    input = document.getElementById("text-input");
    alert(`Willkommen auf der Seite, ${input.value}`);
});

var checkBtn = document.getElementById("btn-check");
checkBtn.addEventListener("click", function() {
    // Function to check the input field if its a number 
    input = document.getElementById("text-input");
    if (isNumeric(input.value)) {
        input.value = input.value * 2;
    } else {
        showError("Eingabe ist keine Zahl oder beinhaltet Zeichen");
    }
});

var clearBtn = document.getElementById("btn-clear");
clearBtn.addEventListener("click", function() {
    // Function to clear the error box
    clearError()
});

var calcBtn = document.getElementById("btn-calculate");
calcBtn.addEventListener("click", function() {
    // Function to make the "calculator work
    number1 = document.getElementById("number-input1");
    number2 = document.getElementById("number-input2");
    out = document.getElementById("number-output");
    console.log(`Num1:${number1.value} | Num2:${number2.value}`);

    if (isNumeric(number1.value)) {
        console.log("Num1 is Number");
    } else { showError("Input 1 not a Number"); };

    if (isNumeric(number2.value)) {
        console.log("Num2 is Number");
    } else { showError("Input 2 not a Number"); };

    if (isNumeric(number1.value) && isNumeric(number2.value)) {
        operations = document.getElementById("select-math");
        switch (operations.value) {
            case "+":
                console.log("Operation: +");
                out.value = +number1.value + +number2.value;
                break;

            case "-":
                console.log("Operation: -");
                out.value = +number1.value - +number2.value;
                break;

            case "*":
                console.log("Operation: *");
                out.value = +number1.value * +number2.value;
                break;

            case "/":
                console.log("Operation: /");
                out.value = +number1.value / +number2.value;
                break;
        }
    }
})

function showError(error) {
    // Creates an error message and shows it in the error box
    var errorMessage = "Achtung, folgender Fehler ist aufgetreten: ";
    errorMessage += error;
    var errorWarning = document.getElementById("error-warnings");
    errorWarning.innerText = errorMessage;
    errorWarning.style.display = "block";
}

function isNumeric(str) {
    // Checks if string is just a number
    if (typeof str != "string") return false
    return !isNaN(str) &&
        !isNaN(parseFloat(str))
}

function clearError() {
    // Clears the error box
    errorfield = document.getElementById("error-warnings")
    errorfield.innerText = "";
}