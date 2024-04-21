function solve(input){
    let encodedMessage = input[0];
    for(let i=0;i<input.length-1;i++){
        let [cmd,substring,replacement] = input[i].split('?');
       if(cmd==='TakeEven'){
        let newMsg = '';
        for(let i=0;i<encodedMessage.length;i+=2){
        newMsg+=encodedMessage[i];
        }
        encodedMessage = newMsg;
        console.log(encodedMessage);
       }else if(cmd==='ChangeAll'){
        while(encodedMessage.includes(substring)){
            encodedMessage = encodedMessage.replace(substring,replacement);
        }
        console.log(encodedMessage);
       }else if(cmd==='Reverse'){
        if(!encodedMessage.includes(substring)){
         console.log('error');
         continue;
        }
         const index = encodedMessage.indexOf(substring);
         encodedMessage = encodedMessage.replace(substring,'');
         substring = substring.split('').reverse().join('');
         encodedMessage+=substring;
         console.log(encodedMessage);
       }
    }
    console.log(`The cryptocurrency is: ${encodedMessage}`);
}