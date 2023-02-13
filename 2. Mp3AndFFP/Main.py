# -*- coding: utf-8 -*-
import matplotlib.pyplot as plt
import numpy as np
from pydub import AudioSegment
from pydub.playback import play
import ctypes
import time
import threading

# 参考サイト
# mp3波形のリアルタイムグラフ https://algorithm.joho.info/programming/python/pydub-realtime-graph/
# フーリエ変換および逆変換 https://qiita.com/ZESSU/items/10cb9d62ae1a6f90a0df
# 棒グラフの書き方 https://pythondatascience.plavox.info/matplotlib/%E6%A3%92%E3%82%B0%E3%83%A9%E3%83%95
# 人の声の周波数について http://www.chiyoda-ute.co.jp/data/syaon.html
# グラフの背景色 https://matplotlib.org/stable/api/_as_gen/matplotlib.axes.Axes.set_facecolor.html

fftBarLengthRate = np.ones(20)
fftBarLengthRate[0] = 0.2
for i in range(1, 13):
    fftBarLengthRate[i] = 0.5

def get_sound():
    return AudioSegment.from_file("ワンピース オープニング 5 ココロのちず.mp3", "mp3")

def get_window_length():
    return 4000

def getkey(key):
    return (bool(ctypes.windll.user32.GetAsyncKeyState(key) & 0x8000))

def line000(pos):
    WIDTH = 80
    pl = [(pos) % WIDTH, (pos + 1) % WIDTH, (pos + 2) % WIDTH]
    rettxt = ""
    for i in range(WIDTH):
        if i in pl:
            rettxt += "0"
        else:
            rettxt += "-"
    return (rettxt)

def realtime_graph(t, y, dt=0.01, title=None):
    line, = plt.plot(t, y, "r-", label="y=x")  # (x,y)のプロット
    ax = plt.gca()
    line.set_ydata(y)  # y値を更新
    plt.title(title)  # グラフタイトル
    plt.xlabel("t[s]")  # x軸ラベル
    plt.ylabel("y")  # y軸ラベル
    plt.legend()  # 凡例表示
    plt.ylim(-50000, 50000)
    ax.axes.xaxis.set_visible(False)
    plt.draw()  # グラフの描画
    plt.pause(dt)  # 更新時間間隔
    plt.clf()  # 画面初期化

def realtime_fft_graph(freq, amp, dt=0.01, title=None, type='plot', left=None, devideIdx=None):
    if type == 'plot':
        plt.plot(freq, amp)
        plt.xlim([0, 4000])  # グラフに出力する周波数の範囲[Hz]
        plt.ylim([0, 500])  # グラフに出力する周波数の範囲[Hz]

    if type == 'bar':
        height = np.zeros(20)
        for i in range(20):
            height[i] = max(amp[int(devideIdx[i]): int(devideIdx[i + 1])]) * fftBarLengthRate[i]
        plt.bar(left, height, width=100.0)
        plt.xlim([-100, 4100])  # グラフに出力する周波数の範囲[Hz]
        plt.ylim([0, 1000])  # グラフに出力する周波数の範囲[Hz]

    if type == 'image':
        height = np.zeros(20)
        for i in range(20):
            height[i] = max(amp[int(devideIdx[i]): int(devideIdx[i + 1])])
        ax = plt.gca()
        if sum(height) < 200:
            ax.set_facecolor('lightgreen')
        elif sum(height) < 2000:
            ax.set_facecolor('orange')
        else:
            ax.set_facecolor('red')

        # plt.bar([0], [sum(height)], width=100.0)
        plt.xlim([-100, 100])  # グラフに出力する周波数の範囲[Hz]
        plt.ylim([0, 10000])  # グラフに出力する周波数の範囲[Hz]

    plt.title(title)  # グラフタイトル
    plt.xlabel("Frequency[Hz]")
    plt.ylabel("Sound Pressure[-]")
    plt.draw()  # グラフの描画
    plt.pause(dt)  # 更新時間間隔
    plt.clf()  # 画面初期化

def show_sound_wave():
    ESC = 0x1B  # ESCキーの仮想キーコード
    (x, y) = (0, 0)  # 初期値
    frame = 0
    plt.ion()  # 対話モードオン

    # 音声ファイルの読み込み
    sound = get_sound()
    allTime = sound.duration_seconds  # 再生時間(秒)
    rate = sound.frame_rate  # サンプリングレート(Hz)
    channel = sound.channels  # チャンネル数(1:mono, 2:stereo)

    # 音声データをリストで抽出
    list_sound = sound.get_array_of_samples()
    y = np.array(list_sound)
    allNumFrame = len(y)
    t = np.linspace(0, allTime, allNumFrame)
    startTime = time.time()

    while (True):
        realtime_graph(t[frame:500 + frame], y[frame:500 + frame], 1/30, '{: .2f} sec'.format(t[frame]))
        frame = int(allNumFrame * (time.time() - startTime) / allTime)
        if getkey(ESC) or (frame + 500) > allNumFrame:  # ESCキーが押されたら終了
            break

    plt.close()

def show_sound_fft():
    ESC = 0x1B  # ESCキーの仮想キーコード
    (x, y) = (0, 0)  # 初期値
    frame = 0
    plt.ion()  # 対話モードオン

    # 音声ファイルの読み込み
    sound = get_sound()
    allTime = sound.duration_seconds  # 再生時間(秒)
    rate = sound.frame_rate  # サンプリングレート(Hz)
    channel = sound.channels  # チャンネル数(1:mono, 2:stereo)

    # 音声データをリストで抽出
    list_sound = sound.get_array_of_samples()
    y = np.array(list_sound)
    allNumFrame = len(y)
    t = np.linspace(0, allTime, allNumFrame)
    startTime = time.time()

    freq = np.fft.fftfreq(get_window_length(), 1.0 / sound.frame_rate)
    freq = freq[:int(get_window_length() / 2)]
    devideIdx = np.linspace(0, len(freq[freq < 4000]), 21)

    left = np.linspace(0, 4000, 21)
    left = left[:-1]

    while (True):
        spec = np.fft.fft(y[frame:get_window_length() + frame])  # 2次元配列(実部，虚部)
        realtime_fft_graph(freq, np.abs(spec[:int(get_window_length() / 2)]) / 10000, dt=1/30,
                           title='{: .2f} sec'.format(t[frame]), type='bar',
                           left=left, devideIdx=devideIdx)
        frame = int(allNumFrame * (time.time() - startTime) / allTime)
        if getkey(ESC) or (frame + get_window_length()) > allNumFrame:  # ESCキーが押されたら終了
            break

    plt.close()

def play_sound():
    sound = get_sound()
    play(sound)

if __name__ == '__main__':
    # thread_1 = threading.Thread(target=show_sound_wave)
    thread_2 = threading.Thread(target=play_sound)
    thread_3 = threading.Thread(target=show_sound_fft)

    # thread_1.start()
    thread_2.start()
    thread_3.start()
