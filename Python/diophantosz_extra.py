# onszorgalom alapjan --> nagyon sok matekos calculator
# 3 valtozot hasznalt, szoval en is megcsinaltam 3 al
def hosszabb_gcd(m, n):
    assert m >= n >= 0 and m + n > 0
    if n == 0:
        d, x, y, = m, 1, 0
    else:
        (d, p, q) = hosszabb_gcd(n, m % n)
        x = q
        y = p - q * (m // n)
    assert m % d == 0 and n % d == 0
    assert d == m * x + n * y
    return d, x, y


def diophantosz(a, b, c):
    if a > b:
        q = hosszabb_gcd(a, b)
        x1 = q[1]
        y1 = q[2]
    else:
        q = hosszabb_gcd(b, a)
        x1 = q[2]
        y1 = q[1]
        assert c % q[0] == 0
        d = q[0]
        p = c / d
        return int(p * x1), int(p * y1)


test1, test2, test3 = 10, 6, 14
if diophantosz(test1, test2, test3) is None:
    print("Not possible")
else:
    num1, num2 = diophantosz(test1, test2, test3)
    print(num1, num2)
