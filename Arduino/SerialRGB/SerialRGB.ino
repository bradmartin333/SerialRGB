String KEY[3] = {"R", "G", "B"};
int PIN[4] = {3, 5, 6, 4}; // PIN[4] is LED GND
long LUX[3] = {0, 0, 0}; // PWM to set pin to
int ACTIVE = 0; // Pin lux currently being added up
bool UPDATE = false;

void setup() {
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  establishContact();  // send a byte to establish contact until receiver responds
  Serial.println("LED CONTROLLER CONNECTED");

  for (int i = 0; i < 4; i++)
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
    UPDATE = true;
    int inByte = Serial.read();
    if (inByte == 32)
      ACTIVE++;
    else
      LUX[ACTIVE] += inByte;
  }
  else if (UPDATE)
  {
    for (int i = 0; i < 3; i++)
    {
      if (LUX[i] > 0)
        LUX[i] -= 32;
      Serial.println(KEY[i] + String(LUX[i]));
      analogWrite(PIN[i], LUX[i]);
      LUX[i] = 0;
    }
    ACTIVE = 0;
    UPDATE = false;
  }
  delay(10);
}
