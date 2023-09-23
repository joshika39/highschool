from math import gcd

from pip._vendor.distlib.compat import raw_input

nums = list()
num = raw_input("Enter how many elements you want:")
print('Enter numbers in array: ')
for i in range(int(num)):
    n = raw_input("num :")
    nums.append(int(n))
print('ARRAY: ', nums)
from math import gcd

szamok = [20, 6, 8, 7]
lkkt = szamok[0]
for i in szamok[1:]:
    lkkt = lkkt * i // gcd(lkkt, i)
print('A legkissebb kozos tobbszoros:', lkkt)
