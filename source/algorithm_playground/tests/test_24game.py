import unittest
from game24_calc.game24 import search


class Game24Test(unittest.TestCase):

    def test_four_integers_results_in_24(self):
        self.assertTrue(search([5,2,7,8]))
        self.assertTrue(search([1,3,4,5]))

    def test_four_integers_does_not_result_in_24(self):
        self.assertFalse(search([1,3,4,1]))