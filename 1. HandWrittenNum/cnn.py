# ペイント
# https://qiita.com/dcm_fukushima/items/75f1bb7204470181a16d

# 画像の重ね方
# https://code.tiblab.net/python/kivy/layout_anchor
# https://niwakomablog.com/kivy-how2use-anchorlayout/

# ラベル・画像の表示・非表示の方法
# https://stackoverflow.com/questions/47387293/how-to-hide-textbox-based-on-checkbox-in-kivy

# PNGの読み込み
# https://intellectual-curiosity.tokyo/2019/07/02/python%E3%81%A7%E7%94%BB%E5%83%8F%E3%82%92%E8%AA%AD%E3%81%BF%E8%BE%BC%E3%82%80%E6%96%B9%E6%B3%95/

# anaconda kivy install
# https://anaconda.org/conda-forge/kivy

# Kivyの画面遷移
# https://qiita.com/mkgask/items/836ec9e22ff81db9818d
# https://qiita.com/mkgask/items/22a9fa9b4cdfcd500b77

from kivy.app import App
from kivy.config import Config
from kivy.properties import StringProperty, ListProperty
from kivy.uix.widget import Widget
from kivy.uix.boxlayout import BoxLayout
from kivy.graphics import Line, Color, Rectangle
from kivy.lang import Builder
from kivy.factory import Factory

# 日本語フォント表示対応
from kivy.core.text import LabelBase, DEFAULT_FONT
from kivy.resources import resource_add_path

from PIL import Image
import numpy as np
import os
from numpy import argmax
from keras.models import model_from_json
from keras.optimizers import Adam

def load_img_as_array(path=None, resize=None, asGray=False):
    if path == None:
        return None

    img = Image.open(path)

    if asGray:
        img = img.convert("L")

    if not asGray:
        img = img.convert("RGB")

    if resize != None:
        img = img.resize((resize[0], resize[1]))

    return np.array(img)

def save_img_as_db(img=None):

    i = 1
    files = os.listdir('db/')
    if len(files) > 0:
        i = int(os.path.splitext(os.path.basename(files[-1]))[0]) + 1
    record = np.array([-1, img])
    filename = str(10000000 + i)[1:]
    np.save('db/' + filename, record)
    return i

def get_record(id='0000001'):
    return np.load('db/' + id + '.npy', allow_pickle=True)

def set_record(record=None, id=1):
    np.save('db/' + str(10000000 + id)[1:], record)

def is_num(s):
    result = False
    for i in range(10):
        result = result | (s == str(i))
    return result

Config.set('graphics', 'width', '1000')
Config.set('graphics', 'height', '500')
Builder.load_file('hand_written_number.kv')
Builder.load_file('db_manage.kv')
resource_add_path('{}\\{}'.format(os.environ['SYSTEMROOT'], 'Fonts'))
LabelBase.register(DEFAULT_FONT, 'MSGOTHIC.ttc')

class DBManage(BoxLayout):
    label = StringProperty()
    record_id = StringProperty()
    label_num_str_list = ListProperty(['', '', '', '', '', '', '', '', '', '', ''])

    def show_record_num_graph(self):
        anc_x = 460
        anc_y = 385
        max_px_size = 480
        interval = 33
        py_size = 10

        label_num_list = [0 for i in range(11)]
        labels = np.empty((0))
        for file in os.listdir('db/'):
            record = np.load('db/' + file, allow_pickle=True)
            labels = np.append(labels, record[0])
        for i, num in enumerate(range(-1, 10)):
            label_num_list[i] = len(labels[labels == num])
            self.label_num_str_list[i] = str(len(labels[labels == num]))

        max_num = max(label_num_list)

        with self.canvas:
            Color(.2, .2, .2)
            Rectangle(pos=(anc_x - 5, anc_y - 10 * interval - 5), size=(max_px_size + 10, interval * 10 + py_size + 10))

        for i, num in enumerate(label_num_list):
            with self.canvas:
                Color(0, 1, 0)
                Rectangle(pos=(anc_x, anc_y - i * interval), size=(max_px_size * num / max_num, py_size))

    def draw_canvas(self):
        anc_x = 100
        anc_y = 350
        px_size = 8

        for i, row in enumerate(self.record[1] / 255):
            for j, val in enumerate(row):
                with self.canvas:
                    Color(val, val, val)
                    Rectangle(pos=(anc_x + j * px_size, anc_y - i * px_size), size=(px_size, px_size))

    def update_record_info(self):
        try:
            self.record = get_record(id=self.record_id)
            self.label = str(self.record[0])
            self.draw_canvas()
        except FileNotFoundError:
            self.record_id = self.old_record_id

    def __init__(self, **kwargs):
        super(DBManage, self).__init__(**kwargs)
        self.record_id = '0000001'
        self.old_record_id = self.record_id
        self.update_record_info()
        self.show_record_num_graph()

    def on_text(self, source):
        if is_num(source):
            self.record[0] = int(source)
            set_record(record=self.record, id=int(self.record_id))
            self.show_record_num_graph()

    def press_next(self):
        self.old_record_id = self.record_id
        self.record_id = str(int(self.record_id) + 1 + 10000000)[1:]
        self.update_record_info()

    def press_back(self):
        self.old_record_id = self.record_id
        self.record_id = str(int(self.record_id) - 1 + 10000000)[1:]
        self.update_record_info()

    def press_max_record(self):
        self.old_record_id = self.record_id
        self.record_id = os.listdir('db/')[-1].replace('.npy', '')
        self.update_record_info()

    def press_min_record(self):
        self.old_record_id = self.record_id
        self.record_id = os.listdir('db/')[0].replace('.npy', '')
        self.update_record_info()


