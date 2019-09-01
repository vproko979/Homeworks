const registerButton = document.getElementById("register");
const returnButton = document.getElementById("return");
const logInButton = document.getElementById("log-in");

let port = "50046";

registerButton.addEventListener("click", () => {
    location.href = "registration.html";
});

returnButton.addEventListener("click", () => {
    location.href = "index.html";
});

logInButton.addEventListener("click", (e) => {
    e.preventDefault();

    document.getElementById("response").innerText = "";

    let data = {
        Username: document.getElementById("username").value,
        Password: document.getElementById("password").value
    }
    logIn(data);
})

async function logIn(data) {

    let response = await fetch(`http://localhost:${port}/api/users/authenticate`, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    let result = await response.text();

    if (result === "Incorrect username or password") {
        document.getElementById("response").innerText = result;
    }else {
        let obj = JSON.parse(result);
        checkUserRole(obj);
    }
}

function checkUserRole(data) {
    localStorage.setItem("userId", data.id);
    localStorage.setItem("userToken", data.token);
    localStorage.setItem("username", data.username);
    if (data.role === "Admin") {
        location.href = "admin.html";
    } else {
        location.href = "user.html";
    }
}