function invert(str) {
    // Reverses a string
    return str.split("").reverse().join("");
}

function read() {
    // Reads the input area and creates the output
    // Gets all substrings and counts them, outputs the string and amount in a table
    input = document.getElementById("input-area");
    inputString = input.value;
    input.value = "";

    seperatedStrings = inputString.split(",");

    table = document.getElementById("table-output");
    tblBody = document.createElement("tbody");
    table.appendChild(tblBody);
    table.innerHTML = "";

    header = table.createTHead();
    header.innerHTML = "<tr><td>Substring</td><td>Häufigkeit</td></tr>";

    const uniques = new Set(seperatedStrings);
    tbody = document.createElement("tbody");

    uniques.forEach(element => {
        currentSubString = element;
        currentSubString = currentSubString.replace(" ", "");

        console.log(currentSubString);
        counter = 0;
        seperatedStrings.forEach(object => {
            object = object.replace(" ", "");
            if (object == currentSubString) {
                counter++;
            };
        });

        row = document.createElement("tr");
        tableObject = document.createElement("td");
        tableCounter = document.createElement("td");
        dataObject = document.createTextNode(element);
        dataCounter = document.createTextNode(counter);

        tableObject.appendChild(dataObject);
        tableCounter.appendChild(dataCounter);

        row.appendChild(tableObject);
        row.appendChild(tableCounter);

        tbody.appendChild(row);
    });

    table.appendChild(tbody);
    shouldSort = document.getElementById("checkbox-sort");
    if (shouldSort.checked) {
        sort()
    }
}

function sort() {
    // function to sort the output table
    const table = document.getElementById("table-output");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 0; i < (rows.length - 1); i++) {
            makeSwitch = false;
            x = rows[i].getElementsByTagName("td")[1];
            y = rows[i + 1].getElementsByTagName("td")[1];

            if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                makeSwitch = true;
                break;
            }
        }
        if (makeSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }

}

var btnInvert = document.getElementById("btn-invert");
btnInvert.addEventListener("click", () => {
    // inverts the text area
    input = document.getElementById("input-area");
    input.value = invert(input.value);
})

var btnEvaluate = document.getElementById("btn-evaluate");
btnEvaluate.addEventListener("click", () => {
    read()
})