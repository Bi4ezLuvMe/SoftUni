window.addEventListener("load", solve);

function solve(){
    const addButtonElement = document.getElementById('add-btn');
    const deleteButtonElement = document.createElement('button');

    addButtonElement.addEventListener('click',()=>{
     const placeElement = document.getElementById('place');
     const actionElement = document.getElementById('action');
     const personElement = document.getElementById('person');

     const place = placeElement.value;
     const action = actionElement.value;
     const person = personElement.value;
 
     placeElement.value = '';
     actionElement.value = '';
     personElement.value = '';

     if(place===''||action===''||person===''){
        return;
     }
    
     const ulDoneElement = document.getElementById('done-list')
     const ulElement = document.getElementById('task-list');
     const liElement = document.createElement('li');
     const articleElement = document.createElement('article');
     const placePElement = document.createElement('p');
     const actionPElement = document.createElement('p');
     const personPElement = document.createElement('p');
     const divElement = document.createElement('div');
     const editButtonElement = document.createElement('button');
     const doneButtonElement = document.createElement('button');

     liElement.classList.add('clean-task');
     placePElement.textContent = `Place:${place}`;
     actionPElement.textContent = `Action:${action}`;
     personPElement.textContent = `Person:${person}`;
     articleElement.appendChild(placePElement);
     articleElement.appendChild(actionPElement);
     articleElement.appendChild(personPElement);
     divElement.classList.add('buttons');
     editButtonElement.classList.add('edit');
     editButtonElement.textContent = 'Edit';
     doneButtonElement.classList.add('done');
     doneButtonElement.textContent = 'Done';
     divElement.appendChild(editButtonElement);
     divElement.appendChild(doneButtonElement);
     liElement.appendChild(articleElement);
     liElement.appendChild(divElement);
     ulElement.appendChild(liElement);

     editButtonElement.addEventListener('click',()=>{
     ulElement.removeChild(liElement);
     placeElement.value = place;
     actionElement.value = action;
     personElement.value = person;
     });

     doneButtonElement.addEventListener('click',()=>{
        ulElement.removeChild(liElement);
        liElement.removeChild(divElement);
        deleteButtonElement.classList.add('delete');
        deleteButtonElement.textContent = 'Delete';
        liElement.appendChild(deleteButtonElement);
        ulDoneElement.appendChild(liElement);
     });

     deleteButtonElement.addEventListener('click',()=>{
      ulDoneElement.removeChild(liElement);
     });
    });
}