""" reorder_list.py module for 

Usage:

    python3 reorder_list.py

"""

import sys

def permutate(list: list, permutation: list):
    """ permutate a fixed array with a given permutation list
    
    Args:

    Returns:
    
    """
    # array = input('please provide a random sequence of elements: ')
    array = ["a","b","c","d"]
    permutation = [1,2,0,3]
    swapped_array = []
    counter = 0
    for i in permutation:
        if counter == i or i in swapped_array:
            counter += 1
            continue
        temp = i
        swap = array[temp]
        sub = array[counter]
        array[temp] = sub
        array[counter] = swap
        swapped_array.append(counter)
        counter += 1
    
    print(array)
