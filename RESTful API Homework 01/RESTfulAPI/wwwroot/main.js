const buttonList = document.getElementsByTagName("li")[0];
const buttonShowUserInfo = document.getElementsByTagName("li")[1];
const buttonCheckUser = document.getElementsByTagName("li")[2];
const buttonAddUser = document.getElementsByTagName("li")[3];
const wrapper = document.getElementById("wrapper").children;
const name = document.getElementById("name");
const surname = document.getElementById("surname");
const age = document.getElementById("age");
const sendBtn = document.getElementById("send");
const showButton = document.getElementById("show");
const showButton2 = document.getElementById("show2");
const number = document.getElementById("number");
const number2 = document.getElementById("number2");

let port = 50302;
let url = "http://localhost:" + port + "/api/values";

function displayResult(data) {
    document.getElementsByClassName("result")[0].style.display = "block";
    let result = "";
    for (let index = 0; index < data.length; index++) {
        result += `<span>${data[index].firstName} ${data[index].lastName} ${data[index].age}</span><br>`;
    }

    document.getElementsByClassName("result")[0].innerHTML = result
}

function displayResult2(data) {
    document.getElementsByClassName("result")[0].style.display = "block";
    let result = `<span>${data.firstName} ${data.lastName} ${data.age}</span><br>`;

    document.getElementsByClassName("result")[0].innerHTML = result
}

function displayResult3(data) {
    document.getElementsByClassName("result")[0].style.display = "block";
    let result = `<span>${data}</span><br>`;

    document.getElementsByClassName("result")[0].innerHTML = result
}

function displayResult4(data) {
    document.getElementsByClassName("result")[0].style.display = "block";
    let result = "";
    if (data == 200) {
        result = `<br><span>The user has been successfully added.</span><br>`;
    } else {
        result = `<br><span>Something went wrong, the user wasn't added to the list.</span><br>`;
    }

    document.getElementsByClassName("result")[0].innerHTML = result
}

let getAllUsers = async (div) => {
    let response = await fetch(url);
    let result = await response.json();
    displayResult(result);
}

let isItAdult = async (div) => {
    let url = "http://localhost:" + port + "/api/values/adults/" + number2.value;
    let response = await fetch(url);
    let result = await response.text();
    displayResult3(result);
}

let getUser = async (div) => {
    let url = "http://localhost:" + port + "/api/values/" + number.value;
    let response = await fetch(url);
    let result = await response.json();
    displayResult2(result);
}

let createUser = async () => {
    let data = {
        FirstName: name.value,
        LastName: surname.value,
        Age: Number(age.value)
    };

    let response = await fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    let result = await response.status;
    displayResult4(result);
}

function removeActiveClass() {
    for (let index = 0; index < wrapper.length; index++) {
        wrapper[index].classList.remove("active");
    }
}

function hideChildren() {
    for (let index = 0; index < wrapper.length; index++) {
        if (!wrapper[index].classList.contains("active")) {
            wrapper[index].style.display = "none";
        }
    }
}

function displaySelected(selection) {
    removeActiveClass();
    displayDiv(selection);
    hideChildren();
    document.getElementsByClassName("result")[0].style.display = "none";
}

function displayDiv(id) {
    document.getElementById(id).classList.add("active");
    document.getElementById("wrapper").style.display = "block";
    document.getElementById(id).style.display = "flex";
}

//Displays the list with users
buttonList.addEventListener("click", () => {
    displaySelected("list")
    getAllUsers("list");
});

//Show user by id
buttonShowUserInfo.addEventListener("click", () => {
    displaySelected("user");
});

showButton.addEventListener("click", () => {
    getUser("user");
});

//Check user by ID if it's over 18
buttonCheckUser.addEventListener("click", () => {
    displaySelected("check");
});

showButton2.addEventListener("click", () => {
    isItAdult("check");
});

//Adds new user
buttonAddUser.addEventListener("click", () => {
    displaySelected("form");
});

sendBtn.addEventListener("click", (e) => {
    e.preventDefault();
    createUser();
});