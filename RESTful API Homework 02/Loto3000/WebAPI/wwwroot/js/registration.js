const regButton = document.getElementById("register");
const returnButton = document.getElementById("return");
const signInButton = document.getElementById("sign-in");

let port = "50046";

returnButton.addEventListener("click", () => {
    location.href = "index.html";
})

signInButton.addEventListener("click", () => {
    location.href = "login.html";
})

regButton.addEventListener("click", (e) => {

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

async function registerUser(data) {

    let response = await fetch(`http://localhost:${port}/api/users/register`, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    let result = await response.text();

    document.getElementById("result").innerText = result;
}