const baseUrl = `https://blog-apps-c12bf.firebaseio.com/`;

const loadProjBtn = document.getElementById('btnLoadPosts');
const viewPostsBtn = document.getElementById('btnViewPost');

const postsList = document.getElementById('posts');

const titleEl = document.getElementById('post-title');
const bodyElList = document.getElementById('post-body');
const commentsList = document.getElementById('post-comments');

loadProjBtn.addEventListener('click', loadProjects);
viewPostsBtn.addEventListener('click', viewPosts);

function ffetch(url, options) {
    options = options || {};
    return new Promise(function (resolve, reject) {
        const req = new XMLHttpRequest();
        req.onreadystatechange = function() {
            if (req.readyState === 4) {
                if (req.status === 200) {
                    resolve(JSON.parse(req.responseText));
                    return;
                }
                reject(new Error(req.status));
            }
        }
        req.open(options.method || 'GET', url);
        req.send(options.body);
    });
}

function loadProjects(e) {
    const url = baseUrl + '/posts.json';
    ffetch(url).then(data => {
        Object.keys(data).forEach(key => {
            const opt = el('option', data[key].title , { value: key})
            postsList.appendChild(opt);
        });
    });
    /*
    fetch(url)
        .then(res => res.json())
        .then(data => {
            Object.keys(data).forEach(k => {
                const opt = el('option', data[k].title , { value: k})
                postsList.appendChild(opt);
            });
        });
    */
}

function viewPosts(e) {
    const selectedIndex = postsList.selectedIndex;
    const selectedOptionId = postsList[selectedIndex].value;

    let postUrl = baseUrl + `posts/${selectedOptionId}`;
    const commentsUrl = postUrl + `/comments.json`;
    postUrl += '.json';

    ffetch(postUrl).then(data => {
        console.log(data);

        titleEl.textContent = data.title;

        bodyElList.textContent = data.body;
        
        ffetch(commentsUrl).then(data => {
            if (data) {
                console.log(data);
                Object.keys(data).forEach(k => {
                    const li = document.createElement('li');
                    li.textContent = data[k].text;
                    commentsList.appendChild(li);
                });
            } else {
                while (commentsList.children.length > 0) {
                    commentsList.children[0].remove();
                }
            }
        })
    });
}

function el(type, content, attributes) {
	const result = document.createElement(type);
	
    if (attributes !== undefined) {
        Object.assign(result, attributes);
    }

    if (Array.isArray(content)) {
        content.forEach(append);
    } else {
        append(content);
    }

    function append(node) {
        if (typeof node === 'string') {
            node = document.createTextNode(node);
        }
        result.appendChild(node);
    }

    return result;
}