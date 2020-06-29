function solve() {
   const history = [];
   document.querySelector('#player1Div').addEventListener('click', onCardPickedFirst);
   document.querySelector('#player2Div').addEventListener('click', onCardPickedSecond);



   function onCardPickedFirst(e) {
      const [first, vs, second] = document.querySelector('#result').querySelectorAll('span');
      const target = e.target;
      const power = Number(target.name);
      if(power === undefined || isNaN(power)) {
         return;
      }

      

      // history adds first check for second
      if(history.length > 0 && history[history.length - 1].first === '') {
         history[history.length - 1].first = power;
      } else {
         history.push({
            first: power,
            second: ''
         })
      }

      target.outerHTML = '<img src="images/whiteCard.jpg"/>'
      first.append(power);
      
      console.log(target);
   }

   function onCardPickedSecond(e) {
      const result = document.querySelector('#result').querySelectorAll('span')[2];
      const target = e.target;
      const power = Number(target.name);
      if(power === undefined || isNaN(power)) {
         return;
      }

      if(history.length > 0 && history[history.length - 1].second === '') {
         history[history.length - 1].second = power;
         result.removeChild();
      } else {
         history.push({
            first: '',
            second: power
         })
      }
      target.outerHTML = '<img src="images/whiteCard.jpg"/>'
      result.append(power);
      console.log(target);
   }
}