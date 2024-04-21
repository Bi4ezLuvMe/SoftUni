function create(words) {
  const contentElement = document.getElementById('content');

  for (const word of words) {
   const divElement = document.createElement('div');
   const paragraphElement = document.createElement('p');

   paragraphElement.textContent = word;
   paragraphElement.style.display = 'none';

   divElement.appendChild(paragraphElement);
   contentElement.appendChild(divElement);

   divElement.addEventListener('click',()=>{
   paragraphElement.style.display = 'block';
   });
  }
}