function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
   const searchElement = document.getElementById('searchField');
   const peopleInfoElements = document.querySelectorAll('tbody tr td');

   const searchWord = searchElement.value;
   for (const peopleInfo of peopleInfoElements) {
         if(peopleInfo.textContent.includes(searchWord)){
            peopleInfo.parentNode.classList.add('select');
         }
   }
   }
}