import assert = require("assert");

function First(input: string) {
    const lines = input.split("\n");
    const diffs = lines.map(line => {
        const nums = line.split(" ").map(Number);
        return nums.reduce((a, b) => Math.max(a, b))
             - nums.reduce((a, b) => Math.min(a, b));
    });
    return diffs.reduce((a, b) => a + b, 0);
}

assert(First(`5 1 9 5
7 5 3
2 4 6 8`) == 18)
console.log("First tests passed");

function Second(input: string) {
    const lines = input.split("\n");
    let sum = 0;
    lines.forEach(line => {
        const nums = line.split(" ").map(Number);
        nextline: for (let i = 0; i < nums.length; i++) {
            for (let j = i + 1; j < nums.length; j++) {
                // check divisibility both ways
                if(nums[i] % nums[j] == 0) {
                    sum += nums[i] / nums[j];
                    continue nextline;
                } else if(nums[j] % nums[i] == 0) {
                    sum += nums[j] / nums[i];
                    continue nextline;
                }
            }
        }
    });
    return sum;
}

assert(Second(`5 9 2 8
9 4 7 3
3 8 6 5`) == 9)
console.log("Second tests passed");