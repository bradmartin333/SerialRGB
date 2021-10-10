int PIN[4] = {3, 5, 6, 4}; // R G B GND

void setup() {
  Serial.begin(115200);
  while (!Serial) 
  {
    ; // Wait for serial port to connect. Needed for native USB port only
  }

  // Send a byte to establish contact until receiver responds
  while (Serial.available() <= 0) 
  {
    Serial.println("CONNECTING...");
    delay(300);
  }
  Serial.println("LED CONTROLLER CONNECTED");

  for (int i = 0; i < 4; i++)
    pinMode(PIN[i], OUTPUT);
}

void loop() {
  if (Serial.available() == 3)
    for (int i = 0; i < 3; i++)
      analogWrite(PIN[i], Serial.read());
  delay(10);
}
