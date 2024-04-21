function attachEventsListeners() {
  const convertButtonElement = document.getElementById('convert');
  const inputDistanceElement = document.getElementById('inputDistance');
  const outputElement = document.getElementById('outputDistance');
  const inputTypeElement = document.getElementById('inputUnits');
  const outputTypeElement = document.getElementById('outputUnits');

  convertButtonElement.addEventListener('click',()=>{
   let outputInMetres = inputDistanceElement.value;
   const from = inputTypeElement.value;
   const to = outputTypeElement.value;
   switch(from){
    case'km': outputInMetres *= 1000; break;
    case'm':outputInMetres *= 1; break;
    case'cm':outputInMetres *= 0.01; break;
    case'mm':outputInMetres *= 0.001; break;
    case'mi':outputInMetres *= 1609.34; break;
    case'yrd':outputInMetres *= 0.9144; break;
    case'ft':outputInMetres *= 0.3048; break;
    case'in':outputInMetres *= 0.0254; break;
   }
   switch(to){
    case'km': outputInMetres /= 1000; break;
    case'm':outputInMetres /= 1; break;
    case'cm':outputInMetres /= 0.01; break;
    case'mm':outputInMetres /= 0.001; break;
    case'mi':outputInMetres /= 1609.34; break;
    case'yrd':outputInMetres /= 0.9144; break;
    case'ft':outputInMetres /= 0.3048; break;
    case'in':outputInMetres /= 0.0254; break;
   }
   outputElement.value = outputInMetres;
  });
}