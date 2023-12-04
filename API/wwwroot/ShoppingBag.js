
itemCount = 0;
totalAmount = 0;
count = sessionStorage.getItem("count");
let user = JSON.parse(sessionStorage.getItem("user"))
let products = JSON.parse(sessionStorage.getItem("myBasket"))




const ShowBasket = () => {
    itemCount = 0;
    totalAmount = 0;
    for (let i = 0; i < products.length; i++) {
        itemCount++;
        totalAmount += products[i].price;
        tempProduct = document.getElementById("temp-row");
        clon = tempProduct.content.cloneNode(true);
        clon.querySelector("img").src = "./image/" + products[i].image;
        clon.querySelector(".price").innerText = products[i].price + "$";
        clon.querySelector(".descriptionColumn").innerText = products[i].description;
        clon.querySelector(".totalColumn").addEventListener('click', () => { deleteFromBasket(products[i]) });
        document.getElementById("myItem").appendChild(clon);
    }
    document.getElementById("itemCount").innerText = itemCount;
    document.getElementById("totalAmount").innerText = totalAmount + "$";
    
}


const deleteFromBasket = (p) => {
    count--;
    sessionStorage.setItem("count", count);
    products = products.filter(i => i != p);
    sessionStorage.removeItem("myBasket"); 
    sessionStorage.setItem("myBasket", JSON.stringify(products));
    document.getElementById("myItem").replaceChildren([]);
    ShowBasket();
}





const placeOrder = async () => {
    var user = JSON.parse(sessionStorage.getItem("user"))
    let orderItem = []
    for (let i = 0; i < products.length; i++) 
        orderItem.push({ "productsId": products[i].productId, "ouantity": 1 })
    if (user) {//1



        var Order = {
            OrderDate : new Date(),
            OrderSum : totalAmount,
            UserId : user.userId,
            OrderItems : orderItem
        }

        try {//2
            const res = await fetch('api/Orders', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(Order)

            });

            const dataPost = await res.json();
            alert(`order number : ${dataPost.orderId} has created succsesful`);
        

        }//2
    catch (er) {
        alert(er)
    }

}//1

else {
    window.location.href="./home.html"
}



}
