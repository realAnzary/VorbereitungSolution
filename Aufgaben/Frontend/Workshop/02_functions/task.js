function showError(error) {
    var errorMessage = "Achtung, folgender Fehler ist aufgetreten: ";
    errorMessage += error;
    var errorWarning = document.getElementById("ErrorWarnings");
    errorWarning.innerText = errorMessage;
    errorWarning.style.display = "block";
}