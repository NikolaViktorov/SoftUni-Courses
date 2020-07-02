const reposList = document.getElementById('repos');
const usernameInput = document.getElementById('username');

const clearButton = document.getElementById('clear');

clearButton.addEventListener('click', clearRepoList);

function loadRepos() {
	const username = usernameInput.value;
	const url = `https://api.github.com/users/${username}/repos`;
	fetch(url)
		.then(res => res.json())
		.then(data => {
			data.forEach(item => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.href = item.html_url;
				a.innerHTML = item.full_name;
				li.appendChild(a);
				reposList.appendChild(li);
			});
		});
}

function clearRepoList(e) {
	while(reposList.children.length > 0) {
		reposList.children[0].remove();
	}
}