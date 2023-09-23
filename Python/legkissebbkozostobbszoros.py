from math import gcd

szamok = [20, 6, 8, 7]
lkkt = szamok[0]
for i in szamok[1:]:
    lkkt = lkkt * i // gcd(lkkt, i)
print('A legkissebb kozos tobbszoros:', lkkt)