""" some basics with numpy

Usage:

    python3 basics.py

"""

import numpy as np


def vector_manipulation():
    myVect = np.array([1,2,3,4])
    myVect2 = np.arange(1,20,2)
    myVect3 = np.array([3,2,4,1], dtype=int)
    
    myVect = myVect + 1
    
    print("Creating a vector with np.array:", myVect)
    print("Creating a vector with np.arange:", myVect2)
    
    print("Are myVect and myVect3 equal?", myVect == myVect3)
    print("Dot product of myVect and myVect3", myVect.dot(myVect3))


def matrix_manipulation():
    myMatrix = np.array([[1,2,3], [4,5,6], [7,8,9]])
    # the matrix class can only do 2d matrixes
    myMatrix2 = np.mat([[1,2,3], [4,5,6], [7,8,9]])
    print("My 3x3 matrix:\n",myMatrix)
    print("My second 3x3 matrix:\n",myMatrix2)
    print("access first element of matrix:", myMatrix[0,0])
    print("access second element of matrix:", myMatrix[1,1])

    print("multiply both matrixes:\n", myMatrix * myMatrix2)
    myMatrixOnes = np.ones([4,4], dtype=int)
    myMatrixOnes2 = np.ones([4,4], dtype=np.bool)

    print(myMatrixOnes)
    print(myMatrixOnes2)


def advanced_matrix_operations():
    arr = np.arange(0,8,1)
    arr = np.array([0,1,2,3,4,5,6,7])
    print(arr)
    arr.reshape(2,2,2)
    print("reshape array to matrix:\n", arr)
    np.transpose(arr)
    print(arr)
    print(np.identity(4))

def main():
    vector_manipulation()
    matrix_manipulation()
    advanced_matrix_operations()


# specially named variable allowing us to detect whether
# a module is run as a script or imported into another module.
# module code is only called once from the importing module.
print(__name__)

# when running as a script, call the main.
if __name__ == "__main__":
    main()
