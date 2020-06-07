""" 
numbers_finder.py

Given a list of numbers and a number k, return whether any two 
numbers from the list add up to k.

Usage:

    python3 numbers_finder.py <List_of_comma_separated_integer_numbers> <integer_value>

Example:

    python3 numbers_finder.py 1,2,3,4,5,6 9
"""

import sys


def find_addition_of_two_numbers_in_list(list: list, k: int):
    """ Checks whether two numbers from a given list add up to a given value k.

        Args:
            list: A list of integer numbers.
            k: The value which is used for the check.

        Returns:
            True if two numbers from the list add up to k. 
    """
    for item in list:
        for item2 in list:
            if k == item + item2:
                return True
    
    return False


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