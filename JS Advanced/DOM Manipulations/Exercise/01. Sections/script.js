function create(words) {
   const div = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      let p = document.createElement('div');

      p.textContent.display = 'block';

      p.addEventListener('mouseover', e => {
         p.textContent = words[i];
      });
      
      div.appendChild(p);
   }
}