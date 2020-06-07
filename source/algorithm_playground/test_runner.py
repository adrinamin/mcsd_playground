import unittest
from test_numbers_finder import NumbersFinderTest

"""
running the test
"""
suite = unittest.TestLoader().loadTestsFromTestCase(NumbersFinderTest)
unittest.TextTestRunner(verbosity=2).run(suite)