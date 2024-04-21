window.addEventListener("load", solve);

function solve() {
    const addButtonElement = document.getElementById('add-btn');
    const deleteButtonElement = document.createElement('button');

    addButtonElement.addEventListener('click',()=>{
      const contactNameElement = document.getElementById('name');
      const contactNumberElement = document.getElementById('phone');
      const contactTypeElement = document.getElementById('category');

      const contactName = contactNameElement.value;
      const contactNumber = contactNumberElement.value;
      const contactType = contactTypeElement.value;

      if(contactName===''||contactNumber===''||contactType===''){
        return;
      }

      const ulContactListElement = document.getElementById('contact-list');
      const ulCheckListElement = document.getElementById('check-list');

      const liElement = document.createElement('li');
      const articleElement = document.createElement('article');
      const pNameElement = document.createElement('p');
      const pNumberElement = document.createElement('p');
      const pTypeElement = document.createElement('p');
      const divButtonsElement = document.createElement('div');
      const editButtonElement = document.createElement('button');
      const saveButtonElement = document.createElement('button');

     divButtonsElement.classList.add('buttons');
     editButtonElement.classList.add('edit-btn');
     saveButtonElement.classList.add('save-btn');

     pNameElement.textContent = `name:${contactName}`;
     pNumberElement.textContent = `phone:${contactNumber}`;
     pTypeElement.textContent = `category:${contactType}`;

     articleElement.appendChild(pNameElement);
     articleElement.appendChild(pNumberElement);
     articleElement.appendChild(pTypeElement);
     divButtonsElement.appendChild(editButtonElement);
     divButtonsElement.appendChild(saveButtonElement);
     liElement.appendChild(articleElement);
     liElement.appendChild(divButtonsElement);
     ulCheckListElement.appendChild(liElement);

     contactNameElement.value = '';
     contactNumberElement.value = '';
     contactTypeElement.value = '';

     editButtonElement.addEventListener('click',()=>{
       ulCheckListElement.removeChild(liElement);

       contactNameElement.value = contactName;
       contactNumberElement.value = contactNumber;
       contactTypeElement.value = contactType;
      });

      saveButtonElement.addEventListener('click',()=>{
        ulCheckListElement.removeChild(liElement);
        liElement.removeChild(divButtonsElement);

        deleteButtonElement.classList.add('del-btn');

        liElement.appendChild(deleteButtonElement);
        ulContactListElement.appendChild(liElement);
      });
      
      deleteButtonElement.addEventListener('click',()=>{
      ulContactListElement.removeChild(liElement);
      });
    });
  }