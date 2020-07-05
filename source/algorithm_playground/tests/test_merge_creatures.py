import unittest
import merging.merging_creatures as merging_creatures

class MergingCreaturesTest(unittest.TestCase):
    """ test merging_creatures.py module
    
    """

    def test_five_creatures_merge_to_one(self):
        list_of_creatures = ['R','G','B','G','B']
        remaining_creatures = merging_creatures.transform_creatues(list_of_creatures)
        self.assertEqual(remaining_creatures, 1, "Remainging creatures are not 1")


    def test_four_creatures_merge_to_one(self):
        list_of_creatures = ['R','G','G','B']
        remaining_creatures = merging_creatures.transform_creatues(list_of_creatures)
        self.assertEqual(remaining_creatures, 1, "Remainging creatures are not 1")


    def test_five_creatures_merge_to_two(self):
        list_of_creatures = ['R','G','R','G']
        remaining_creatures = merging_creatures.transform_creatues(list_of_creatures)
        self.assertEqual(remaining_creatures, 2, "Remainging creatures are not 2")


if __name__ == '__main__':
    unittest.main()