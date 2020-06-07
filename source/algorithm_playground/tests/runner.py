""" runner.py module for running the test suite

Usage:
    python3 runner.py

"""
import unittest

# looks for all test files in the tests folder
suite = unittest.TestLoader().discover(".","test_*.py")
unittest.TextTestRunner(verbosity=2).run(suite)