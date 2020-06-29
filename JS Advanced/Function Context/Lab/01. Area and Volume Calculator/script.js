function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};

function solve(area, vol, input) {
    const objects = JSON.parse(input);
    return objects.map(obj => {
        const a = Math.abs(area.call(obj));
        const v = Math.abs(vol.call(obj));
        return {area: a, volume: v};
    });
}


console.log(solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]'));
