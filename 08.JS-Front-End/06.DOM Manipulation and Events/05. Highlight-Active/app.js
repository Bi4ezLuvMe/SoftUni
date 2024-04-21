function focused() {
 const inputElements = document.querySelectorAll('input');
 const arrInputElements = Array.from(inputElements);
  for (const inputElement of arrInputElements) {
    inputElement.addEventListener('focus',(e)=>{
        e.target.parentNode.classList.add('focused');
    });
    inputElement.addEventListener('blur',(e)=>{
        e.target.parentNode.classList.remove('focused');
    });
  }
}