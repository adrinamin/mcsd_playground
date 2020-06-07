import unittest
import permutation.reorder_list as reorder_list


class ReorderListTest(unittest.TestCase):

    def test_permutate_array(self):
        _random_char = ["a", "b", "c", "d"]
        _permutation = [1,3,2,4]
        result = reorder_list.permutate(_random_char, _permutation)
        self.assertEqual(["a", "c", "b", "d"], result)


# for running this test file separately
if __name__ == '__main__':
    unittest.main()