function encodeAndDecodeMessages() {
    const inputElement = document.getElementsByTagName('textarea')[0];
    const outputElement= document.getElementsByTagName('textarea')[1];
    const buttonElements = document.getElementsByTagName('button');

    Array.from(buttonElements).forEach(x=>x.addEventListener('click',()=>{
        let outputText = '';
        if(x.textContent==='Encode and send it'){
            const text = inputElement.value;
         for (const char of text) {
           outputText+=String.fromCharCode(char.charCodeAt(char)+1);
         }
        }else if(x.textContent==='Decode and read it'){
            const text = outputElement.textContent;
            for (const char of text) {
                outputText+=String.fromCharCode(char.charCodeAt(char)-1);
              }
        }
        outputElement.textContent = outputText;
        inputElement.value = '';
    }));

}