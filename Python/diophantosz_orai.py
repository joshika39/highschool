# orai feladat --> diophantoszi egyenlet
def diophantosz(a, b):
    if b == 0:
        return [1, 0, a]

    [x1, y1, d] = diophantosz(b, a % b)
    [a, b, c] = [y1, x1 - (a // b) * y1, d]
    return [a, b, c]

print()
eredmeny = diophantosz(10, 5)

print("{0}*a + {1}*b = {2}".format(eredmeny[0], eredmeny[1], eredmeny[2]))
