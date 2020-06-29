function solve(nums, criteria) {
    if (criteria === 'asc') {
        return nums.sort((a, b) => a - b);
    } else {
        return nums.sort((a, b) => b - a);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'desc'));