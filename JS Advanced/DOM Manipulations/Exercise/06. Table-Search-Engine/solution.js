function solve() {
   document.querySelector('#searchBtn').addEventListener('click', e => {
      const query = document.querySelector('#searchField').value;
      if (query.trim().length === 0) {
         return;
      }
      const body = document.querySelector('tbody');
      [...body.querySelectorAll('tr')].forEach(r => {
         r.classList.remove('select');
      });
      [...body.querySelectorAll('td')].forEach(d => {
         if(d.textContent.includes(query)) {
            d.parentNode.classList.add('select');
         }
      });
      document.querySelector('#searchField').value = '';      
   });
}