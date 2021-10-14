import math
testcase = int(input())
while testcase:
    # 1 <= height <= 1000000
    height = int(input())
    # 1 <= length <= 1000000000
    length = int(input())
    # 1 <= distance <= height
    distance = int(input())
    
    # needed variables for equation
    h = height - distance
    s = length / 2
    a = (s**2 - h**2)/(2*h)

    # 1 <= javob <= 1000000000
    if a < 0:
        print("arqon kalta")
    elif a == 0:
        print("0")
    else:
        b = s/a
        print(a*(math.log((b+math.sqrt(b**2 - 4))/2)))
    testcase -= 1