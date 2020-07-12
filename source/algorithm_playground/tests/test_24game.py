import unittest
from game24_calc.game24 import doNumbersResultIn24


class Game24Test(unittest.TestCase):

    def test_four_integers_results_in_24(self):
        self.assertTrue(doNumbersResultIn24([5,2,7,8]))