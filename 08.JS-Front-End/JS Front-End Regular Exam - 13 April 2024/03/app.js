function solve(){
const loadGamesButtonElement = document.getElementById('load-games');
const addGameButtonElement = document.getElementById('add-game');
const editGameButtonElement = document.getElementById('edit-game');
const loadGamesURL = 'http://localhost:3030/jsonstore/games';

loadGamesButtonElement.addEventListener('click', () => {
    /*
    fetch(loadGamesURL).then(result=>result.json()).then(data=>{
 const games = Object.values(data);
 for (const game of games) {
     const gamesListDiv = document.getElementById('games-list');
    
     const divGameElement = document.createElement('div');
     const divGameContentElement = document.createElement('div');
     const pGameNameElement = document.createElement('p');
     const pGamePlayersElement = document.createElement('p');
     const pGameTypeElement = document.createElement('p');
     const divButtonsElement = document.createElement('div');
     const changeButtonElement = document.createElement('button');
     const deleteButtonElement = document.createElement('button');
    
    divGameElement.classList.add('board-game');
    divGameContentElement.classList.add('content');
    divButtonsElement.classList.add('buttons-container');
    changeButtonElement.classList.add('change-btn');
    deleteButtonElement.classList.add('delete-btn');
    
    pGameNameElement.textContent = game.name;
    pGamePlayersElement.textContent = game.players;
    pGameTypeElement.textContent = game.type;
    changeButtonElement.textContent = 'Change';
    deleteButtonElement.textContent = 'Delete';

    divGameContentElement.appendChild(pGameNameElement);
    divGameContentElement.appendChild(pGamePlayersElement);
    divGameContentElement.appendChild(pGameTypeElement);
    divButtonsElement.appendChild(changeButtonElement);
    divButtonsElement.appendChild(deleteButtonElement);
    divGameElement.appendChild(divGameContentElement);
    divGameElement.appendChild(divButtonsElement);
    gamesListDiv.appendChild(divGameElement);

    changeButtonElement.addEventListener('click',()=>{
        const gameNameElement = document.getElementById('g-name');
        const gameTypeElement = document.getElementById('type');
        const maxPlayersElement = document.getElementById('players');

        gameNameElement.value = game.name;
        gameTypeElement.value = game.type;
        maxPlayersElement.value = game.players;

        editGameButtonElement.disabled = false;
        addGameButtonElement.disabled = true;

        editGameButtonElement.addEventListener('click',()=>{
         const newGameName= gameNameElement.value;
         const newgameType = gameTypeElement.value;
         const newMaxPlayers = maxPlayersElement.value;

        const updatedGame = {
            name:newGameName,
            type:newgameType,
            players:newMaxPlayers,
        };

        fetch(`${loadGamesURL}/${game._id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedGame)
        })
        .then(response => response.json())
        .then(() => {
            loadGamesButtonElement.click();
            gameNameElement.value = '';
            gameTypeElement.value = '';
            maxPlayersElement.value = '';
        })
        .catch(error => console.error('Error updating game:', error));
        });

        editGameButtonElement.disabled = true;
        addGameButtonElement.disabled = false;
    });

    deleteButtonElement.addEventListener('click',()=>{
        fetch(`${loadGamesURL}/${game._id}`, {
            method: 'DELETE'
        })
        .then(() => {
            loadGamesButtonElement.click();
        })
        .catch(error => console.error('Error deleting game:', error));
    });
 }
}).catch(error => console.error('Error loading games:', error));*/
    fetch(loadGamesURL)
        .then(result => result.json())
        .then(data => {
            const gamesListDiv = document.getElementById('games-list');

            Object.values(data).forEach(game => {
                const divGameElement = document.createElement('div');
                const divGameContentElement = document.createElement('div');
                const pGameNameElement = document.createElement('p');
                const pGamePlayersElement = document.createElement('p');
                const pGameTypeElement = document.createElement('p');
                const divButtonsElement = document.createElement('div');
                const changeButtonElement = document.createElement('button');
                const deleteButtonElement = document.createElement('button');

                divGameElement.classList.add('board-game');
                divGameContentElement.classList.add('content');
                divButtonsElement.classList.add('buttons-container');
                changeButtonElement.classList.add('change-btn');
                deleteButtonElement.classList.add('delete-btn');

                pGameNameElement.textContent = game.name;
                pGamePlayersElement.textContent = game.players;
                pGameTypeElement.textContent = game.type;
                changeButtonElement.textContent = 'Change';
                deleteButtonElement.textContent = 'Delete';

                divGameContentElement.appendChild(pGameNameElement);
                divGameContentElement.appendChild(pGamePlayersElement);
                divGameContentElement.appendChild(pGameTypeElement);
                divButtonsElement.appendChild(changeButtonElement);
                divButtonsElement.appendChild(deleteButtonElement);
                divGameElement.appendChild(divGameContentElement);
                divGameElement.appendChild(divButtonsElement);
                gamesListDiv.appendChild(divGameElement);

                changeButtonElement.addEventListener('click', () => {
                    const gameNameElement = document.getElementById('g-name');
                    const gameTypeElement = document.getElementById('type');
                    const maxPlayersElement = document.getElementById('players');

                    gameNameElement.value = game.name;
                    gameTypeElement.value = game.type;
                    maxPlayersElement.value = game.players;

                    editGameButtonElement.disabled = false;
                    addGameButtonElement.disabled = true;

                    editGameButtonElement.addEventListener('click', () => {
                        const newGameName = gameNameElement.value;
                        const newGameType = gameTypeElement.value;
                        const newMaxPlayers = maxPlayersElement.value;

                        const updatedGame = {
                            name: newGameName,
                            type: newGameType,
                            players: newMaxPlayers
                        };

                        fetch(`${loadGamesURL}/${game._id}`, {
                            method: 'PUT',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(updatedGame)
                        })
                        .then(() => {
                            loadGamesButtonElement.click();
                            gameNameElement.value = '';
                            gameTypeElement.value = '';
                            maxPlayersElement.value = '';
                        })
                        .catch(error => console.error('Error updating game:', error));

                        editGameButtonElement.disabled = true;
                        addGameButtonElement.disabled = false;
                    });
                });

                deleteButtonElement.addEventListener('click', () => {
                    fetch(`${loadGamesURL}/${game._id}`, {
                        method: 'DELETE'
                    })
                    .then(() => {
                        loadGamesButtonElement.click();
                    })
                    .catch(error => console.error('Error deleting game:', error));
                });
            });
        })
        .catch(error => console.error('Error loading games:', error));
});

addGameButtonElement.addEventListener('click',()=>{
const gameNameElement = document.getElementById('g-name');
const gameTypeElement = document.getElementById('type');
const maxPlayersElement = document.getElementById('players');

const gameName = gameNameElement.value;
const gameType = gameTypeElement.value;
const maxPlayers = maxPlayersElement.value;

if(gameName === ''||gameType===''||maxPlayers===''){
    return;
}

const game = {
    name:gameName,
    type:gameType,
    players:maxPlayers,
};

fetch(loadGamesURL, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(game)
})
.then(() => {
    loadGamesButtonElement.click();

    gameNameElement.value = '';
    gameTypeElement.value = '';
    maxPlayersElement.value = '';
})
.catch(error => console.error('Error adding game:', error));
});
editGameButtonElement.disabled = true;
}
solve();