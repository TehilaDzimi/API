
itemCount = 0;
totalAmount = 0;


let products = JSON.parse(sessionStorage.getItem("myBasket"))
const ShowBasket = () => {
    itemCount = 0;
    totalAmount = 0;
    for (let i = 0; i < products.length; i++) {
        itemCount++;
        totalAmount += products[i].price;
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
    products = products.filter(i => i != p);
    sessionStorage.removeItem("myBasket");
    sessionStorage.setItem("myBasket", JSON.stringify(products));
    document.getElementById("myItem").replaceChildren([]);
    ShowBasket();
}
const placeOrder = async () => {


    try {
        var e = JSON.parse(sessionStorage.getItem("user"))
        var OrderId = 2
        var OrderDate = new Date();

        var OrderSum = totalAmount
        var UserId = e.userId
        var OrderItems = products
        var Order = { OrderId, OrderDate, OrderSum, UserId, OrderItems }


        const res = await fetch('api/Orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(Order)

        });

        const dataPost = await res.json();
        alert(dataPost.OrderId + "נוצרה הזמנה  מס")
    }
    catch (er) {
        alert(er)
    }


}
