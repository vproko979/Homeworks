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
        // Role: "User"
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

// function luckyNumbers() {

//     let count = 0;
//     let numbers = [];
    
//     while (count <= 7) {
//         let luckyNumber = Math.ceil(Math.random() * 37)
//         if (numbers.indexOf(luckyNumber) === -1) {
//             numbers.push(luckyNumber);
//             count++;
//         }
//     }
    
//     return numbers.sort((a, b) => a - b);
// }

// // * It turn number into string, before saving into database
// let numbersIntoString = numbers => numbers.sort((a, b) => a - b).join(",");

// // * Turning string of numbers into array of numbers
// let stringIntoNumbers = numbers => numbers.split(",").map(number => Number(number));

// console.log(luckyNumbers());
// console.log(numbersIntoString(luckyNumbers()));
// console.log(stringIntoNumbers(numbersIntoString(luckyNumbers())));