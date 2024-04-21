function baristas(input){
let baristas = [];
const baristasCount = Number(input[0]);
for(let i=1;i<=baristasCount;i++){
const [name,shift,drinks] = input[i].split(' ');
baristas.push({name,shift,drinks,});
}
for(let i=baristasCount+1;i<input.length-1;i++){
    const cmd = input[i].split(' / ');
    const baristaName = cmd[1];
    const barista = baristas.find(x=>x.name === baristaName);
    if(cmd[0]==='Prepare'){
        const shift = cmd[2];
        const coffeeType = cmd[3];
     if(barista){
        if(barista.shift===shift&&barista.drinks.includes(coffeeType)){
            console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
        }else{
            console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
        }
     }
    }else if(cmd[0]==='Change Shift'){
        const newShift = cmd[2];
        if(barista){
           barista.shift = newShift;
           console.log(`${baristaName} has updated his shift to: ${newShift}`);
        }
    }else if(cmd[0]==='Learn'){
        const newCoffeeType = cmd[2];
     if(barista){
        if(barista.drinks.includes(newCoffeeType)){
            console.log(`${baristaName} knows how to make ${newCoffeeType}.`);
        }else{
            barista.drinks+=`,${newCoffeeType}`;
            console.log(`${baristaName} has learned a new coffee type: ${newCoffeeType}.`);
        }
     }
    }
} 
for (const barista of baristas) {
    console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.drinks.split(',').join(', ')}`);
}
}