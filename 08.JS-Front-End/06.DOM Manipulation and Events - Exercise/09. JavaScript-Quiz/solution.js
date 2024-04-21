function solve() {
  const questionsElements = document.querySelectorAll('section');
  const results = document.getElementById('results');
  const resultsHeader = results.querySelector('h1');
  const resultsList = results.querySelector('ul');
  const questions = {
    'Question #1: Which event occurs when the user clicks on an HTML element?':'onclick',
    'Question #2: Which function converting JSON to string?':'JSON.stringify()',
    'Question #3: What is DOM?':'A programming API for HTML and XML documents',
  }

  let currentQuestionIndex = 0;
  let correctAnswers = 0;

  function showNextQuestion() {
    if (currentQuestionIndex < questionsElements.length) {
      questionsElements[currentQuestionIndex].style.display = 'block';
    } else {
      showResults();
    }
  }

  function showResults() {
    results.style.display = 'block';
    if (correctAnswers === Object.keys(questions).length) {
      resultsHeader.textContent = "You are recognized as top JavaScript fan!";
    } else {
      resultsHeader.textContent = `You have ${correctAnswers} right answers`;
    }
  }

  for (const question of questionsElements) {
    const answerButtonElements = question.querySelectorAll('.quiz-answer');

    Array.from(answerButtonElements).forEach(answerButton => {
      answerButton.addEventListener('click', () => {
        const questionText = question.querySelector('.question-wrap h2').textContent;
        const answerButtonText = answerButton.querySelector('p').textContent;
        
        if (questions[questionText] === answerButtonText) {
          correctAnswers++;
        }
        
        question.style.display = 'none';
        currentQuestionIndex++;
        showNextQuestion();
      });
    });
  }

  showNextQuestion();
}