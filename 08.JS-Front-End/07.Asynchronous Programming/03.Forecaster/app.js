function attachEvents() {
    const cityNameElement = document.getElementById('location');
    const submitButton = document.getElementById('submit');
    
    const url = 'http://localhost:3030/jsonstore/forecaster/';
    
    submitButton.addEventListener('click',()=>{
        const cityName = cityNameElement.value;
        const forecastElement = document.getElementById('forecast');
       fetch(url+'locations').then(x=>x.json()).then(data=>{
          let cities = data;
          const city = cities.find(x=>x.name===cityName);

          fetch(url+`today/`+city.code).then(res=>res.json()).then(data=>{
            const forecaster = data.forecast;
            const name = data.name;

            const condition = forecaster.condition;
            const highTemp = forecaster.high;
            const lowTemp = forecaster.low;

            forecastElement.style.display = 'block';
            const currentConditionElement = document.getElementById('current');
            const currentForecastElement = document.createElement('div');
            currentForecastElement.classList.add('forecasts');
            const spanContionSymbolElement = document.createElement('span');
            spanContionSymbolElement.classList.add('condition');
            spanContionSymbolElement.classList.add('symbol');
            const conditionElement = document.createElement('span');
            conditionElement.classList.add('condition');
            const forecastDataNameElement = document.createElement('span');
            const forecastDataTempElement = document.createElement('span');
            const forecastDataConditionElement = document.createElement('span');
            forecastDataConditionElement.classList.add('forecast-data');
            forecastDataNameElement.classList.add('forecast-data');
            forecastDataTempElement.classList.add('forecast-data');
            let conditionSymbol = '';
            switch(condition){
             case 'Sunny':conditionSymbol = '☀'; break;
             case 'Partly sunny':conditionSymbol = '⛅'; break;
             case 'Overcast':conditionSymbol = '☁'; break;
             case 'Rain':conditionSymbol = '☂'; break;
            }
            spanContionSymbolElement.textContent = conditionSymbol;
            forecastDataNameElement.textContent = name;
            forecastDataTempElement.textContent = `${lowTemp}°/${highTemp}°`
            forecastDataConditionElement.textContent = condition;

            conditionElement.appendChild(forecastDataNameElement);
            conditionElement.appendChild(forecastDataTempElement);
            conditionElement.appendChild(forecastDataConditionElement);
            currentForecastElement.appendChild(spanContionSymbolElement);
            currentForecastElement.appendChild(conditionElement);
            currentConditionElement.appendChild(currentForecastElement);
            
          }).catch(()=>console.log('Something Went Wrong'));

          fetch(url+`upcoming/`+city.code).then(res=>res.json()).then(data=>{
            const forecastInfoElement = document.createElement('div');
            const upcomingElement = document.getElementById('upcoming');
            forecastInfoElement.classList.add('forecast-info');
           for (const forecast of data.forecast) {
            const condition = forecast.condition;
            const highTemp = forecast.high;
            const lowTemp = forecast.low;

            const currentForecastElement = document.createElement('span');
            currentForecastElement.classList.add('upcoming');
            const spanSymbolElement = document.createElement('span');
            spanSymbolElement.classList.add('symbol');
            const spanTempElement = document.createElement('span');
            const spanConditionElement = document.createElement('span');
            spanTempElement.classList.add('forecast-data');
            spanConditionElement.classList.add('forecast-data');
            let conditionSymbol = '';
            switch(condition){
                case 'Sunny':conditionSymbol = '☀'; break;
                case 'Partly sunny':conditionSymbol = '⛅'; break;
                case 'Overcast':conditionSymbol = '☁'; break;
                case 'Rain':conditionSymbol = '☂'; break;
               }
               spanSymbolElement.textContent = conditionSymbol;
            spanTempElement.textContent = `${lowTemp}°/${highTemp}°`;
            spanConditionElement.textContent = condition;
            currentForecastElement.appendChild(spanSymbolElement);
            currentForecastElement.appendChild(spanTempElement);
            currentForecastElement.appendChild(spanConditionElement);
            forecastInfoElement.appendChild(currentForecastElement);
        }
        upcomingElement.appendChild(forecastInfoElement);
            
          }).catch(()=>console.log('Something Went Wrong 2'));;
       });

    });
}

attachEvents();