"""
strobo_number.py

For the given length n, find all n-length Strobogrammatic numbers.

Strobogrammatic Number is a number whose numeral is rotationally symmetric so that it appears the same when rotated 180 degrees. 
In other words, Strobogrammatic Number appears the same right-side up and upside down.

Usage:

    python3 strobo_number.py <number_of_digits>

Example:
    python3 strobo_number.py 4

"""
import sys


def find_all_strobogrammatic_numbers(n: int):
    """ Returns all strobogrammatic numbers for a given number of digits.
    
    Args:
        int: number of digits
    
    Returns:
        A list of string with strobogrammatic numbers.
    """
    result = numdef(n, n)
    return result


def numdef(digits: int, length: int):
    if digits == 0: 
        return [""]
    if digits == 1:
        return ["0", "1", "8"]

    result = []
    middles = numdef(digits - 2, length)
    for middle in middles:
        if digits != length:
            result.append("0" + middle + "0")
        result.append("1"+ middle +"1")
        result.append("8"+ middle +"8")
        result.append("6"+ middle +"9")
        result.append("9"+ middle +"6")
    return result

def main(digits: int):
    result = find_all_strobogrammatic_numbers(digits)
    print("number of strobogrammatic numbers: ", len(result))
    print(result)

if __name__ == '__main__':
    main(int(sys.argv[1]))