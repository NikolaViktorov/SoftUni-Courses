function solve() {
  const anchors = Array.from(document.querySelectorAll('a'));
  const counters = anchors.map(a => a.nextElementSibling.innerText.split(' ')[1]);
  const container = document.querySelector("#page1 > .middled");
  container.addEventListener('click', function(e) {
    const target = e.target;
    const parent = e.target.parentElement;
    const notTargetAnchor = target.localName !== 'a';
    const notTargetParentAnchor = (parent && parent.localName !== 'a');
    if (notTargetParentAnchor && notTargetAnchor) {
      return;
    }
    const targetAnchor = notTargetAnchor ? parent : target;
    const counterIndex = anchors.indexOf(targetAnchor);
    if (counterIndex === -1) {
      return;
    }
    counters[counterIndex]++;
    const paragraph = targetAnchor.nextElementSibling;
    paragraph.innerText = `visited ${counters[counterIndex]} times`;
    
  })
}


/*
const list = Array.from(document.getElementsByClassName("link-1"));
  
  if(counters === null) {
    counters = new Array(list.length).fill(0);
  }

  console.log(list);
  list.forEach(e => {
    e.addEventListener('click', event => {
      e.getElementsByTagName("p").innerText = `${2}`;
    })
  })

  console.log(list);
  //TODO...

*/ 