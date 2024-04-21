function subtract() {
    const firstNumberElement = document.getElementById('firstNumber');
    const secondNumberElement = document.getElementById('secondNumber');
    const resultNumberElement = document.getElementById('result');

    resultNumberElement.textContent = Number(firstNumberElement.value) - Number(secondNumberElement.value);
}