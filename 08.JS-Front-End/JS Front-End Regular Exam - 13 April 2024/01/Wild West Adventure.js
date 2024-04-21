function solve(input){
  const gunmenCount = Number(input[0]);
  const gunmen = [];

  for (let i = 1; i <= gunmenCount; i++) {
   const [heroName, HP, bullets] = input[i].split(' ');
   const gunman = {heroName,
    HP:Number(HP),
    bullets:Number(bullets),
};
   gunmen.push(gunman);
  }

  for (let i = gunmenCount + 1; i < input.length - 1; i++) {
   const command = input[i].split(' - ');

   const gunmanName = command[1];
   const gunman = gunmen.find(x=>x.heroName===gunmanName);

   if(!gunman){
    continue;
   }

   if(command[0]==='FireShot'){
    
  if(gunman.bullets>0){
      gunman.bullets--;
      console.log(`${gunmanName} has successfully hit ${command[2]} and now has ${gunman.bullets} bullets!`);
  }else{
    console.log(`${gunmanName} doesn't have enough bullets to shoot at ${command[2]}!`);
  }
   }else if(command[0]==='TakeHit'){
   gunman.HP-=Number(command[2]);
   if(gunman.HP>0){
    console.log(`${gunmanName} took a hit for ${command[2]} HP from ${command[3]} and now has ${gunman.HP} HP!`);
   }else{
    const index = gunmen.indexOf(gunman);
    gunmen.splice(index,1);
    console.log(`${gunmanName} was gunned down by ${command[3]}!`);
   }
   }else if(command[0]==='Reload'){
     if(gunman.bullets<6){
         console.log(`${gunmanName} reloaded ${6-gunman.bullets} bullets!`);
         gunman.bullets = 6;
     }else{
        console.log(`${gunmanName}'s pistol is fully loaded!`);
     }
   }else if(command[0]==='PatchUp'){
    if(gunman.HP===100){
     console.log(`${gunmanName} is in full health!`);
    }else{
        if(gunman.HP+Number(command[2])>100){
            console.log(`${gunmanName} patched up and recovered ${100-(Number(command[2]+gunman.HP))} HP!`);
        }else{
            gunman.HP+=Number(command[2]);
            console.log(`${gunmanName} patched up and recovered ${Number(command[2])} HP!`);
        }
    }
   }
  }
  for (const gunman of gunmen) {
    console.log(gunman.heroName);
    console.log(` HP: ${gunman.HP}`);
    console.log(` Bullets: ${gunman.bullets}`);
  }
}