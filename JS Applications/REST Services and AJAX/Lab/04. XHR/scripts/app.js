function loadRepos() {
   const url = 'https://api.github.com/users/testnakov/repos';
   const resultDiv = document.querySelector('#res');

   const httpReq = new XMLHttpRequest();
   httpReq.addEventListener('readystatechange', function get(e) {
      if (httpReq.status == 200 && httpReq.readyState == 4) {
         resultDiv.textContent = httpReq.responseText;
      }
   })
   httpReq.open('GET', url);
   httpReq.send();
}