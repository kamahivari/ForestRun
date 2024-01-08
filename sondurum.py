import cv2
import mediapipe as mp
import pydirectinput

mp_drawing = mp.solutions.drawing_utils
mp_drawing_styles = mp.solutions.drawing_styles
mp_hands = mp.solutions.hands

# Kameradan gelen görüntü üzerinde işlem yapma
cap = cv2.VideoCapture(0)

# Elin başlangıç pozisyonunu kaydetmek için değişkenler
start_x = None
start_y = None

# Hareket takibini başlatmak için bayrak
tracking_started = False

# Hareket eşiği
move_threshold = 0.1

with mp_hands.Hands(
    min_detection_confidence=0.5,
    min_tracking_confidence=0.5) as hands:
  while cap.isOpened():
    success, image = cap.read()
    if not success:
    
      continue

    # Görüntüyü işleme ve el bulma
    image = cv2.cvtColor(cv2.flip(image, 1), cv2.COLOR_BGR2RGB)
    image.flags.writeable = False
    results = hands.process(image)

    # Draw the hand annotations on the image.
    image.flags.writeable = True
    image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
    if results.multi_hand_landmarks:
      for hand_landmarks in results.multi_hand_landmarks:
        # Başparmağın konumunu al
        thumb_tip = hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_TIP]
        index_finger_mcp = hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_MCP]

        # Başparmağın index parmağının MCP (orta eklem noktası) konumundan daha yüksek olup olmadığını kontrol et
        if thumb_tip.y < index_finger_mcp.y:
            if not tracking_started:
                # Başparmağı yukarı hareketi algılandı, hareket takibini başlat
                tracking_started = True
                start_x = thumb_tip.x
                start_y = thumb_tip.y
                print("Thumb up detected, start tracking movement...")
        else:
            tracking_started = False

        if tracking_started:
            # Elin mevcut konumunu al
            current_x = thumb_tip.x
            current_y = thumb_tip.y

            # Elin hareket yönünü belirle
            if abs(current_x - start_x) > move_threshold:
                if current_x < start_x:
                    pydirectinput.press('left')
                    start_x = current_x
                else:
                    pydirectinput.press('right')
                    start_x = current_x

            if abs(current_y - start_y) > move_threshold:
                if current_y > start_y:
                    pydirectinput.press('down')
                    start_y = current_y
                else:
                    pydirectinput.press('space')
                    start_y = current_y

        mp_drawing.draw_landmarks(
            image,
            hand_landmarks,
            mp_hands.HAND_CONNECTIONS,
            mp_drawing_styles.get_default_hand_landmarks_style(),
            mp_drawing_styles.get_default_hand_connections_style())
    
    cv2.imshow('MediaPipe Hands', image)
    if cv2.waitKey(5) & 0xFF == 27:
      break
cap.release()
cv2.destroyAllWindows()