function validate() {
    const emailElement = document.getElementById('email');
    const pattern = /([a-z]+\@[a-z]+\.[a-z]+$)/;
    emailElement.addEventListener('change',()=>{
     const emailText = emailElement.value;
     if(!emailText.match(pattern)){
        emailElement.classList.add('error');
     }else{
        emailElement.classList.remove('error');
     }
    });
}