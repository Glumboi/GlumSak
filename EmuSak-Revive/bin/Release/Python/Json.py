import json
import requests

url = "https://raw.githubusercontent.com/blawar/titledb/master/US.en.json"#"https://raw.githubusercontent.com/blawar/titledb/master/EE.en.json"
nsuIdFile = "./nsuIds.txt"
param = dict()
resp = requests.get(url = url, params = param)
data = resp.json()

nsuIds = open(nsuIdFile).read().split()

def GetGameNames():
    for i in range(len(nsuIds)):
        print(json.dumps(data[nsuIds[i]]["name"], indent=4))

def GetGameIcons():
    with open('gameIcons.txt', 'w') as the_file:
        for i in range(len(nsuIds)):
            the_file.write(json.dumps(data[nsuIds[i]]["iconUrl"], indent=4)+"\n")
            print(json.dumps(data[nsuIds[i]]["iconUrl"], indent=4))

def GetGameIds():
    with open('gameIds.txt', 'w') as the_file:
        for i in range(len(nsuIds)):
            the_file.write(json.dumps(data[nsuIds[i]]["id"], indent=4)+"\n")
            print(json.dumps(data[nsuIds[i]]["id"], indent=4))

def GetGameCategorys():
    for i in range(len(nsuIds)):
        print(json.dumps(data[nsuIds[i]]["category"], indent=4))

def GetGameIdAndIcon():
    with open('gameIcons_Ids.txt', 'w', encoding='utf8') as the_file:
        for i in range(len(nsuIds)):
            the_file.write(json.dumps(data[nsuIds[i]]["iconUrl"], indent=4)+ " | " + json.dumps(data[nsuIds[i]]["id"], indent=4)+ " | " + json.dumps(data[nsuIds[i]]["name"], indent=4) + "\n")
            print(json.dumps(data[nsuIds[i]]["iconUrl"], indent=4)+" | " + json.dumps(data[nsuIds[i]]["id"], indent=4)+ " | " + json.dumps(data[nsuIds[i]]["name"], indent=4) + "\n")

#GetGameIcons()
#GetGameNames()
#GetGameIds()
#GetGameCategorys()
GetGameIdAndIcon() 
