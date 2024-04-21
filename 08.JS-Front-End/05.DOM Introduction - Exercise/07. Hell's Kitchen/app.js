function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
     const inputElement = document.getElementsByTagName('textarea')[0];
     const bestRestourantElement = document.querySelector('#bestRestaurant p');
     const bestRestourantWorkersElement = document.querySelector('#workers p'); 
  
      let restounrants = [];      
      let input = JSON.parse(inputElement.value);

      for (const restounrant of input) {
       let avgSalary = 0;
       const [name,employeesInfo] = restounrant.split(' - '); 
       let employees1 = employeesInfo.split(', ');
       let bestSalary = 0;
       let employees = '';
       let isThereARestounrant = restounrants.find(x=>x.restorantName===name);
       for (const employee of employees1) {
        if(isThereARestounrant){
          const [employeeName,salary] = employee.split(' ');
          avgSalary+=Number(salary);
          if(Number(salary)>isThereARestounrant.bestSalary){
            isThereARestounrant.bestSalary = Number(salary);
          }
          isThereARestounrant.employees+=`Name: ${employeeName} With Salary: ${salary} `
        }else{
          const [employeeName,salary] = employee.split(' ');
          avgSalary+=Number(salary);
          if(Number(salary)>bestSalary){
            bestSalary = Number(salary);
          }
         employees+=`Name: ${employeeName} With Salary: ${salary} `
        }
       }
       avgSalary/=employees1.length;
       if(isThereARestounrant){
        isThereARestounrant.avgSalary+=avgSalary;
        isThereARestounrant.employees+=employees;
       }else{
         restounrants.push({
           restorantName:name,
           avgSalary,
           employees,
           bestSalary,
         });
       }
      }
      restounrants.sort((a,b)=>b.avgSalary-a.avgSalary);
      const bestRestourant = restounrants[0];
      let outputRestoraunt = `Name: ${bestRestourant.restorantName} Average Salary: ${bestRestourant.avgSalary.toFixed(2)} Best Salary: ${bestRestourant.bestSalary.toFixed(2)}`
      bestRestourantElement.textContent=outputRestoraunt;
      bestRestourantWorkersElement.textContent=bestRestourant.employees;
   }
}