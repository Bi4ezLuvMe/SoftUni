function addItem() {
   const itemsElement = document.getElementById('items');
   const inputElement = document.getElementById('newItemText');

   const newElement = document.createElement('li');
   newElement.textContent = inputElement.value;

   itemsElement.appendChild(newElement);

   inputElement.value = '';
}