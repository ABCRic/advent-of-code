import assert = require("assert");

function First(input: string) {
    let acc = 0;
    for (let i = 0; i < input.length; i++) {
        if(input[i] == input[(i + 1) % input.length])
            acc += Number(input[i]);
    }
    return acc;
}

assert(First("1122") === 3);
assert(First("1111") === 4);
assert(First("1234") === 0);
assert(First("91212129") === 9);
console.log("First tests passed");

function Second(input: string) {
    let acc = 0;
    for (let i = 0; i < input.length; i++) {
        if(input[i] == input[(i + input.length / 2) % input.length])
            acc += Number(input[i]);
    }
    return acc;
}

assert(Second("1212") === 6);
assert(Second("1221") === 0);
assert(Second("123425") === 4);
assert(Second("123123") === 12);
assert(Second("12131415") === 4);
console.log("Second tests passed");