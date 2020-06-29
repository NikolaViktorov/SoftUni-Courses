function growingWord() {
  const p = document.querySelector("#exercise > p");
  let px = 2;
  let colors = {
    "blue" : "green",
    "green" : "red",
    "red" : "blue"
  };
  if (!p.hasAttribute("style")) {
    p.setAttribute("style", `color:blue; font-size: ${px}px`)
  } else {
    let curPx = p.style["font-size"];
    px = curPx.substr(0, curPx.length - 2) * 2;
    let curColor = p.style.color;
    p.setAttribute("style", `color:${colors[curColor]}; font-size: ${px}px`)
  }
}