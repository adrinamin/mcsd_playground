import unittest
from strobogrammatic_number.strobo_number import find_all_strobogrammatic_numbers

class StroboNumberTest(unittest.TestCase):

    def test_strobo_numbers_with_2_digits_returns_4_numbers(self):
        self.assertEqual(4, len(find_all_strobogrammatic_numbers(2)), " There must be 4 strobogrammatic numbers with 2 digits.")

    def test_strobo_numbers_with_4_digits_returns_20_numbers(self):
        self.assertEqual(20, len(find_all_strobogrammatic_numbers(4))," There must be 20 strobogrammatic numbers with 4 digits.")