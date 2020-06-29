function getArticleGenerator(articles) {
    const div = document.querySelector('#content');
    let cur = 0;

    return () => {
        const p = document.createElement('article');
        if(articles[cur]) {
            p.innerText = articles[cur++] ? articles[cur-1] : '';
            div.appendChild(p); 
        }
        return;
    }
}
