""" reorder_list.py module for permutation of any array.

Usage:

    python3 reorder_list.py <random_array> <permutation_array>

"""
import sys


def permutate(array: list, permutation: list):
    """ permutate a fixed array with a given permutation list
    
    Args:
        array: An array of random elements
        permutation: The permutation of the given array

    Returns:
    
    """
    _swapped_array = []
    _counter = 0
    for i in permutation:

        if _counter == i or i in _swapped_array:
            _counter += 1
            continue

        _temp = i-1
        _swap = array[_temp]
        _sub = array[_counter]
        array[_temp] = _sub
        array[_counter] = _swap
        _swapped_array.append(_counter)
        _counter += 1
    
    return array


def main(char_array, permutation):
    """ Runs the permutation for the given parameter
        and prints the returned permutated array
    
    Args:
        array: An array of random elements
        permutation: The permutation of the given array
    
    """
    _list = list(char_array.split(","))
    _permutation = list(map(int, permutation.split(",")))
    _permuatation_array = permutate(_list, _permutation)

    print(_permuatation_array)


if __name__ == "__main__":
    main(sys.argv[1], sys.argv[2])