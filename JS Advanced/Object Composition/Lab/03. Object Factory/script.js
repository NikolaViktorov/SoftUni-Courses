function solve(propsStr) {
    const props = JSON.parse(propsStr);
    const concatenate = (a, o) => ({...a, ...o});
    const c = props.reduce(concatenate, {}); 
    
    return c;
}

solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`);