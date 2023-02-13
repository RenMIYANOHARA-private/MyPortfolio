# 参考サイト
# 機械学習の構築 https://note.nkmk.me/python-scikit-learn-svm-mnist/
# データの構築 https://techacademy.jp/magazine/18981
# Confusion matrix https://note.nkmk.me/python-sklearn-confusion-matrix-score/
# Confusion matrixの微調整 https://teratail.com/questions/310989

# CNN https://qiita.com/ha9kberry/items/70310fc82f5386f69024

# フォルダ内ファイルリスト読込 https://weblabo.oscasierra.net/python/python3-beginning-file-list.html
# Numpy読込

# 精度出力 https://pystyle.info/ml-accuracy-precision-recall-f-measure/
# 日付 https://qiita.com/shibainurou/items/0b0f8b0233c45fc163cd

# PythonファイルExe化 https://techacademy.jp/magazine/18963
# BatファイルでExeファイルを実行する方法 https://jj-blues.com/cms/wantto-exeinbatfile/

#必要なライブラリのインポート
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
import numpy as np
from numpy import argmax
import os
import glob
import csv
import pandas as pd
from datetime import datetime
from keras.models import Sequential
from keras.layers.convolutional import Conv2D, MaxPooling2D
from keras.layers.core import Activation, Flatten, Dense, Dropout
from keras.optimizers import Adam
from keras.utils import to_categorical

def get_record(path=None, no=1):

  if not os.path.exists(path):
    return None

  df = pd.read_csv(path)
  if df.empty:
    return None

  if no == -1:
    return np.array(df[df['No'] == max(df['No'])])[0]
  return np.array(df[df['No'] == no])[0]

def set_record(path=None, record=None, mode='w'):
  with open(path, mode, newline='') as file:
    writer = csv.writer(file)
    writer.writerow(record)

def update_model(f1):
  if not os.path.exists('model/current_model_info.csv'):
    model_history = get_record(path='model/model_history.csv')
    header = ['No', 'Execute date', 'Accuracy', 'Precision', 'Recall', 'F1', 'Record_nums', 'Rate_train_test', 'Epochs']
    set_record(path='model/current_model_info.csv', record=header)
    set_record(path='model/current_model_info.csv', record=model_history, mode='a')
    return True

  current_model_info = get_record(path='model/current_model_info.csv', no=-1)
  if current_model_info[5] >= f1:
    return False
  else:
    model_history = get_record(path='model/model_history.csv', no=-1)
    header = ['No', 'Execute date', 'Accuracy', 'Precision', 'Recall', 'F1', 'Record_nums', 'Rate_train_test', 'Epochs']
    set_record(path='model/current_model_info.csv', record=header)
    set_record(path='model/current_model_info.csv', record=model_history, mode='a')
    return True

def write_to_model_history(accuracy, precision, recall, f1, record_nums, rate_train_test, epochs):

  model_history = [1, datetime.now().strftime('%Y%m%d-%H-%M-%S'), accuracy, precision, recall, f1,
                   record_nums, rate_train_test, epochs]

  if not os.path.exists('model/model_history.csv'):
    header = ['No', 'Execute date', 'Accuracy', 'Precision', 'Recall', 'F1', 'Record_nums', 'Rate_train_test', 'Epochs']
    set_record(path='model/model_history.csv', record=header)
    set_record(path='model/model_history.csv', record=model_history, mode='a')
    return

  model_history[0] = int(get_record(path='model/model_history.csv', no=-1)[0]) + 1
  set_record(path='model/model_history.csv', record=model_history, mode='a')

def get_random_index_from_narray(num=10, nplist=None):
  np.random.shuffle(nplist)
  return nplist[:num]

def get_cnn_model(num_classes=10):
  model = Sequential()
  model.add(Conv2D(32, kernel_size=3, padding="same", activation="relu", input_shape=(28, 28, 1)))
  model.add(Conv2D(32, kernel_size=3, activation="relu"))
  model.add(MaxPooling2D(pool_size=(2, 2)))
  model.add(Dropout(0.2))

  model.add(Conv2D(64, kernel_size=3, padding="same", activation="relu"))
  model.add(Conv2D(64, kernel_size=3, activation="relu"))
  model.add(MaxPooling2D(pool_size=(2, 2)))
  model.add(Dropout(0.2))

  model.add(Flatten())
  model.add(Dense(512, activation="relu"))
  model.add(Dropout(0.5))
  model.add(Dense(num_classes))
  model.add(Activation("softmax"))

  optimizer = Adam(learning_rate=0.001)
  model.compile(optimizer=optimizer, loss="categorical_crossentropy", metrics=["accuracy"])

  model.summary()

  return model

def train_model():
  # 学習DBが更新されているかを確認する。
  files = glob.glob('db/*.npy')
  current_model_info = get_record(path='model/current_model_info.csv', no=-1)
  if len(current_model_info) != 0 and len(files) == current_model_info[6]:
    return

  # 使用するテストデータと学習データの数を定義
  epochs = 20
  img_height = 28
  img_width = 28
  rate_train_test = 0.25

  # 学習DBの読込
  images = np.empty((0, img_height, img_width))
  labels = np.empty((0))
  for file in files:
    record = np.load(file, allow_pickle=True)
    if record[0] != -1:
      labels = np.append(labels, record[0])
      images = np.append(images, [record[1]], axis=0)

  # TrainデータとTestデータに分割
  all_record_nums = len(images)
  devided_nums = all_record_nums - int(all_record_nums * rate_train_test)
  train_images = images[:devided_nums]
  train_labels = labels[:devided_nums]
  test_images = images[devided_nums:]
  test_labels = labels[devided_nums:]

  # ラベルのユニークを生成
  label_unique = np.unique(labels)

  # imageデータを正規化
  train_images = train_images / 255
  test_images = test_images / 255

  # imageデータに1次元追加
  train_images = np.reshape(train_images, (-1, 28, 28, 1))
  print(np.shape(train_labels))
  print(np.shape(label_unique))
  train_labels = to_categorical(train_labels, len(label_unique))
  test_images = np.reshape(test_images, (-1, 28, 28, 1))

  # 学習器（人工知能）をトレーニング
  model = get_cnn_model(num_classes=len(label_unique))
  model.fit(train_images, train_labels, verbose=1, epochs=epochs, batch_size=32, validation_split=0.2)

  # どれくらい学習器（人工知能）が優れているかを計算
  pred_labels = model.predict(test_images)
  pred_labels = argmax(pred_labels, axis=1)
  accuracy = accuracy_score(test_labels, pred_labels)
  precision = precision_score(test_labels, pred_labels, average='micro')
  recall = recall_score(test_labels, pred_labels, average='micro')
  f1 = f1_score(test_labels, pred_labels, average='micro')
  write_to_model_history(accuracy, precision, recall, f1, all_record_nums, rate_train_test, epochs)

  # 学習器の保存
  json_string = model.to_json()
  open(os.path.join('./model', 'cnn_model.json'), 'w').write(json_string)
  model.save_weights(os.path.join('./model', 'cnn_model_weights.hdf5'))

if __name__=='__main__':
    train_model()

