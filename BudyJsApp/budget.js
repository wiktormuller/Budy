/* www.youtube.com/CodeExplained */

// SELECT ELEMENTS
const balanceEl = document.querySelector(".balance .value");
const incomeTotalEl = document.querySelector(".income-total");
const outcomeTotalEl = document.querySelector(".outcome-total");
const incomeEl = document.querySelector("#income");
const expenseEl = document.querySelector("#expense");
const allEl = document.querySelector("#all");
const incomeList = document.querySelector("#income .list");
const expenseList = document.querySelector("#expense .list");
const allList = document.querySelector("#all .list");

// SELECT BTNS
const expenseBtn = document.querySelector(".tab1");
const incomeBtn = document.querySelector(".tab2");
const allBtn = document.querySelector(".tab3");
const toggleBtn = document.querySelector(".toggleBtn");

// INPUT BTS
const addExpense = document.querySelector(".add-expense");
const expenseTitle = document.getElementById("expense-title-input");
const expenseAmount = document.getElementById("expense-amount-input");
const expenseCategoryId = document.getElementById("expense-categoryid-input");
const expenseOccuredAt = document.getElementById("expense-occuredat-input");

const addIncome = document.querySelector(".add-income");
const incomeTitle = document.getElementById("income-title-input");
const incomeAmount = document.getElementById("income-amount-input");
const incomeCategoryId = document.getElementById("income-categoryid-input");
const incomeOccuredAt = document.getElementById("income-occuredat-input");

// VARIABLES
let balance = 0, income = 0, outcome = 0;
const DELETE = "delete", EDIT = "edit";

updateUI();

// EVENT LISTENERS
expenseBtn.addEventListener("click", function(){
    show(expenseEl);
    hide( [incomeEl, allEl] );
    active( expenseBtn );
    inactive( [incomeBtn, allBtn] );
})
incomeBtn.addEventListener("click", function(){
    show(incomeEl);
    hide( [expenseEl, allEl] );
    active( incomeBtn );
    inactive( [expenseBtn, allBtn] );
})
allBtn.addEventListener("click", function(){
    show(allEl);
    hide( [incomeEl, expenseEl] );
    active( allBtn );
    inactive( [incomeBtn, expenseBtn] );
})
toggleBtn.addEventListener("click", function(){
    var color = window.getComputedStyle(document.body,"").getPropertyValue("background-color");
    if(color == "rgb(34, 34, 34)")
    {
        document.body.style.backgroundColor = "#34006a";
    }
    else
    {
        document.body.style.backgroundColor = "#222";
    }
})

addExpense.addEventListener("click", function(){
    // IF ONE OF THE INPUTS IS EMPTY => EXIT
    if(!expenseTitle.value || !expenseAmount.value || expenseCategoryId.value || expenseOccuredAt.value) return;

    // SAVE THE ENTRY TO ENTRY_LIST
    let expense = {
        type : "expense",
        title : expenseTitle.value,
        amount : parseInt(expenseAmount.value),
        categoryId : parseInt(expenseCategoryId.value),
        occuredAt : expenseOccuredAt.value
    }

    updateUI();
    clearInput( [expenseTitle, expenseAmount] )
})

addIncome.addEventListener("click", function(){
    // IF ONE OF THE INPUTS IS EMPTY => EXIT
    if(!incomeTitle.value || !incomeAmount.value || incomeCategoryId.value || incomeOccuredAt.value) return;

    // SAVE THE ENTRY TO ENTRY_LIST
    let income = {
        name : incomeTitle.value,
        amount : parseInt(incomeAmount.value),
        categoryId : parseInt(incomeCategoryId.value),
        occuredAt : incomeOccuredAt.value
    }

    updateUI();
    clearInput( [incomeTitle, incomeAmount] )
})

incomeList.addEventListener("click", deleteOrEdit);
expenseList.addEventListener("click", deleteOrEdit);
allList.addEventListener("click", deleteOrEdit);

