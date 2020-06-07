import sys

from permutation.reorder_list import permutate

def main(list: str, permutation):
    _list = list(list.split(","))
    _permutation = list(map(int, permutation.split(",")))
    permutate(_list, _permutation)


if __name__ == "__main__":
    main(sys.argv[1], sys.argv[2])