import random
import numpy as np

def get_conversion_list():
    l = list(range(26))
    random.shuffle(l)
    return l

class rotor:

    def __init__(self, conversion_list):
        self.conversion_list = conversion_list
        self.reflect_conversion_list = [0 for i in range(26)]
        for i, v in enumerate(self.conversion_list):
            self.reflect_conversion_list[v] = i

    def get_scrambled_char(self, char, rotate=False, reverse=False):
        scrambled_char = ''
        if reverse:
            scrambled_char = chr(97 + self.reflect_conversion_list[ord(char) - 97])
        else:
            scrambled_char = chr(97 + self.conversion_list[ord(char) - 97])

        if rotate:
            self.rotate()
        return scrambled_char

    def rotate(self):
        self.conversion_list = [i + 1 for i in self.conversion_list]
        self.conversion_list[self.conversion_list.index(26)] = 0

class enigma:

    def __init__(self):
        self.r1 = rotor([12, 17, 19, 5, 7, 16, 23, 20, 22, 13, 1, 25, 11, 3, 4, 10, 8, 14, 6, 2, 0, 18, 21, 15, 24, 9])
        self.r2 = rotor([19, 8, 14, 0, 24, 5, 17, 21, 25, 1, 15, 18, 6, 23, 20, 3, 13, 4, 12, 22, 2, 16, 9, 10, 7, 11])
        self.r3 = rotor([11, 18, 24, 1, 17, 7, 9, 6, 14, 0, 19, 12, 8, 20, 23, 16, 3, 25, 5, 4, 10, 2, 21, 22, 13, 15])

    def get_enigma_char(self, char):
        new_char = self.r1.get_scrambled_char(char, rotate=True)
        return new_char

enigma = enigma()

mystr = input('Input message >>>')
new_str = ''
for i in mystr:
    new_str += str(enigma.get_enigma_char(i))
print(new_str)
