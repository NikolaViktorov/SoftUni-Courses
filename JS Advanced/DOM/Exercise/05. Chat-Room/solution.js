function solve() {
   document.querySelector('#send').addEventListener('click', send);

   function send(e) {
      const chat = document.querySelector('#chat_messages');
      const input = document.querySelector('#chat_input').value;
      const output = document.createElement('div');
      output.className = 'message my-message';
      output.textContent = input;

      chat.appendChild(output);
      document.querySelector('#chat_input').value = '';
   }

}


