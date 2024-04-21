function solve() {
    const addGiftButton = document.getElementById('add-present');
    const editGiftButton = document.getElementById('edit-present');
    const loadPresentsButton = document.getElementById('load-presents');
    const giftList = document.getElementById('gift-list');
    const giftEndpoint = 'http://localhost:3030/jsonstore/gifts';

    // Function to create a present element
    function createPresentElement(present) {
        const presentElement = document.createElement('div');
        presentElement.classList.add('gift-sock');

        const content = document.createElement('div');
        content.classList.add('content');
        content.innerHTML = `
            <p>${present.gift}</p>
            <p>${present.for}</p>
            <p>${present.price}</p>
        `;
        presentElement.appendChild(content);

        const buttonsContainer = document.createElement('div');
        buttonsContainer.classList.add('buttons-container');

        const changeButton = document.createElement('button');
        changeButton.classList.add('change-btn');
        changeButton.textContent = 'Change';
        changeButton.addEventListener('click', () => {
            editGiftButton.disabled = false;
            addGiftButton.disabled = true;

            // Populate input fields
            document.getElementById('gift').value = present.gift;
            document.getElementById('for').value = present.for;
            document.getElementById('price').value = present.price;

            // Event listener for Edit Present button
            editGiftButton.addEventListener('click', () => {
                const updatedPresent = {
                    gift: document.getElementById('gift').value,
                    for: document.getElementById('for').value,
                    price: document.getElementById('price').value
                };

                // Send PUT request to update the present
                fetch(`${giftEndpoint}/${present._id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(updatedPresent)
                })
                .then(response => response.json())
                .then(() => {
                    loadPresents();
                    // Clear input fields
                    document.getElementById('gift').value = '';
                    document.getElementById('for').value = '';
                    document.getElementById('price').value = '';
                })
                .catch(error => console.error('Error updating present:', error));

                // Disable edit gift button and enable add gift button
                editGiftButton.disabled = true;
                addGiftButton.disabled = false;
            });
        });

        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete-btn');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', () => {
            // Send DELETE request to remove the present
            fetch(`${giftEndpoint}/${present._id}`, {
                method: 'DELETE'
            })
            .then(() => {
                loadPresents();
            })
            .catch(error => console.error('Error deleting present:', error));
        });

        buttonsContainer.appendChild(changeButton);
        buttonsContainer.appendChild(deleteButton);
        presentElement.appendChild(buttonsContainer);

        return presentElement;
    }

    // Function to load presents
    function loadPresents() {
        fetch(giftEndpoint)
        .then(response => response.json())
        .then(data => {
            giftList.innerHTML = '';
            Object.values(data).forEach(present => {
                const presentElement = createPresentElement(present);
                giftList.appendChild(presentElement);
            });
        })
        .catch(error => console.error('Error loading presents:', error));
    }

    // Event listener for Load Presents button
    loadPresentsButton.addEventListener('click', loadPresents);

    // Event listener for Add Gift button
    addGiftButton.addEventListener('click', () => {
        const giftInput = document.getElementById('gift').value;
        const forInput = document.getElementById('for').value;
        const priceInput = document.getElementById('price').value;

        const newPresent = {
            gift: giftInput,
            for: forInput,
            price: priceInput
        };

        // Send POST request to add new present
        fetch(giftEndpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newPresent)
        })
        .then(() => {
            loadPresents();
            // Clear input fields
            document.getElementById('gift').value = '';
            document.getElementById('for').value = '';
            document.getElementById('price').value = '';
        })
        .catch(error => console.error('Error adding present:', error));
    });
}

// Call solve function
solve();
