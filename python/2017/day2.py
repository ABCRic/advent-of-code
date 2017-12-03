import pathlib

puzzle_input = pathlib.Path("day2in").read_text()

def day2_1(in_data):
    def max_diff(elements):
        elements = list(elements)
        return max(elements) - min(elements)
    lines = in_data.split("\n")
    num_lines = [map(int, line.split()) for line in lines]
    values = [max_diff(l) for l in num_lines]
    return sum(values)

assert day2_1("""5 1 9 5
7 5 3
2 4 6 8""") == 18

print("First puzzle:", day2_1(puzzle_input))

def day2_2(in_data):
    # split into array of ints for each line
    lines = in_data.split("\n")
    num_lines = [list(map(int, line.split())) for line in lines]
    total = 0

    for line in num_lines:
        # iterate over line
        for i in range(len(line)):
            line_done = False
            # iterate over other numbers down the line
            for j in range(i + 1, len(line)):
                # check divisibility both ways. If either verify, add to sum and jump to next line
                if line[i] % line[j] == 0:
                    total += line[i] / line[j]
                    line_done = True
                    break
                elif line[j] % line[i] == 0:
                    total += line[j] / line[i];
                    line_done = True
                    break
            if line_done:
                break
    return int(total)

assert day2_2("""5 9 2 8
9 4 7 3
3 8 6 5""") == 9

print("Second puzzle:", day2_2(puzzle_input))