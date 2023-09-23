# Hegedus Joshua
import math

def prime_factors_lookup(num):
    result = dict()
    prime_factors = []

    while num % 2 == 0:
        prime_factors.append(2)
        num = num / 2
    for i in range(3, int(math.sqrt(num)) + 1, 2):
        while num % i == 0:
            prime_factors.append(int(i))
            num = num / i

    if num > 2:
        prime_factors.append(int(num))

    for prime_factor in prime_factors:
        if prime_factor in result:
            result[prime_factor] += 1
        else:
            result[prime_factor] = 1

    return result


num = int(input("Enter a number to get it's prime factors: "))
print(prime_factors_lookup(num))
