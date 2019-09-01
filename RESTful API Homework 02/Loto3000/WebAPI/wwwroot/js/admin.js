const logOutButton = document.getElementById("log-out");
const drawButton = document.getElementById("draw");
const publishButton = document.getElementById("publish");
const startSessionButton = document.getElementById("start-session");
const checkSessionButton = document.getElementById("check-session");
const winnersButton = document.getElementById("winners");
const regAdminButton = document.getElementById("reg-admin");
const submitButton = document.getElementById("register");
const closeButton = document.getElementById("close");
const prizeButton = document.getElementById("prize");
const addButton = document.getElementById("add");
const close2Button = document.getElementById("close2");
const winnersList = document.getElementById("winners-list");

let port = "50046";

regAdminButton.addEventListener("click", () => {
    document.getElementById("form").style.display = "flex";
    document.getElementById("title").style.display = "none";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    
})

submitButton.addEventListener("click", (e) => {
    e.preventDefault();
    
    let data = {
        Username: document.getElementById("username").value,
        Password: document.getElementById("password").value,
        ConfirmPassword: document.getElementById("confirm-password").value,
        FirstName: document.getElementById("name").value,
        LastName: document.getElementById("surname").value
    }
    registerUser(data);
})

closeButton.addEventListener("click", (e) => {
    e.preventDefault();
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "flex";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    document.getElementById("response").innerText = "";
})

prizeButton.addEventListener("click", () => {
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    document.getElementById("prizes").style.display = "flex";
});

winnersButton.addEventListener("click", () => {
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "none";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "flex";
    getTheWinnersList();
});

addButton.addEventListener("click", (e) => {
    e.preventDefault();
    let data = {
        NumberOfHits: document.getElementById("hits").value,
        Prize: document.getElementById("prize2").value
    };

    addUpdatePrize(data);
});

close2Button.addEventListener("click", () => {
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "flex";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    document.getElementById("response").innerText = "";
});

logOutButton.addEventListener("click", () => {
    location.href = "index.html";
})

checkSessionButton.addEventListener("click", () => {
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "flex";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    checkSession();
});

startSessionButton.addEventListener("click", () => {
    document.getElementById("form").style.display = "none";
    document.getElementById("title").style.display = "flex";
    document.getElementById("prizes").style.display = "none";
    document.getElementById("winners-list").style.display = "none";
    startSession();
});

drawButton.addEventListener("click", () => {
    let numbers = generateLuckyNumbers();

    for (let i = 0; i < numbers.length; i++) {
        document.getElementsByClassName("number")[i].innerHTML = `${numbers[i]}`;
    }

});

(function displayUser(){
    document.getElementById("admin").innerHTML = `<span>Administrator: ${localStorage.getItem("username")}</span>`;
})();

async function addUpdatePrize(data) {
    let token = localStorage.getItem("userToken")
    let response = await fetch(`http://localhost:${port}/api/admins/prize`, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    });
    let result = await response.text();

    document.getElementById("result3").innerText = result;
}

async function registerUser(data) {
    let token = localStorage.getItem("userToken");
    let response = await fetch(`http://localhost:${port}/api/admins/register`, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    });
    let result = await response.text();

    document.getElementById("result2").innerText = result;
}

async function startSession() {
    let token = localStorage.getItem("userToken")
    let response = await fetch(`http://localhost:${port}/api/admins/session`, {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + token
        }
    });
    let result = await response.text();
    document.getElementById("response").innerText = result;
}

async function checkSession() {
    let response = await fetch(`http://localhost:${port}/api/users/active`);
    let result = await response.text();
    document.getElementById("response").innerText = result;
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

function generateLuckyNumbers() {
    debugger
    let count = 0;
    let numbers = [];
    
    while (count <= 7) {
        let luckyNumber = Math.ceil(Math.random() * 37)
        if (numbers.indexOf(luckyNumber) === -1) {
            numbers.push(luckyNumber);
            count++;
        }
    }
    
    return numbers.sort((a, b) => a - b);
}

async function publishLuckyNumbers() {
    let id = await lastSession();
    let numbers = [];

    for (let i = 0; i <= 7; i++) {
        numbers.push(document.getElementsByClassName("number")[i].innerText);
    }

    let data = {
        SessionId: id,
        DrawnNumbers: numbers.join()
    };

    sendLuckyNumbers(data);
}

async function sendLuckyNumbers(data) {
    let token = localStorage.getItem("userToken")
    let response = await fetch(`http://localhost:${port}/api/admins/drawing`, {
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

publishButton.addEventListener("click", () => {
    publishLuckyNumbers()
});

async function getTheWinnersList() {
    debugger
    let response = await fetch(`http://localhost:${port}/api/users/winners`)
    let result = await response.text();
    displayWinners(result);
}

function createCloseButton() {
    let button = document.createElement("button");
    button.innerText = "Close"
    button.setAttribute("id", "close3");
    winnersList.appendChild(button);
    document.getElementById("close3").addEventListener("click", () => {
        winnersList.style.display = "none";
        document.getElementById("form").style.display = "none";
        document.getElementById("title").style.display = "flex";
        document.getElementById("prizes").style.display = "none";
        document.getElementById("winners-list").style.display = "none";
        document.getElementById("response").innerText = "";
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
    
    console.log(data);
    if (data.includes("No winners")) {
        cleanWinners();
        winnersTittle("No winners in the last session");
        createCloseButton();
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
    createCloseButton();

}