package AOC2017

import "testing"

func TestDay1_1(t *testing.T) {
	testCases := []struct {
		input  string
		result int
	}{
		{"1122", 3},
		{"1111", 4},
		{"1234", 0},
		{"91212129", 9},
	}
	for _, tC := range testCases {
		t.Run(tC.input, func(t *testing.T) {
			actual := day1_1(tC.input)
			if actual != tC.result {
				t.Errorf("Expected: %d Actual: %d", tC.result, actual)
			}
		})
	}
}

func TestDay1_2(t *testing.T) {
	testCases := []struct {
		input  string
		result int
	}{
		{"1212", 6},
		{"1221", 0},
		{"123425", 4},
		{"123123", 12},
		{"12131415", 4},
	}
	for _, tC := range testCases {
		t.Run(tC.input, func(t *testing.T) {
			actual := day1_2(tC.input)
			if actual != tC.result {
				t.Errorf("Expected: %d Actual: %d", tC.result, actual)
			}
		})
	}
}
