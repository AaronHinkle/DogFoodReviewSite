

//html link for general treat count and dog bone picture
const clickCount = document.getElementById("treatcount");
const myImg = document.getElementById("dogbone");

//html link for the dog bone picture 
myImg.addEventListener("click", addClick)

//function to add a click per click on dog bone
function addClick() {
    treats += clickValue;

    clickCount.innerHTML = "Treats:" + (treats).toFixed(2);
}


/////////////////////AUTOBUY/////////////////////////////
////////////////////////////////////////////////////////////////////


//variables for autobuy
let price = 10;
let autoClickCount = 0;
let treats = 0;

//// multiplier HTML links
const autoClickText = document.getElementById("clicks-per")
const autoClickPrice = document.getElementById("auto-click-price")
const autoClickBuy = document.getElementById("auto-click-purchase")

//event listener for autoclick button
autoClickBuy.addEventListener("click", autoClickBuyFunction)

//function for buy auto clicks
function autoClickBuyFunction() {

    if (treats >= price) {
        treats -= price;
        price = (price * 1.1).toFixed(2);
        setInterval(addClick, 1000)
        autoClickCount++;
        autoClickPrice.textContent = ("AutoClicker price: " + price);
        autoClickText.textContent = ("You have:" + autoClickCount + " treats/second")
    }

    else {
        alert("You do not have enough to buy a autoClick. Get more treats. ")
    }
}


/////////////////////MULTIPLIER SECTION/////////////////////////////
////////////////////////////////////////////////////////////////////


// Multiplier variables 
let multiplierPrice = 10;
let multiplierCount = 0;
let clickValue = 1;

// multiplier HTML links

const multiplierBuy = document.getElementById("multiply-click-purchase")
const purchaseMultiplierText = document.getElementById("treatsPerClick");
const purchaseMultiplierPrice = document.getElementById("multiplier-price");
const multipliersPerClick = document.getElementById("multiplierPerClick");

// event listener for multiplierButton

multiplierBuy.addEventListener("click", multiplierBuyFunction);

//function for buying a multiplier 

function multiplierBuyFunction() {
    if (treats >= multiplierPrice) {
        treats -= multiplierPrice;
        clickValue = clickValue * 1.2;
        multiplierCount++;
        multiplierPrice = (multiplierPrice * 1.1).toFixed(2);
        purchaseMultiplierPrice.textContent = ("Multiplier price " + multiplierPrice);
        purchaseMultiplierText.textContent = ("You have " + multiplierCount + " multipliers")
        multiplierPerClick.textContent = ("You have " + clickValue.toFixed(2) + " treats per click")
    }

    else {
        alert("You do not have enough to buy a multiplier! Get more treats. ")
    }
}

//////////////// GAME RESET ////////////////////////////////////

const resetGame = document.getElementById("reset");

//event listener
resetGame.addEventListener("click", ResetDatMess)

function ResetDatMess() {
    location.reload()
}