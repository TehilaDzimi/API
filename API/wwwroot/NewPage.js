
const user = sessionStorage.getItem("user")
const jsonUser = JSON.parse(user)


const loadPage = () => {
    const jsonUser = JSON.parse(user)
    welcome.innerHTML = `hello to ${jsonUser.firstName}  welcome to home page:)!!!`
    

}

const UpdateloadPage = () => {
    
    const email3 = document.getElementById("email3")
    email3.value = jsonUser.email

    const password3 = document.getElementById("password3")
    password3.value = jsonUser.password

    const firstName3 = document.getElementById("firstName3")
    firstName3.value = jsonUser.firstName

    const lastName3 = document.getElementById("lastName3")
    lastName3.value = jsonUser.lastName

}


const update = async () => {
    
    try {
        var userId = jsonUser.userId
        var email = document.getElementById("email3").value
        var password = document.getElementById("password3").value
        var firstName = document.getElementById("firstName3").value
        var lastName = document.getElementById("lastName3").value
        var User = { userId, email, password, firstName, lastName }
        console.log(User)
        var url = 'api/users' + "/" + userId
        const res = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)
        });
        if (res.ok) {
            const dataPost = await res.json();
            alert("The user updated succesefuly")
            console.log(dataPost)
        }
        else {
            throw new Error('Request failed with status ' + res.status);
        }
    }
    
    catch (er) {
        alert("cant save the changes")
    }
}

const checkPassword = async () => {
    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("password").value;
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    await fetch('api/Users/check',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        })
        .then(r => r.json())
        .then(data => res = data)

    if (res <= 2)
        meter.value = res;
        meter.value = res;
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}


const loadToPage = () => {
    window.location.href = "./Products.html"
}
const toUpdate = () => {
    window.location.href = "./newPage.html"
}