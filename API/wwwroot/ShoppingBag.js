
itemCount = 0;
totalAmount = 0;
let products = JSON.parse(sessionStorage.getItem("myBasket"))
const ShowBasket =  () => {
    for (let i = 0; i < products.length; i++) {
        itemCount++;
        totalAmount +=products[i].price;
        tempProduct = document.getElementById("temp-row");
        clon = tempProduct.content.cloneNode(true);
        clon.querySelector("img").src = "./Images/" + products[i].image;
        clon.querySelector(".price").innerText = products[i].price + "$";
        clon.querySelector(".descriptionColumn").innerText = products[i].description;
        clon.querySelector(".totalColumn").addEventListener('click', () => { deleteFromBasket(products[i]) });
        document.getElementById("myItem").appendChild(clon);
    }
    document.getElementById("itemCount").innerText = itemCount;
    document.getElementById("totalAmount").innerText = totalAmount + "$";
}


const deleteFromBasket = (p) => {
    products=products.filter(i => i != p);
    sessionStorage.removeItem("myBasket");
    sessionStorage.setItem("myBasket", JSON.stringify(products));
    document.getElementById("myItem").replaceChildren([]);
    ShowBasket();
}

const createOrder = async () => {
    try {
        var e=JSON.parse(sessionStorage.getItem("user"))
        var orderDate ="21/11/23";
        var orderSum = totalAmount;
        var userId = e.userId;
        var orderItems = products
        var Order = { orderDate, orderSum, userId, orderItems }
        const res = await fetch('api/Orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(Order)

        });
        const dataPost = await res.json();
        alert("הזמנה מס' " + dataPost.OrderId+"בוצעה בהצלחה")
    }
    catch (er) {
        alert(er)
    }
}
