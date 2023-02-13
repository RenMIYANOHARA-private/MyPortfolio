from modules.enigma import enigma
import requests

url = "https://notify-api.line.me/api/notify"
access_token = 'xxxxxx'
headers = {'Authorization': 'Bearer ' + access_token}

enigma = enigma()

count = 0
while(count < 10):
    message = input('Input message >>>')
    enigma_message = ''
    for i in message:
        enigma_message += str(enigma.get(i))
    payload = {'message': enigma_message}
    r = requests.post(url, headers=headers, params=payload,)
    count += 1
