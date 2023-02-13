import random


def get_conversion_list():
    l = list(range(26))
    random.shuffle(l)
    return l

class scrambler:

    def __init__(self):
        self.conversion_list = [16, 22, 13, 24, 15, 6, 1, 7, 0, 2, 8, 23, 10,
                                19, 14, 11, 5, 21, 18, 12, 17, 3, 25, 20, 9, 4]

    def get_scrambled_char(self, char):
        scrambled_char = chr(97 + self.conversion_list[ord(char) - 97])
        return scrambled_char
