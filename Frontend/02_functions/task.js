function showError(error) {
    var errorMessage = "Achtung, folgender Fehler ist aufgetreten: ";
    errorMessage += error;
    var errorWarning = document.getElementById("ErrorWarnings");
    errorWarning.innerText = errorMessage;
    errorWarning.style.display = "block";
}

function isNumeric(str) {
    if (typeof str != "string") return false
    return !isNaN(str) &&
        !isNaN(parseFloat(str))
}

function clearError() {
    errorfield = document.getElementById("ErrorWarnings")
    errorfield.innerText = "";
}

var helloWorldBtn = document.getElementById("btn-submit");
helloWorldBtn.addEventListener("click", function() {
    input = document.getElementById("text-input");
    alert(`Willkommen auf der Seite, ${input.value}`);
});

var checkBtn = document.getElementById("btn-check");
checkBtn.addEventListener("click", function() {
    input = document.getElementById("text-input");
    if (!isNaN(input.value)) {
        input.value = input.value * 2;
    } else {
        showError("Eingabe ist keine Zahl oder beinhaltet Zeichen");
    }
});

var clearBtn = document.getElementById("btn-clear");
clearBtn.addEventListener("click", function() {
    clearError()
});

var calcBtn = document.getElementById("btn-calculate");
calcBtn.addEventListener("click", function() {
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