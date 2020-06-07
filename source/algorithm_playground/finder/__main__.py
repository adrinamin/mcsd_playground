import sys

from finder.numbers_finder import find_addition_of_two_numbers_in_list

def main(string: str, k):
    _listNumbers = list(map(int, string.split(",")))
    _kNumber = int(k)
    res = find_addition_of_two_numbers_in_list(_listNumbers, _kNumber)
    if res:
        print("Your list contains two values which add up to your given value.")
    else:
        print("Two items could not be added up to your given value.")

if __name__ == '__main__':
    main(sys.argv[1], sys.argv[2])