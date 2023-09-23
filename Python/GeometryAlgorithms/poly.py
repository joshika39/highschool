import lines
import math


# To calculate the length of a side (section)
def oldal_hossz(a, b):
    return math.sqrt(math.pow((b[0] - a[0]), 2) + math.pow((b[1] - a[1]), 2))


# To calculate the area of the triangle
def triangle_area(a, b, c):
    s = (oldal_hossz(a, b) + oldal_hossz(b, c) + oldal_hossz(a, c)) / 2
    return math.sqrt(s * (s - oldal_hossz(a, b)) * (s - oldal_hossz(b, c)) * (s - oldal_hossz(a, c)))


# To check if the area is convex
def convex_area(pts):
    n = len(pts)
    t = 0
    pts.append(pts[0])
    for i in range(1, n):
        t += triangle_area(pts[0], pts[i], pts[i+1])

    return t


# To calculate the area of the polygon
def poly_area(pts):
    n = len(pts)
    pts.append(pts[0])
    t = 0
    for i in range(0, n):
        t += pts[i][0] * pts[i+1][1]
        t -= pts[i][1] * pts[i+1][0]

    return 1/2*abs(t)


# To find the points of the polygon
def find_point(pts):
    n = len(pts) - 2
    d = pts[n + 1]
    q = [-1000, 1000]
    for i in range(n):
        if pts[i][1] < q[1]:
            q[1] = pts[i][1]

        if d[0] > pts[i][0]:
            if q[0] < pts[i][0]:
                q[0] = pts[i][0]

    q[1] = q[1] - 1
    return q


# To check whether the point is in or not in the polygon
def in_polygon(pts):
    q = find_point(pts)
    if q[0] == 1000:
        return False
    n = len(pts)-1
    d = pts[n]
    counter = 0
    pts[n] = pts[0]
    for i in range(n):
        if lines.metszi(pts[i], pts[i + 1], d, q):
            counter = counter + 1

    return (counter % 2) != 0