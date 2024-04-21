function solve() {
  function toCamelCase(str){
    return str.split(' ').map(function(word,index){
      if(index == 0){
        return word.toLowerCase();
      }
      return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
    }).join('')
  }
  function toPascalCase(str){
    return str.split(' ').map(function(word){
      return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
    }).join('')
  }
   const textToTransformElement = document.getElementById('text');
   const namingConventionElement = document.getElementById('naming-convention');
   const resultElement = document.getElementById('result');

   const namingConvention = namingConventionElement.value;
   const textToTranform = textToTransformElement.value;
   let result='';

   if(namingConvention ==='Camel Case'){
   result = toCamelCase(textToTranform);
   }else if(namingConvention ==='Pascal Case'){
  result = toPascalCase(textToTranform);
   }else{
   result = 'Error!'
   }
   resultElement.textContent = result;
}