""" game24.py module

The 24 game is played as follows:
Your are given a list of four integers, each between 1 and 9, in a fixed order.
By placing operators +,-,* and / between the numbers, and grouping them
with parentheses, determine whether it is possible to reach the value 24.

Usage:

    python3 game24.py <List_of_comma_separated_integer_numbers> 

Example

    python3 game24.py 5,2,7,8

"""
import sys


def doNumbersResultIn24(numbers: list):
    return False


def main(numbers: str):
    _listNumbers = list(map(int, str.split(",")))
    if doNumbersResultIn24(_listNumbers):
        print("Congrats! Your given numbers result in 24!")
    else:
        print("Unfortunately, your given numbers do not result in 24.")


if __name__ == "__main__":
    main(sys.argv[1])