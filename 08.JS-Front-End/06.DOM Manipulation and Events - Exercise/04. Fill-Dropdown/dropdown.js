function addItem() {
   const menuElement = document.getElementById('menu');
   const textElement = document.getElementById('newItemText');
   const valueElement = document.getElementById('newItemValue');
   const buttonElement = document.querySelector('input[type=button]');

    const newElement = document.createElement('option');

    newElement.textContent = textElement.value;
    newElement.value = valueElement.value;

    menuElement.appendChild(newElement);

    textElement.value ='';
    valueElement.value = '';
}