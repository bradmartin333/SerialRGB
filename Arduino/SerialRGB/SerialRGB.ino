int PIN[3] = {3, 5, 6}; // R G B

void setup() {
  Serial.begin(9600);
  while (!Serial) {
    ; // Wait for serial port to connect. Needed for native USB port only
  }

  // Send a byte to establish contact until receiver responds
  while (Serial.available() <= 0) {
    Serial.println("CONNECTING...");
    delay(300);
  }
  Serial.println("LED CONTROLLER CONNECTED");

  for (int i = 0; i < 3; i++)
    pinMode(PIN[i], OUTPUT);
}

void loop() {
  //RRGGBB
  if (Serial.available() == 6) {
    byte a = Serial.read();
    byte b = Serial.read();
    int sum = int(a) + int(b);
    Serial.print("R\t");
    Serial.println(sum);
    analogWrite(PIN[0], sum);

    a = Serial.read();
    b = Serial.read();
    sum = int(a) + int(b);
    Serial.print("G\t");
    Serial.println(sum);
    analogWrite(PIN[1], sum);

    a = Serial.read();
    b = Serial.read();
    sum = int(a) + int(b);
    Serial.print("B\t");
    Serial.println(sum);
    analogWrite(PIN[2], sum);
  }
  // Eat up errant serial bytes
  while (Serial.available() > 0) {
    byte discard = Serial.read();
  }
  delay(10);
}
