
a = [12, 17, 19, 5, 7, 16, 23, 20, 22, 13, 1, 25, 11, 3, 4, 10, 8, 14, 6, 2, 0, 18, 21, 15, 24, 9]

b = [0 for i in range(26)]
for i, a_i in enumerate(a):
    b[a_i] = i