// HELPERS
function deleteOrEdit(event){
    const targetBtn = event.target;

    const entry = targetBtn.parentNode;

    if( targetBtn.id == "delete"){
        deleteEntry(entry);
    }else if(targetBtn.id == "edit" ){
        editEntry(entry);
    }
}

function deleteEntry(entry){
    console.log(entry.id);
    if(entry.classList[0] == "income")
    {
        fetch('https://localhost:5001/api/Incomes' + '/' + entry.id, {
            method: 'delete'
        })
        .then();
    }

    if(entry.classList[0] == "expense")
    {
        fetch('https://localhost:5001/api/Expenses' + '/' + entry.id, {
            method: 'delete'
        })
        .then();
    }

    updateUI();
}

function editEntry(entry){
    if(entry.classList[0] == "income"){
        fetch("https://localhost:5001/api/Incomes",{
            method: 'PUT',
            headers:{
            'Content-Type':'application/json'
            },
            body: JSON.stringify({name:entry.name, amount:entry.amount, occuredAt:entry.occuredAt, categoryId:entry.categoryId})
        })
    }
    else if(entry.classList[0] == "expense"){
        fetch("https://localhost:5001/api/Expenses",{
            method: 'PUT',
            headers:{
            'Content-Type':'application/json'
            },
            body: JSON.stringify({name:entry.name, amount:entry.amount, occuredAt:entry.occuredAt, categoryId:entry.categoryId})
        })
    }

    updateUI();
}

function updateUI(){
    
    // UPDATE UI
    fetch('https://localhost:5001/api/Balances/actual')
    .then(response => response.json())
    .then(data =>
    {
        let balance = 0;
        balance = data.balanceAmount;
        balanceEl.innerHTML = `${balance} <small>PLN</small>`;
    })

    fetch('https://localhost:5001/api/Expenses')
    .then(response => response.json())
    .then(data =>
    {
        var outcome = 0;
        outcome = data.map(expense => expense.amount).reduce((acc, expense) => acc + expense, 0);
        outcomeTotalEl.innerHTML = `${outcome} <small>PLN</small>`;
    })
    
    fetch('https://localhost:5001/api/Incomes')
    .then(response => response.json())
    .then(data =>
    {
        var income = 0;
        income = data.map(inc => inc.amount).reduce((acc, inc) => acc + inc, 0);
        incomeTotalEl.innerHTML = `${income} <small>PLN</small>`;
    })

    clearElement( [expenseList, incomeList, allList] );

    fetch('https://localhost:5001/api/Expenses')
    .then(response => response.json())
    .then(data =>
    {
        Object.entries(data).forEach( (expense) => {
            showEntry(expenseList, "expense", expense[1].name, expense[1].amount, expense[1].id);
        });
    })

    fetch('https://localhost:5001/api/Incomes')
    .then(response => response.json())
    .then(data =>
    {
        Object.entries(data).forEach( (income) => {
            showEntry(incomeList, "income", income[1].name, income[1].amount, income[1].id);
        });
    })

    fetch('https://localhost:5001/api/Entries')
    .then(response => response.json())
    .then(data =>
    {
        Object.entries(data).forEach( (entry) => {

            showEntry(allList, entry[1].type, entry[1].name, entry[1].amount, entry[1].id);
        });
    })

    if(toggleBtn.checked)
    {

    }

    updateChart(income, outcome);
}

function showEntry(list, type, title, amount, id){

    const entry = ` <li id = "${id}" class="${type}">
                        <div class="entry">${title}: ${amount} PLN</div>
                        <div id="edit"></div>
                        <div id="delete"></div>
                    </li>`;

    const position = "afterbegin";

    list.insertAdjacentHTML(position, entry);
}

function clearElement(elements){
    elements.forEach( element => {
        element.innerHTML = "";
    })
}

function clearInput(inputs){
    inputs.forEach( input => {
        input.value = "";
    })
}
function show(element){
    element.classList.remove("hide");
}

function hide( elements ){
    elements.forEach( element => {
        element.classList.add("hide");
    })
}

function active(element){
    element.classList.add("active");
}

function inactive( elements ){
    elements.forEach( element => {
        element.classList.remove("active");
    })
}