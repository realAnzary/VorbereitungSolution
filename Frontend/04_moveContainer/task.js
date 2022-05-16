// 2. Ändere die Hintergrund- und Randfarbe vom Container #MoveContainer
var moveContainer = document.getElementById("move-container");
moveContainer.style.backgroundColor = "green";
moveContainer.style.borderColor = "yellow";
// 3. Hänge einen click-Eventlistener an den Button #ToggleMoveContainerBtn, der den Container #MoveContainer ein- bzw. ausblendet
var isVisible = true;
var btnVisibilty = document.getElementById("toggle-move-container-btn");
btnVisibilty.addEventListener("click", () => {
    if (isVisible) {
        console.log("Hide");
        moveContainer.style.display = "none";
        btnVisibilty.value = "Zeigen";
        isVisible = false;
    } else {
        console.log("Show");
        moveContainer.style.display = "block";
        btnVisibilty.value = "Verstecken";
        isVisible = true;
    }
})


var moveToRight = true;
var moveContainerBtn = document.getElementById("move-container-btn");
moveContainerBtn.addEventListener("click", () => {
    leftPos = moveContainer.style.left.replace("px", "");
    stepsInput = document.getElementById("move-container-steps")
    steps = parseInt(stepsInput.value)

    if (moveToRight && leftPos > screen.width) {
        moveToRight = false;
    }
    if (!moveToRight && leftPos < 0) {
        moveToRight = true;
    }

    if (leftPos != "") {
        leftPos = parseInt(leftPos);
    }

    if (moveToRight) {
        moveContainer.style.left = `${leftPos + steps}px`;
    } else {
        moveContainer.style.left = `${leftPos - steps}px`;
    }
})
var stepsBox = document.getElementById("move-container-steps");
stepsBox.addEventListener("change", () => {
    if (stepsBox.value == "") {
        stepsBox.value = 100;
    }
})

// 4. Erstelle einen zweiten Button #ToggleContainerBtn, der per Klick den Container #MoveContainer nach rechts bzw. links verschiebt.