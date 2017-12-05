package AOC2017

func day1_1(input string) int {
	sum := 0
	for i := range input {
		if input[i] == input[(i+1)%len(input)] {
			sum += int(input[i] - '0')
		}
	}
	return sum
}

func day1_2(input string) int {
	sum := 0
	halfLen := len(input) / 2
	for i := range input {
		if input[i] == input[(i+halfLen)%len(input)] {
			sum += int(input[i] - '0')
		}
	}
	return sum
}
