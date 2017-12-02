import pathlib

puzzle_input = pathlib.Path("day1in").read_text()

def day1_1(in_data):
    acc = 0
    for x in range(len(in_data)):
        if in_data[x] == in_data[(x + 1) % len(in_data)]:
            acc += int(in_data[x])
    return acc

assert day1_1("1122") == 3
assert day1_1("1111") == 4
assert day1_1("1234") == 0
assert day1_1("91212129") == 9

print("First puzzle:", day1_1(puzzle_input))

def day1_2(in_data):
    acc = 0
    half_len = int(len(in_data) / 2)
    
    for x in range(len(in_data)):
        if in_data[x] == in_data[(x + half_len) % len(in_data)]:
            acc += int(in_data[x])
    return acc

assert day1_2("1212") == 6
assert day1_2("1221") == 0
assert day1_2("123425") == 4
assert day1_2("123123") == 12
assert day1_2("12131415") == 4

print("Second puzzle:", day1_2(puzzle_input))