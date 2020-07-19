""" game24.py module

The 24 game is played as follows:
You are given a list of four integers, each between 1 and 9, in a fixed order.
By placing operators +,-,* and / between the numbers, and grouping them
with parentheses, determine whether it is possible to reach the value 24.
Example: 5,2,7,8 => ((5*2)-7)*8

Usage:

    python3 game24.py <List_of_comma_separated_integer_numbers> 

Example

    python3 game24.py 5,2,7,8

"""
import sys


# C++ example: https://helloacm.com/the-24-game-algorithm-using-depth-first-search/
# trimming binary search tree: https://helloacm.com/how-to-trim-a-binary-search-tree-using-dfs-recursion/
def search(numbers: list):
    """The algorithm will bruteforce all pairs of the numbers in the vector, 
    and apply four operators on these two numbers,
    
    Args:
        numbers: list of numbers. 4 integers max.
    
    """
    if len(numbers) == 0:
        return False
    if len(numbers) == 1:
        return abs(numbers[0]-24) < 1*10^6

    for i in range(len(numbers)):
        for j in range(len(numbers)):
            if i == j:
                continue
            numbers2 = []
            for k in range(4):
                if k < 2 and j > i:
                    continue
                if k == 0:
                    numbers2.append(numbers[i] + numbers[j])        
                if k == 1:
                    numbers2.append(numbers[i] - numbers[j])        
                if k == 2:
                    numbers2.append(numbers[i] * numbers[j])        
                if k == 3:
                    if numbers[j] == 0:
                        continue
                    numbers2.append(numbers[i] / numbers[j])

                if search(numbers2):
                    return True
                numbers2 = []

    return False     


def main(numbers: str):
    _listNumbers = list(map(int, str.split(",")))
    if search(_listNumbers):
        print("Congrats! Your given numbers result in 24!")
    else:
        print("Unfortunately, your given numbers do not result in 24.")


if __name__ == "__main__":
    main(sys.argv[1])