function addItem() {
    const itemsElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');
 
    const newElement = document.createElement('li');
    const deleteButton = document.createElement('a');
    deleteButton.textContent = '[Delete]'
    deleteButton.href = '#';
    deleteButton.addEventListener('click',()=>{
     deleteButton.parentElement.remove();
    });
    newElement.textContent = inputElement.value;
    
    newElement.appendChild(deleteButton);
    itemsElement.appendChild(newElement);
 
    inputElement.value = '';
}