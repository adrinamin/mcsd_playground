""" daily coding problem 206

Usage:

    python3 permutation.py

"""

def permutate():
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


def main():
    permutate()


if __name__ == "__main__":
    main()