

const getAllProducts = async (desc, minPrice, maxPrice, categoryIds) => {
    try {
        let url = `api/products`;
        if (desc || minPrice || maxPrice || categoryIds)
            url += `?`;

        if (desc) url += `desc=${desc}`;

        if (minPrice) url += `&minPrice=${minPrice}`;

        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (categoryIds) {
            for (let i = 0; i < categoryIds.length; i++) {
                url += `&categoryIds=${categoryIds[i]}`;
                console.log(categoryIds[i] + '  ttt')
            }
        }
        console.log(url + '  aaa');
        const res = await fetch(url);
        const products = await res.json();
        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}

count = 0;
const FilterProducts = async () => {
    const categoriesArr = [];
    const a = document.querySelectorAll(".opt");
    for (let i = 0; i < a.length; i++) {
        if (a[i].checked)
            categoriesArr.push(a[i].value)
    }

    const getdesk = document.getElementById("nameSearch").value

    const getminPrice = document.getElementById("minPrice").value
    const getmaxPrice = document.getElementById("maxPrice").value
    const products = await getAllProducts(getdesk, getminPrice, getmaxPrice, categoriesArr);
    document.getElementById("PoductList").replaceChildren([]);
    for (let i = 0; i < products.length; i++) {
        var templateProd = document.getElementById("temp-card");
        var cln = templateProd.content.cloneNode(true);
        cln.querySelector("img").src = "./Images/" + products[i].image;
        cln.querySelector("h1").innerText = products[i].name;
        cln.querySelector("p.price").innerText = products[i].price + ' $';
        cln.querySelector("p.description").innerText = products[i].description;
        cln.querySelector("button") .addEventListener('click', () => {addToBasket(products[i]) })
        document.getElementById("PoductList").appendChild(cln);
    }
    document.getElementById("counter").innerText = products.length+1;
}


const getAllCategories = async () => {
    url = 'api/Categories'
    try {
        const res = await fetch(url);
        const products = await res.json();

        return products;
    }
    catch (ex) {
        console.log(ex);
    }
}

const ShowCategories = async () => {

    const categories = await getAllCategories();

    for (let i = 0; i < categories.length; i++) {

        var templateCate = document.getElementById("temp-category");
        var cln = templateCate.content.cloneNode(true);

        cln.querySelector("span.OptionName").innerText = categories[i].name;
        cln.querySelector(".opt").value = categories[i].categoryId;

        document.getElementById("categoryList").appendChild(cln);
    }
}
ShowCategories();

const basketArr = [];

const addToBasket = (products) => {
    basketArr.push(products);
    console.log(basketArr + " a")
    sessionStorage.setItem("myBasket", JSON.stringify(basketArr));
}
