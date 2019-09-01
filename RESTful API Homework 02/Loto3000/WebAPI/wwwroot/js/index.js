const registerButton = document.getElementById("register")
const signInButton = document.getElementById("sign-in")

registerButton.addEventListener("click", () => {
    location.href = "registration.html";
});

signInButton.addEventListener("click", () => {
    location.href = "login.html";
})