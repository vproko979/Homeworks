const logOutButton = document.getElementById("log-out");
const sendButton = document.getElementById("send");
const winnersButton = document.getElementById("winners");
const winnersList = document.getElementById("winners-list");

let port = "50046";

winnersButton.addEventListener("click", () => {
    console.log("Winners btn was clicked");
    document.getElementById("main").style.display = "none";
    getTheWinnersList();
});

logOutButton.addEventListener("click", () => {
    location.href = "index.html";
})

sendButton.addEventListener("click", () => {

    createTicket();
});

(function displayUser(){
    document.getElementById("user").innerHTML = `<span>User: ${localStorage.getItem("username")}</span>`;
})();

async function createTicket(){
    let luckyNumbers = [];
    let sessionId = await lastSession();

    for (let index = 1; index <= 7; index++) {
        luckyNumbers.push(document.getElementById("number" + index).value);
    }

    let data = {
        SessionId: sessionId,
        UserId: localStorage.getItem("userId"),
        Numbers: luckyNumbers.sort((a,b) => a - b).toString()
    };

    sendTicket(data);
}

async function lastSession() {
    let token = localStorage.getItem("userToken")
    let response = await fetch(`http://localhost:${port}/api/users/last`,{
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    });
    let result = await response.text();
    let object = JSON.parse(result)
    return object.id;
}

(async function checkSession() {
    let response = await fetch(`http://localhost:${port}/api/users/active`);
    let result = await response.status;

    if (result === 400) {
        document.getElementById("status").innerText = "Sorry you can't fill out ticket at the moment.";
        document.getElementById("send").disabled = true;
        document.getElementById("send").style.backgroundColor = "gray";
    } else {
        document.getElementById("status").innerText = "We accept tickets. Good Luck!";
    }

})();

async function sendTicket(data) {
    let token = localStorage.getItem("userToken")
    let response = await fetch(`http://localhost:${port}/api/users/ticket`, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token,
        }
    });
    let result = await response.text();

    document.getElementById("result").innerText = result;
}

async function getTheWinnersList() {
    debugger
    let response = await fetch(`http://localhost:${port}/api/users/winners`)
    let result = await response.text();
    displayWinners(result);
}

function createCloseButton(parent){
    let button = document.createElement("button");
        button.innerText = "Close"
        button.setAttribute("id", "close");
        winnersList.appendChild(button);
        document.getElementById("close").style.marginTop = "39px";
        document.getElementById("close").addEventListener("click", () => {
            winnersList.style.display = "none";
            document.getElementById(parent).style.display = "flex";
        });
}

function cleanWinners(){
    winnersList.innerHTML = "";
    winnersList.style.display = "flex";
}

function winnersTittle(message){
    let title = document.createElement("h1");
        title.innerText = message;
        winnersList.appendChild(title);
}

function displayWinners(data) {
    
    if (data.includes("No winners")) {
        cleanWinners();
        winnersTittle(data);
        createCloseButton("main");
        return;
    }
    let list = JSON.parse(data);
    cleanWinners();
    winnersTittle("WINNERS!");
    let br = document.createElement("br");
    winnersList.appendChild(br);
    let table = document.createElement("table");
    table.setAttribute("border", "2");
    table.setAttribute("rules", "all");
    let thead = document.createElement("thead");
    let tableHeadTitles = `<thead>
                                <th>Full name</th>
                                <th>Winning numbers</th>
                                <th>Prize</th>
                            </thead>`;
    thead.innerHTML = tableHeadTitles;
    table.appendChild(thead);
    let tbody = document.createElement("tbody");
    let text = "";
    for (let index = 0; index < list.length; index++) {
        text += `<tr>
                    <td>${list[index].firstName} ${list[index].lastName}</td>
                    <td>${list[index].winningNumbers}</td>
                    <td>${list[index].prize}</td>
                </tr>`;

    }
    tbody.innerHTML = text;
    table.appendChild(tbody);
    winnersList.appendChild(table);
    createCloseButton("main");

}