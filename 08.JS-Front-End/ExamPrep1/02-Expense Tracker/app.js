window.addEventListener("load", solve);

function solve(){
    const addButtonElement = document.getElementById('add-btn');
    const deleteButtonElement = document.getElementsByClassName('delete')[0];

    addButtonElement.addEventListener('click',()=>{
        let expenseTypeElement = document.getElementById('expense');
        let amountElement = document.getElementById('amount');
        let dateElement = document.getElementById('date');

        let expenseType = expenseTypeElement.value;
        let amount = amountElement.value;
        let date =dateElement.value;

        if(expenseType===''||amount===''||date===''){
            return;
        }
        expenseTypeElement.value = '';
        amountElement.value = '';
        dateElement.value = '';
        addButtonElement.disabled = true;

        const expensesUlElement = document.getElementById('expenses-list');
        const ulElement = document.getElementById('preview-list');
        const liElement = document.createElement('li');
        const articleElement = document.createElement('article');
        const pTypeElement = document.createElement('p');
        const pAmountElement = document.createElement('p');
        const pDateElement = document.createElement('p');
        const divElement = document.createElement('div');
        const buttonEditElement = document.createElement('button');
        const buttonOKElement = document.createElement('button');

        liElement.classList.add('expense-item');
        pTypeElement.textContent = `Type: ${expenseType}`;
        pAmountElement.textContent = `Amount: ${amount}$`;
        pDateElement.textContent = `Date: ${date}`;
        articleElement.appendChild(pTypeElement);
        articleElement.appendChild(pAmountElement);
        articleElement.appendChild(pDateElement);
        divElement.classList.add('buttons');
        buttonEditElement.classList.add('btn');
        buttonEditElement.classList.add('edit');
        buttonEditElement.textContent = 'Edit';
        buttonOKElement.classList.add('btn');
        buttonOKElement.classList.add('ok');
        buttonOKElement.textContent = 'OK';
        divElement.appendChild(buttonEditElement);
        divElement.appendChild(buttonOKElement);
        liElement.appendChild(articleElement);
        liElement.appendChild(divElement);
        ulElement.appendChild(liElement);

        buttonEditElement.addEventListener('click',()=>{
            expenseTypeElement.value = expenseType;
            amountElement.value = amount;
            dateElement.value = date;
            addButtonElement.disabled = false;
            ulElement.removeChild(liElement);
        });
        buttonOKElement.addEventListener('click',()=>{
            ulElement.removeChild(liElement);
            liElement.removeChild(divElement);
            addButtonElement.disabled = false;
            expensesUlElement.appendChild(liElement);
        });
        deleteButtonElement.addEventListener('click',()=>{
            expensesUlElement.innerHTML = '';
        })
    });
}