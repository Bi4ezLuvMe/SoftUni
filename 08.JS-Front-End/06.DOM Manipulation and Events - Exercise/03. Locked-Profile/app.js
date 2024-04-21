function lockedProfile() {
    const profilesElements = document.getElementsByClassName('profile');
    const buttonsElements = document.getElementsByTagName('button');

     Array.from(buttonsElements).forEach(x=>x.addEventListener('click',()=>{
     const isLocked = x.parentElement.getElementsByTagName('input')[0].checked;
     if(!isLocked){
         const hiddenInfo = x.parentElement.getElementsByTagName('div')[0];
        if(x.textContent === 'Show more'){
            hiddenInfo.style.display = 'block';
            x.textContent = 'Hide it';
        }else if(x.textContent === 'Hide it'){
        hiddenInfo.style.display = 'none';
        x.textContent = 'Show more';
        }
     }
     }));
}