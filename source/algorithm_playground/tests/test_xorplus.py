import unittest
from xorplus.xorplus_checker import check_for_xor_and_plus


class XorPlusCheckerTest(unittest.TestCase):

    def test_Given_7_and_7_returns_8(self):
        result = check_for_xor_and_plus(7,7)
        self.assertEqual(8, result)

    def test_Given_3_and_3_returns_4(self):
        result = check_for_xor_and_plus(3,3)
        self.assertEqual(4, result)

    def test_Given_2_and_3_returns_0(self):
        result = check_for_xor_and_plus(2,3)
        self.assertEqual(0, result)


if __name__ == '__main__':
    unittest.main()