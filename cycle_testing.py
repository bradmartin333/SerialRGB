#!/usr/bin/python
# -*- coding: utf-8 -*-

import serial
import time
import math
import re
import sys
import os

startTime = time.time()
arduino = serial.Serial(port='COM3', baudrate=9600, timeout=.1)
min = 0
max = 360
deg = int(max / 2)
rev = False
cycles = 1
delay = 0.0125

def compass_to_rgb(h, s=1, v=1):
    h = float(h)
    s = float(s)
    v = float(v)
    h60 = h / 60.0
    h60f = math.floor(h60)
    hi = int(h60f) % 6
    f = h60 - h60f
    p = v * (1 - s)
    q = v * (1 - f * s)
    t = v * (1 - (1 - f) * s)
    (r, g, b) = (0, 0, 0)
    if hi == 0:
        (r, g, b) = (v, t, p)
    elif hi == 1:
        (r, g, b) = (q, v, p)
    elif hi == 2:
        (r, g, b) = (p, v, t)
    elif hi == 3:
        (r, g, b) = (p, q, v)
    elif hi == 4:
        (r, g, b) = (t, p, v)
    elif hi == 5:
        (r, g, b) = (v, p, q)
    return chr(int(r * 127))+chr(int(r * 127))+ \
           chr(int(g * 127))+chr(int(g * 127))+ \
           chr(int(b * 127))+chr(int(b * 127))

def start_comms():
    while True:
        arduino.write(bytes('HELLO', 'utf-8'))
        time.sleep(0.1)   
        if ('LED CONTROLLER CONNECTED' in str(arduino.readline())):
            break

def start_new_cycle():
    global cycles
    global arduino
    arduino.close()
    time.sleep(2)
    arduino = serial.Serial(port='COM3', baudrate=9600, timeout=.1)
    time.sleep(2)
    start_comms()
    cycles += 1

def spin_wheel():
    global min
    global max
    global deg
    global rev
    
    if deg == min:
        start_new_cycle()
        rev = False
    elif deg == max:
        rev = True
        
    if rev:
        deg -= 1
    else:
        deg += 1

os.system('cls')
start_comms()

while True:
    spin_wheel()
    arduino.write(bytes(compass_to_rgb(deg), 'utf-8'))
    time.sleep(delay)
    sys.stdout.write('\rUptime (hrs): {:.3f}\tCycle: {}\tHSL (deg): {:0>3}'.format((time.time()
                     - startTime) / 3600, cycles,  deg))
    sys.stdout.flush()
