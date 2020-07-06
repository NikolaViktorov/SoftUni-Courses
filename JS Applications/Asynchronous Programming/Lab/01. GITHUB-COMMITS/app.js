function getUrl(username, repo) {
    return `https://api.github.com/repos/${username}/${repo}/commits`;
}

const usernameInput = document.getElementById('username');
const repoInput = document.getElementById('repo');
const commitsList = document.getElementById('commits');

function loadCommits() {
    const username = usernameInput.value;
    const repo = repoInput.value;
    const url = getUrl(username, repo);
    fetch(url)
        .then(res => res.json())
        .then(data => {
            while(commitsList.children.length > 0) {
                commitsList.children[0].remove();
            }
            data.forEach(d => {
                const li = document.createElement('li');
                li.textContent = `${d.commit.author.name} ${d.commit.message}`;
                commitsList.appendChild(li);
            });
        });
}