class Paint(Widget):
    result_sentence = StringProperty()
    show_result = StringProperty()
    filename = StringProperty()
    font_size = StringProperty()

    def __init__(self, **kwargs):
        super().__init__(**kwargs)
        self.line_width = 10 # 線の太さ
        self.lines = [] # undo用に線を格納するリスト
        self.in_drawing = False # 描画中か否かを判定
        self.canvas.add(Color(0, 0, 0))
        self.result_sentence = ''
        self.show_result = '0'
        self.filename = 'piko.png'
        self.font_size = '40'

    # クリック中（描画中）の動作
    def on_touch_move(self, touch):
        if self.in_drawing == False:
            if self.pos[0]<touch.x<self.pos[0]+self.size[0] and self.pos[1]<touch.y<self.pos[1]+self.size[1]:
                self.in_drawing = True
                with self.canvas:
                    touch.ud['line'] = Line(points=(touch.x, touch.y), width=self.line_width)
        elif touch.ud:
            if self.pos[0]<touch.x<self.pos[0]+self.size[0] and self.pos[1]<touch.y<self.pos[1]+self.size[1]:
                touch.ud['line'].points += [touch.x, touch.y]

    # クリック終了時の動作
    def on_touch_up(self, touch):
        if self.in_drawing:
            self.lines.append(touch.ud['line'])
            self.in_drawing = False

    # キャンバスを全消しする
    def clear_canvas(self):
        for line in self.lines:
            self.canvas.remove(line)
        self.lines = []
        self.show_result = '0'

    # 「Teach me！」ボタン押下時のイベント
    def press_teach(self):
        self.export_to_png('./image/hand_written.png')

        # TODO ここに手書き数字の識別モデルを組み込む
        self.img = load_img_as_array(path='./image/hand_written.png', resize=[28, 28], asGray=True)
        self.img = 255 - self.img
        i = save_img_as_db(self.img)
        self.img = self.img / 255
        self.img = np.reshape(self.img, (-1, 28, 28, 1))

        # modelの読み込み
        self.json_string = open(os.path.join('./model', 'cnn_model.json')).read()
        self.model = model_from_json(self.json_string)
        self.model.summary()
        self.model.compile(loss='categorical_crossentropy', optimizer=Adam(learning_rate=0.001, beta_1=0.5), metrics=['accuracy'])
        self.model.load_weights(os.path.join('./model', 'cnn_model_weights.hdf5'))

        self.pre = self.model.predict(self.img)
        self.pre = argmax(self.pre, axis=1)

        if self.pre[0] % 3 == 0:
            self.filename = 'nabeatsu.png'
            self.font_size = '120'
        else:
            self.filename = 'piko.png'
            self.font_size = '40'

        self.result_sentence = str(self.pre[0])
        self.show_result = '1'

class MainRoot(BoxLayout):

    handWrittenNumber = None
    dbManage = None

    def __init__(self, **kwargs):
        super(MainRoot, self).__init__(**kwargs)

    def change_hand_written_number(self):
        self.handWrittenNumber = Factory.HandWrittenNumber()
        self.clear_widgets()
        self.add_widget(self.handWrittenNumber)

    def change_db_manage(self):
        self.dbManage = Factory.DBManage()
        self.clear_widgets()
        self.add_widget(self.dbManage)

class MainApp(App):
    def __init__(self, **kwargs):
        super(MainApp, self).__init__(**kwargs)
        self.title = '手書き数字'

if __name__=='__main__':
    MainApp().run()


