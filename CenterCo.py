import socket

import cv2
from cvzone.HandTrackingModule import HandDetector

#UDP server config
socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAdress = ("127.0.0.1",5052) #localhost


#elde edilen frame boyutları gerekli
height = 480
width = 640


#capture nesnesi yaratılır
cap = cv2.VideoCapture(0)
#cap nesnesi 3-4.param
cap.set(3,width)
cap.set(4,height)

#tek el kontrolu
detector = HandDetector(maxHands=1)

#sürekli veri okunacak capture nesnesinden
while True:
    # bool deger ve okunan frame dondurur
    success,img = cap.read()
    #bulunan el landmarklarını aynı frame üzerine yaz, buldugun elleri aynı sekilde döndür.
    hands ,img = detector.findHands(img)

    data = []
    if hands:
        hand = hands[0]
        centerpoint = hand["center"]
        #print(centerpoint)


        #landmarkList = hand['lmList']
        #print(landmarkList)




        #box = hand['bbox']
        #print(box)
        #handtype = hand["type"]
        #print(handtype)

    #list icinde list kurtul - veri isle -> unity gonder
       # for lm in landmarkList:
            #data.append(lm[0]) #data objeye ekle
            #data.append(height-lm[1])  #opencv origin -> left top  -- unity -> right top
            #data.append(lm[2])
        #socket.sendto(str.encode(str(data)),serverAdress)
        socket.sendto(str.encode(str(centerpoint)),serverAdress)

        #print(data)


    #cv2.imshow("ForestRun_CAM",img)

    flipped = cv2.flip(img,1)
    cv2.imshow("ForestRun_cam",flipped)

    # kapanmaması icin
    cv2.waitKey(1)


