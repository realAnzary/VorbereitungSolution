var addAnimalBtn = document.getElementById("add-animal-btn");
addAnimalBtn.addEventListener("click", () => {
    let fence1 = document.getElementById("fence-1");
    let fence2 = document.getElementById("fence-2");
    let nameInput = document.getElementById("add-animal");
    let alreadyInFence1 = false;
    let alreadyInFence2 = false;

    for (let i = 0; i < fence1.children.length; i++) {
        let element = fence1.children[i];
        if (nameInput.value == element.innerText) {
            alreadyInFence1 = true;
            console.log("In Fence 1");
        }
    }

    for (let i = 0; i < fence2.children.length; i++) {
        let element = fence2.children[i];
        if (nameInput.value == element.innerText) {
            alreadyInFence2 = true;
            console.log("In Fence 2");
        }
    }

    if (!alreadyInFence1 && !alreadyInFence2) {

        newAnimal = document.createElement("div");
        newAnimal.classList.add("animal");
        newSpan = document.createElement("span");
        newSpan.innerHTML = nameInput.value;
        newAnimal.appendChild(newSpan);
        newAnimal.addEventListener("click", clickFunction);
        newAnimal.setAttribute('draggable', true);
        newAnimal.addEventListener('dragstart', dragstart);

        fence1.appendChild(newAnimal);
        SortFence();
    }
})

function clickFunction() {
    if (this.classList.contains("selected")) {
        this.classList.remove("selected");
    } else {
        this.classList.add("selected");
    }
}

var moveAnimalBtn = document.getElementById("move-animals-btn");
moveAnimalBtn.addEventListener("click", () => {
    let fence1 = document.getElementById("fence-1");
    let fence2 = document.getElementById("fence-2");

    if (fence1.childElementCount > 0) {
        for (let i = fence1.childElementCount - 1; i > -1; i--) {
            let element = fence1.children[i];
            if (element.classList.contains("selected")) {
                fence2.appendChild(element);
                element.classList.remove("selected");
            }
        }
    }

    if (fence2.childElementCount > 0) {
        for (let i = fence2.childElementCount - 1; i > -1; i--) {
            let element = fence2.children[i];
            if (element.classList.contains("selected")) {
                fence1.appendChild(element);
                element.classList.remove("selected");
            }
        }
    }
    SortFence();
})

function SortFence() {
    let fence1 = document.getElementById("fence-1");
    let fence2 = document.getElementById("fence-2");

    let list = [];

    for (let i = 0; i < fence1.childElementCount; i++) {
        const element = fence1.children[i];
        list.push(element.innerText);
        element.innerText = "";
    }

    list = list.sort();

    for (let i = 0; i < fence1.children.length; i++) {
        const element = fence1.children[i];
        element.innerText = list[i];
    }

    list = [];

    for (let i = 0; i < fence2.childElementCount; i++) {
        const element = fence2.children[i];
        list.push(element.innerText);
        element.innerText = "";
    }

    list = list.sort();

    for (let i = 0; i < fence2.children.length; i++) {
        const element = fence2.children[i];
        element.innerText = list[i];
    }
}

var fences = document.querySelectorAll('.fence');
fences.forEach(fence => {
    fence.addEventListener('dragenter', dragEnter)
    fence.addEventListener('dragover', dragOver);
    fence.addEventListener('dragleave', dragLeave);
    fence.addEventListener('drop', drop);
})

function dragstart(e) {
    e.target.classList.add('dragging');
}


function dragEnter(e) {
    e.preventDefault();
}

function dragOver(e) {
    e.preventDefault();
}


function dragLeave(e) {}

function drop(e) {
    const draggable = document.getElementsByClassName("dragging");
    e.target.appendChild(draggable[0]);
    draggable[0].classList.remove("dragging");
}