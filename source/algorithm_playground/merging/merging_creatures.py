"""
merging_creatures.py

There are creatures of three colors: red, blue and green (R,B,G).
One power of the creatures are that if they are next to each other
they can merge to a creature of the third color.

It determines the smallest number of the creatures remaining after 
any possible sequence of transformation

Usage:

    python3 merging_creatures.py <List>

Example:
    python3 merging_creatures.py R,G,B,G,B

"""

import sys

def transform_creatues(creatures: list ):
    """ Transforms 2 creatues of colors red, green or blue standing next to each other
    to a new creature of the third color.
    
    Args:
        list: A list of creatures in the following form for example: ['R','G','B']
    
    Returns:
        The remaining number of creatures remaining
    """
    result = len(merge_creatures(creatures))
    return result


def merge_creatures(creatures: list):
    oldlist = creatures

    for i in range(len(oldlist)):

        if (i+1) >= len(oldlist):
            break

        if oldlist[i] == oldlist[i+1]:
            continue

        merged = get_merged_creature(oldlist[i],oldlist[i+1])
        del oldlist[i]
        del oldlist[i]
        oldlist.insert(i, merged)
        merge_creatures(oldlist)
        break

    return oldlist

def get_merged_creature(left: chr, right: chr):
    if left == 'R' and right == 'G' or left == 'G' and right == 'R':
        return 'B'

    if left == 'B' and right == 'G' or left == 'G' and right == 'B':
        return 'R'

    if left == 'R' and right == 'B' or left == 'B' and right == 'R':
        return 'G'


def main(string: str):
    result = transform_creatues(string.split(","))
    print("remaining creatures: ", result)

if __name__ == '__main__':
    main(sys.argv[1])