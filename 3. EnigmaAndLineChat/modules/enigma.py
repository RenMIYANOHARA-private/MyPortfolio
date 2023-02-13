import random

def get_conversion_list():
    l = list(range(26))
    random.shuffle(l)
    return l

class scrambler:
    def __init__(self, conversion_list):
        self.conversion_list = conversion_list
        self.reflect_conversion_list = [0 for i in range(26)]
        for i, v in enumerate(self.conversion_list):
            self.reflect_conversion_list[v] = i

    def scramble(self, char, reverse=False):
        scrambled_char = ''
        if reverse:
            scrambled_char = chr(97 + self.reflect_conversion_list[ord(char) - 97])
        else:
            scrambled_char = chr(97 + self.conversion_list[ord(char) - 97])
        return scrambled_char

class rotor(scrambler):
    def __init__(self, conversion_list):
        super().__init__(conversion_list)

    def rotate(self):
        self.conversion_list = [i + 1for i in self.conversion_list]
        self.conversion_list[self.conversion_list.index(26)] = 0

class enigma:
    rotors = {'r1': [12, 17, 19, 5, 7, 16, 23, 20, 22, 13, 1, 25, 11, 3, 4, 10, 8, 14, 6, 2, 0, 18, 21, 15, 24, 9],
              'r2': [19, 8, 14, 0, 24, 5, 17, 21, 25, 1, 15, 18, 6, 23, 20, 3, 13, 4, 12, 22, 2, 16, 9, 10, 7, 11],
              'r3': [11, 18, 24, 1, 17, 7, 9, 6, 14, 0, 19, 12, 8, 20, 23, 16, 3, 25, 5, 4, 10, 2, 21, 22, 13, 15],
              'r4': [13, 14, 4, 0, 17, 18, 9, 15, 2, 5, 6, 7, 23, 10, 20, 22, 25, 24, 1, 3, 21, 19, 8, 16, 11, 12],
              'r5': [10, 12, 6, 9, 2, 5, 20, 21, 22, 0, 16, 24, 8, 4, 11, 25, 23, 18, 17, 19, 1, 3, 13, 7, 14, 15]}

    def __init__(self, rotors=None, plugboard=None):
        if rotors == None:
            rotors = ['r1', 'r2', 'r3']
        if plugboard == None:
            plugboard = [1, 0, 3, 2, 5, 4, 7, 6] + [i for i in range(8, 26)]
        self.plugboard = scrambler(plugboard)
        self.r1 = rotor(self.get_rotor(rotors[0]))
        self.r2 = rotor(self.get_rotor(rotors[1]))
        self.r3 = rotor(self.get_rotor(rotors[2]))
        self.reflector = scrambler([25 - i for i in range(26)])
        self.count_r1 = 0
        self.count_r2 = 0
        self.count_r3 = 0

    def get(self, char):
        char = self.plugboard.scramble(char)
        char = self.r1.scramble(char)
        char = self.r2.scramble(char)
        char = self.r3.scramble(char)
        char = self.reflector.scramble(char)
        char = self.r3.scramble(char, reverse=True)
        char = self.r2.scramble(char, reverse=True)
        char = self.r1.scramble(char, reverse=True)
        char = self.plugboard.scramble(char, reverse=True)
        if self.count_r1 == 26:
            self.r1.rotate()
        if self.count_r2 == 26:
            self.r2.rotate()
        self.r3.rotate()
        self.count_r()
        return char

    def count_r(self):
        self.count_r3 += 1
        if self.count_r3 == 26:
            self.count_r3 = 0
            self.count_r2 += 1
        if self.count_r2 == 26:
            self.count_r2 = 0
            self.count_r1 += 1
        if self.count_r1 == 26:
            self.count_r1 = 0

    def get_rotor(self, id='r1'):
        return self.rotors[id]
