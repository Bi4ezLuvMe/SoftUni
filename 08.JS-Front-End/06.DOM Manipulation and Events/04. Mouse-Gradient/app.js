function attachGradientEvents() {
  const greadientElement = document.getElementById('gradient');
  const resultElement = document.getElementById('result');
  const width = greadientElement.offsetWidth;
  greadientElement.addEventListener('mousemove',(event)=>{
   const currWidth = event.offsetX;
   const progress = Math.truc(((currWidth/width)*100));
   resultElement.textContent = `${progress}%`;
  });
  greadientElement.addEventListener('mouseout',()=>{
    resultElement.textContent = '';
   });
}