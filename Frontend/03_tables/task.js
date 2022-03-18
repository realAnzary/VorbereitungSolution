function invert(str) {
    //console.log(`Input: ${str}`);
    return str.split("").reverse().join("");
}

function read() {
    input = document.getElementById("input-area");
    inputString = input.value;
    input.value = "";

    seperatedStrings = inputString.split(",");
    //console.log(seperatedStrings)

    table = document.getElementById("table-output");
    tblBody = document.createElement("tbody");
    table.appendChild(tblBody);
    table.innerHTML = "";

    header = table.createTHead();
    header.innerHTML = "<tr><td>Substring</td><td>Häufigkeit</td></tr>";
    /*

    tabel.appendChild(tblBody)

    celldata = document.createTextNode("Hello")
    cell = document.createElement("td")
    cell.appendChild(celldata)

    row = document.createElement("tr")
    row.appendChild(cell)
    tblBody.appendChild(row)
    */

    const uniques = new Set(seperatedStrings);
    //console.log(uniques);
    tbody = document.createElement("tbody");

    uniques.forEach(element => {
        currentSubString = element;

        counter = 0;
        seperatedStrings.forEach(object => {
            if (object == element) {
                counter++;
            };
        });
        //console.log(`Element: ${element} occured ${counter} times`);


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
    const table = document.getElementById("table-output");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 0; i < (rows.length - 1); i++) {
            makeSwitch = false;
            x = rows[i].getElementsByTagName("td")[1];
            y = rows[i + 1].getElementsByTagName("td")[1];

            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
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
    input = document.getElementById("input-area");
    //console.log(invert(input.value));
    input.value = invert(input.value);
})

var btnEvaluate = document.getElementById("btn-evaluate");
btnEvaluate.addEventListener("click", () => {
    //console.log("Do smth");
    read()
})