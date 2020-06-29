function solve() {
  const inputParagraph = document.getElementById('input');
  const output = document.getElementById('output');
  const pValue = inputParagraph.innerText;

  const sentences = Array.from(pValue.split('. '));
  let newParagraph = document.createElement('p');

  for (let i = 0; i < sentences.length; i++) {

    newParagraph.innerText += sentences[i];
    if ((i + 1) % 3 === 0) {
      output.appendChild(newParagraph);
      newParagraph = document.createElement('p');
    } else if(sentences.length == i + 1) {
      output.appendChild(newParagraph);
    }

  }
}