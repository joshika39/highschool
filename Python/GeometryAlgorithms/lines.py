# To check the position of two points (right, left, in line)
def irany(a, b):
    s = a[1] * b[0] - b[1] * a[0]
    if s < 0:
        return -1
    elif s == 0:
        return 0
    else:
        return 1


# To check if the the second section is turning
def turn(a, b, c):
    p = [b[0] - a[0], b[1] - a[1]]
    q = [c[0] - a[0], c[1] - a[1]]
    return irany(p, q)


# To check if one of the points are out of the line
def on_line(a, b, c):
    return turn(a, c, b) == 0 and (a[0] < c[0] < b[0] and a[1] < c[1] < b[1]) or \
           (a[0] > c[0] > b[0] and a[1] > c[1] > b[1])


# To check if the one of the section is intersects with one another
def metszi(a, b, c, d):
    if on_line(a, b, c) or on_line(a, b, d) or on_line(c, d, a) or on_line(c, d, b):
        return True
    if (turn(a, b, c) is not turn(a, b, d)) and (turn(c, d, a) is not turn(c, d, b)):
        return True
    return False
