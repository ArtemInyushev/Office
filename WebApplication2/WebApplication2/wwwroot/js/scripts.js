function filterNames() {
    const input = document.getElementById("nameFilter");
    const filter = input.value.toLowerCase();
    const table = document.getElementById("table");
    const rows = table.rows;
    for (let i = 1; i < rows.length; i++) {
        const td = rows[i].getElementsByTagName("td")[0];
        const name = td.innerText;
        if (name.toLowerCase().indexOf(filter) > -1) {
            rows[i].style.display = "";
        } else {
            rows[i].style.display = "none";
        }
    }
}

function sortNames() {
    const table = document.getElementById("table");
    const sortMode = document.getElementById("sorting").value;
    const rows = table.rows;
    const length = rows.length;
    for (let i = 1; i < length; i++) {
        for (let j = 1; j < length - i; j++) {
            const value1 = rows[j].getElementsByTagName("td")[0];
            const value2 = rows[j + 1].getElementsByTagName("td")[0];
            if (sortMode === "Asc") {
                if (value1.innerText > value2.innerText) {
                    rows[j].parentNode.insertBefore(rows[j + 1], rows[j]);
                }
            }
            else if (sortMode === "Desc") {
                if (value1.innerText < value2.innerText) {
                    rows[j].parentNode.insertBefore(rows[j + 1], rows[j]);
                }
            }
        }
    }
}