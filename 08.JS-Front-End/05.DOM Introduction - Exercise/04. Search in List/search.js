function search() {
  const listElements = document.getElementsByTagName('li');
  const searchedElement = document.getElementById('searchText');
  const resultElement = document.getElementById('result');

  let matchesFound = 0;
  const searchedWord = searchedElement.value;
  console.log(searchedWord);
  for (const element of listElements) {
   if(element.textContent.includes(searchedWord)){
      element.style.fontWeight = 'bold';
      element.style.textDecoration = 'underline';
      matchesFound++;
   }
  }
  resultElement.textContent = `${matchesFound} matches found`;
}
