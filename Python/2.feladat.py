# orai feladat --> diophantoszi egyenlet
def diofantosz(a, b):
    if b == 0:
        return [1, 0, a]

    [x1, y1, d] = diofantosz(b, a % b)
    [a, b, c] = [y1, x1 - (a // b) * y1, d]
    return [a, b, c]


result = diofantosz(12, 10)
print("{0}*a + {1}*b = {2}".format(result[0], result[1], result[2]))
