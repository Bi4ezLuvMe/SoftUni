function solve() {
  const addMealButtonElement = document.getElementById('add-meal');
  const loadMealsButtonElement = document.getElementById('load-meals');
  const editMealButtonElement = document.getElementById('edit-meal');
  const getMealsUrl = 'http://localhost:3030/jsonstore/tasks';

  // Function to create meal elements
  function createMealElement(food) {
      const listMealsElement = document.getElementById('list');

      const divMealElement = document.createElement('div');
      divMealElement.classList.add('meal');
      const foodTypeElement = document.createElement('h2');
      const foodCaloriesElement = document.createElement('h3');
      const foodTimeElement = document.createElement('h3');
      foodTypeElement.textContent = food.food;
      foodCaloriesElement.textContent = food.calories;
      foodTimeElement.textContent = food.time;
      const divMealButtonsElement = document.createElement('div');
      divMealButtonsElement.classList.add('meal-buttons');
      const changeMealButtonElement = document.createElement('button');
      const deleteMealButtonElement = document.createElement('button');
      changeMealButtonElement.classList.add('change-meal');
      deleteMealButtonElement.classList.add('delete-meal');
      changeMealButtonElement.textContent = 'Change';
      deleteMealButtonElement.textContent = 'Delete';
      divMealButtonsElement.appendChild(changeMealButtonElement);
      divMealButtonsElement.appendChild(deleteMealButtonElement);
      divMealElement.appendChild(foodTypeElement);
      divMealElement.appendChild(foodCaloriesElement);
      divMealElement.appendChild(foodTimeElement);
      divMealElement.appendChild(divMealButtonsElement);
      listMealsElement.appendChild(divMealElement);

      // Event listener for Change button
      changeMealButtonElement.addEventListener('click', () => {
          // Populate input fields
          const foodTypeInput = document.getElementById('food');
          const timeInput = document.getElementById('time');
          const caloriesInput = document.getElementById('calories');
          foodTypeInput.value = food.food;
          timeInput.value = food.time;
          caloriesInput.value = food.calories;

          // Enable edit meal button and disable add meal button
          editMealButtonElement.disabled = false;
          addMealButtonElement.disabled = true;

          // Event listener for Edit Meal button
          editMealButtonElement.addEventListener('click', () => {
              const updatedFood = foodTypeInput.value;
              const updatedTime = timeInput.value;
              const updatedCalories = caloriesInput.value;

              const updatedMeal = {
                  food: updatedFood,
                  time: updatedTime,
                  calories: updatedCalories
              };

              // Send PUT request to update meal
              fetch(`${getMealsUrl}/${food._id}`, {
                  method: 'PUT',
                  headers: {
                      'Content-Type': 'application/json'
                  },
                  body: JSON.stringify(updatedMeal)
              })
              .then(response => response.json())
              .then(() => {
                  // After successful update, reload meals
                  loadMeals();
              })
              .catch(error => console.error('Error updating meal:', error));

              // Disable edit meal button and enable add meal button
              editMealButtonElement.disabled = true;
              addMealButtonElement.disabled = false;
          });
      });

      // Event listener for Delete button
      deleteMealButtonElement.addEventListener('click', () => {
          // Send DELETE request to delete meal
          fetch(`${getMealsUrl}/${food._id}`, {
              method: 'DELETE'
          })
          .then(() => {
              // After successful deletion, reload meals
              loadMeals();
          })
          .catch(error => console.error('Error deleting meal:', error));
      });
  }

  // Function to load meals
  function loadMeals() {
      fetch(getMealsUrl)
      .then(response => response.json())
      .then(data => {
          const meals = Object.values(data);
          const listMealsElement = document.getElementById('list');
          listMealsElement.innerHTML = ''; // Clear previous meals
          meals.forEach(meal => {
              createMealElement(meal);
          });
      })
      .catch(error => console.error('Error loading meals:', error));
  }

  // Event listener for Load Meals button
  loadMealsButtonElement.addEventListener('click', () => {
      loadMeals();
  });

  // Event listener for Add Meal button
  addMealButtonElement.addEventListener('click', () => {
      const foodTypeInput = document.getElementById('food');
      const timeInput = document.getElementById('time');
      const caloriesInput = document.getElementById('calories');
      const newMeal = {
          food: foodTypeInput.value,
          time: timeInput.value,
          calories: caloriesInput.value
      };

      // Send POST request to add new meal
      fetch(getMealsUrl, {
          method: 'POST',
          headers: {
              'Content-Type': 'application/json'
          },
          body: JSON.stringify(newMeal)
      })
      .then(() => {
          // After successful addition, reload meals
          loadMeals();
          // Clear input fields
          foodTypeInput.value = '';
          timeInput.value = '';
          caloriesInput.value = '';
      })
      .catch(error => console.error('Error adding meal:', error));
  });
}

// Call solve function
solve();
