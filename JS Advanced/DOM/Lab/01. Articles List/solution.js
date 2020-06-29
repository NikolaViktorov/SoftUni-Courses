function createArticle() {
	const createTitleInput = document.getElementById('createTitle');
	const createContentInput = document.getElementById('createContent');
	const articleSection = document.getElementById('articles');

	const titleValue = createTitleInput.value;
	const contentValue = createContentInput.value;

	if (!titleValue || !contentValue) {
		return;
	}


	const newArticle = document.createElement('article');
	const articleHeading = document.createElement('h3');
	const articleParagraph = document.createElement('p');

	newArticle.appendChild(articleHeading);
	newArticle.appendChild(articleParagraph);

	articleSection.appendChild(newArticle);

	articleHeading.innerText = titleValue;
	articleParagraph.innerText = contentValue;
	
	createTitleInput.value = '';
	createContentInput.value = '';
}