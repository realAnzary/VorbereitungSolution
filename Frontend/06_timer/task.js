// Vars
cheat = true;
gameRunning = false;
remainingTime = 0;
rightAnswer = 0;
points = 0;
timerId = 0;

// Dom Access

var startBtn = document.getElementById("dw-StartBtn");
startBtn.addEventListener("click", () => {
    console.log("Start");
    gameRunning = true;
    startBtn.style.display = "None";
    last.style.display = "Block";
    remainingTime = 15;
    points = 0;
    timerId = setInterval(timerFnc, 1000);
    newTask();
})

var answerBtns = document.getElementsByClassName("dw-Answer-Btn");
for (let index = 0; index < answerBtns.length; index++) {
    const element = answerBtns[index];
    element.focus();
    element.addEventListener("click", checkAnswer);
    element.addEventListener("keydown", function(event) {
        if (event.which == element.id) {
            console.log(`Pressed ${event.which}`);
        }
    });
}
var last = document.getElementById("dw-lastRound");
var score = document.getElementById("dw-Score");
var timer = document.getElementById("dw-Timer");
var task = document.getElementById("dw-Task");

// Fncs

function timerFnc() {
    if (remainingTime > 0) {
        remainingTime--;
        timer.innerText = `Time: ${remainingTime}`;
    } else {
        console.log("Time over");
        window.clearInterval(timerId);
        startBtn.style.display = "Block";
        last.style.display = "None";
        timer.innerText = `Time: Game Over`;
        gameRunning = false;
    }
}

function checkAnswer() {
    if (gameRunning) {
        if (this.value == rightAnswer) {
            console.log("Right");
            last.innerText = `Last Round: Right`;
            updateScore(1);
            addTime(5);
        } else {
            console.log("Wrong");
            last.innerText = `Last Round: Wrong`;
            addTime(-5);
        }
        newTask();
    } else {
        for (let index = 0; index < answerBtns.length; index++) {
            const element = answerBtns[index];
            element.value = "Starte a new Game";
        }
    }
}

function updateScore(toAdd) {
    points += toAdd;
    score.innerText = `Score: ${points}`;
}

function addTime(toAdd) {
    remainingTime += toAdd;
}

function newTask() {
    if (cheat) {

        for (let index = 0; index < answerBtns.length; index++) {
            const element = answerBtns[index];
            element.style.background = "Red";
        }
    }

    operations = ['+', '-', '*', '/'];
    selectedOp = operations[Math.floor(Math.random() * operations.length)];
    selectedOp2 = operations[Math.floor(Math.random() * operations.length)];
    num1 = Math.floor(Math.random() * 99 + 1);
    num2 = Math.floor(Math.random() * 99 + 1);
    num3 = Math.floor(Math.random() * 99 + 1);

    tmpResult = 0;
    result = 0;


    if (Math.floor(Math.random() > .5)) {
        result = calculate(num1, num2, selectedOp, true);
        task.innerText = `Aufgabe: ${num1} ${selectedOp} ${num2}`;
    } else {
        if ((selectedOp2 == '*' && (selectedOp == '+' || selectedOp == '-')) || (selectedOp2 == '/' && selectedOp != '/')) {
            tmpResult = calculate(num2, num3, selectedOp2, false);
            result = calculate(num1, tmpResult, selectedOp, true);
        } else {
            tmpResult = calculate(num1, num2, selectedOp, false);
            result = calculate(tmpResult, num3, selectedOp2, true);
        }
        task.innerText = `Aufgabe: ${num1} ${selectedOp} ${num2} ${selectedOp2} ${num3}`;
    }
    rightAnswer = parseFloat(result).toFixed(2);
    fakeResults(result);
}

function calculate(num1, num2, symbol, rounded) {
    switch (symbol) {
        case '+':
            return num1 + num2;
            break;
        case '-':
            return num1 - num2;
            break;
        case '*':
            return rounded ? (num1 * num2).toFixed(2) : num1 * num2;
            break;
        case '/':
            return rounded ? (num1 / num2).toFixed(2) : num1 / num2;
            break;
    }
}

function fakeResults(correctAnswer) {
    fakeAnswers = [];
    max = 20;
    min = -20;

    fakeAnswers.push(parseFloat(correctAnswer).toFixed(2));

    for (let i = 0; i < 3; i++) {
        let tmpAnswer = 0;
        let viableAnswer = true;
        do {
            viableAnswer = true;
            tmpAnswer = (parseFloat(correctAnswer) + Math.floor(Math.random() * (max - (min)) + (min))).toFixed(2);
            if (tmpAnswer == 0 || fakeAnswers.includes(tmpAnswer)) {
                viableAnswer = false;
            }
        } while (!viableAnswer);
        fakeAnswers.push(tmpAnswer);
    }
    shuffleArray(fakeAnswers);

    for (let index = 0; index < answerBtns.length; index++) {
        if (fakeAnswers[index] == rightAnswer && cheat) {
            answerBtns[index].style.background = "Green";
        }

        const element = answerBtns[index];
        element.value = fakeAnswers[index];
    }
}

function shuffleArray(array) {
    let currentIndex = array.length;
    let randomIndex;
    while (currentIndex != 0) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;
        [array[currentIndex], array[randomIndex]] = [
            array[randomIndex], array[currentIndex]
        ];
    }
    return array;
}