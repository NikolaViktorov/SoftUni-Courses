function solve(){
   function changeColor(e) {
      const target = e.target.parentNode;
      const rows = [...tbody.querySelectorAll('tr')];

      let isTog = target.style.backgroundColor === 'rgb(65, 63, 94)';

      rows.forEach(r => r.style.backgroundColor = '')
      
      if(isTog) {
         target.style.backgroundColor = '';
      } else {
      target.style.backgroundColor = '#413f5e';
      }

   }

   const tbody = document.querySelector('tbody');
   tbody.addEventListener('click', changeColor);
}
