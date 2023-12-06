


var IdCount = 100;

const register = async () => {
    try {
        var email = document.getElementById("email").value
        var password = document.getElementById("password").value
        var firstName = document.getElementById("firstName").value
        var lastName = document.getElementById("lastName").value
        var User = { email, password, firstName, lastName }


        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });

        const dataPost = await res.json();
        if (dataPost.email != null) {
            alert(`${dataPost.firstName}  ${dataPost.lastName} added`)
        }
        else {
            alert("eror!!")
        }
        
    }
    catch (er) {
        alert(er)
    }


}


//const checkLength = () => {
//    var email = document.getElementById("email").value
//    if (email.length > 30) {
//        alert("to long")
//    }
//} 

var users;



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
        /* alert("your password is weak!! try again")*/
        meter.value = res;

    // Update the password strength meter
    meter.value = res;

    // Update the text indicator
 
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}




const login = async () => {
    let user = {
        email: document.getElementById("email2").value,
        password: document.getElementById("password2").value
    }
    try {

        var url = 'api/Users/login';

        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
        }
        else {
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))
            alert("you loged in")
            window.location.href = "./Hello.html"

        }
    }

    catch (er) {
        alert("The email or the password was not proper")
    }

    
 
    }


const logOut = () => {
    window.location.href = "./Register.html"
}

const login2 = () => {
    window.location.href = "./home.html"
}
