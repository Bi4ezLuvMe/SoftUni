function deleteByEmail() {
   const emailElements = document.querySelectorAll('tr td:last-child');
   const resultElement = document.getElementById('result');
   const inputElement = document.querySelector('label input');
   
   let isFound = false;
   for (const email of emailElements) {
    if(email.textContent===inputElement.value){
       isFound = true;
       email.parentElement.remove();
    }
   }
   if(isFound){
    resultElement.textContent = 'Deleted.';
   }else{
    resultElement.textContent = 'Not found.'
   }
   inputElement.value = '';
}