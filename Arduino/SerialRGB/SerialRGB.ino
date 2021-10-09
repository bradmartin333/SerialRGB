int KEY[3] = {82, 71, 66};
int PIN[4] = {3, 5, 6, 4};
long LUX[3] = {0, 0, 0};
bool CMD[3] = {false, false, false};
int ledGnd = 4;

void setup() {
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  establishContact();  // send a byte to establish contact until receiver responds
  Serial.println("LED CONTROLLER CONNECTED");

  for (int i = 0; i < sizeof PIN; i++)
  {
    pinMode(PIN[i], OUTPUT);
    analogWrite(PIN[i], LOW);
  }
}

void establishContact() {
  while (Serial.available() <= 0) {
    Serial.println("CONNECTING...");
    delay(300);
  }
}

void loop() {
  int bytes = Serial.available();
  if (bytes > 0)
  {
    int inByte = Serial.read();
    if (inByte == KEY[0])
      CMD[0] = true;
    else if (inByte == KEY[1])
      CMD[1] = true;
    else if (inByte == KEY[2])
      CMD[2] = true;
    else
    {
      for (int i = 0; i < sizeof CMD; i++)
      {
        if (CMD[i])
          LUX[i] += (long(inByte - '0') * (pow(10, bytes)) + 1) / 10;
      }
    }
  }
  else
  {
    for (int i = 0; i < sizeof CMD; i++)
    {
      if (CMD[i])
      {
        Serial.println(String((char)KEY[i]) + String(LUX[i]));
        analogWrite(PIN[i], LUX[i]);
        LUX[i] = 0;
        CMD[i] = false;
      }
    }
  }
  delay(10);
}
