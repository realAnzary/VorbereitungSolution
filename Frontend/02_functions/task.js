function showError(error) {
    var errorMessage = "Achtung, folgender Fehler ist aufgetreten: ";
    errorMessage += error;
    var errorWarning = document.getElementById("ErrorWarnings");
    errorWarning.innerText = errorMessage;
    errorWarning.style.display = "block";
}

function clearError() {
    errorfield = document.getElementById("ErrorWarnings")
    errorfield.innerText = "";
}

var helloWorldBtn = document.getElementById("btn-submit");
helloWorldBtn.addEventListener("click", function() {
    input = document.getElementById("TextInput");
    alert(`Willkommen auf der Seite, ${input.value}`);
});

var checkBtn = document.getElementById("btn-check");
checkBtn.addEventListener("click", function() {
    input = document.getElementById("TextInput");
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
    //ToDO
})