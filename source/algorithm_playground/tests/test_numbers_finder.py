import unittest
import finder.numbers_finder as numbers_finder


class NumbersFinderTest(unittest.TestCase):
    """ tests the numbers_finder.py module

    """

    def setUp(self):
        self.finder = numbers_finder
        self.k_value = 9
    
    def tearDown(self):
        pass

    def test_two_numbers_from_list_add_up_to_k(self):
        list_of_numbers = [15, 20, 0, 6, 3, 5]
        result = self.finder.find_addition_of_two_numbers_in_list(list_of_numbers, self.k_value)
        self.assertTrue(result, "two numbers did not add up to k")

    def test_no_number_adds_up_to_k(self):
        list_of_numbers = [15, 20, 0, 6, 4, 10, 15]
        result = self.finder.find_addition_of_two_numbers_in_list(list_of_numbers, self.k_value)
        self.assertFalse(result)


# for running this test file separately
if __name__ == '__main__':
    unittest.main()