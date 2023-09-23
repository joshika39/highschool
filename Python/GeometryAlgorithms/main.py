import lines  # For the methods with line.
# Incl.:
#   irany(point, point)
#   turn(point, point, point)
#   on_line(point, point, point)
#   metszi(point, point, point, point)

import poly  # For the methods with line.
# Incl.:
#   oldal_hossz(point, point)
#   triangle_area(point, point, point)
#   convex_area(some points)
#   poly_area(some points)
#   find_point(some points)
#   in_polygon(some points)

# To Read in the coordinates


def read(n):
    r = []

    for i in range(1, n + 1):
        print(str(i) + ". pont koordinatai: ")
        ax = int(input("A.x = "))
        ay = int(input("A.y = "))

        r.append((ax, ay))

    return r


# Main part below
# A, B, C, D = read(4)

# print(lines.metszi(A, B, C, D))
# ir = lines.turn(A, B, C)


pts = read(5)
if poly.in_polygon(pts):
    print('benne van')
else:
    print('nincs benne')
