//Todos os lanches do cardapio
const sandwish = [
    {
        name: "Claudinho Simples",
        image: "./assets/img/claudinho_simples.jpg",
        desc: `50% de desconto`,
        cod: `EXB029`
    },

    {
        name: "Egg Claudinho",
        image: "./assets/img/egg_claudinho.jpg",
        desc: "40% de desconto",
        cod: `VGB777`
    },

    {
        name: "Claudinho Vegano",
        image: "./assets/img/claudinho_vegano.jpg",
        desc: "30% de desconto",
        cod: `ALK544`
    },

    {
        name: "Big Claudinho Bacon",
        image: "./assets/img/claudinho_salada.jpg",
        desc: "20% de desconto",
        cod: `KLY882`
    }
]
//Array de containers
const container = [];
const title = [];
const burgerImg = [];
const description = [];
const cod = [];

const cardapio = document.querySelector("#menu-items"); //grid

//cria item do menu
const createElements = () => {
    //Titulo, imagem e descrição
    for(let i = 0; i < sandwish.length; i++)
    {
        container.push(document.createElement("article"));
        title.push(document.createElement("h3"));
        burgerImg.push(document.createElement("img"));
        description.push(document.createElement("p"));
        cod.push(document.createElement("span"));
    }
    

    
}
//Coloca os valores
const addValues = () => {
    for(let i = 0; i < sandwish.length; i++)
    {
        container[i].classList.add("lanche-container","lanche-grid", "main-content");
        title[i].textContent = `${sandwish[i].name}`;
        burgerImg[i].src = `${sandwish[i].image}`;
        description[i].classList.add("flex");
        description[i].innerHTML = `${sandwish[i].desc}`;
        cod[i].innerHTML = `${sandwish[i].cod}`;
        description[i].appendChild(cod[i]);
    }
}

const createContainer = () => {
    for(let i = 0; i < sandwish.length; i++)
    {
        container[i].appendChild(title[i]);
        container[i].appendChild(burgerImg[i]);
        container[i].appendChild(description[i]);
        console.log(container[i]);
    }
}

const addContainer = () => {
    for(let i=0; i < sandwish.length; i++)
        cardapio.appendChild(container[i]);
}

createElements();
addValues();
createContainer();
addContainer();