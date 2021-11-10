int PIN[4] = {5, 6, 3, 4}; // R G B GND
int incomingByte = 0; // for incoming serial data
int IDX = 0;

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

  for (int i = 0; i < 4; i++)
    pinMode(PIN[i], OUTPUT);
}

void loop() {
  // send data only when you receive data:
  if (Serial.available() > 0) {
    // read the incoming byte:
    incomingByte = Serial.read();
    // say what you got:
    Serial.print(IDX, DEC);
    Serial.print("\t");
    Serial.println(incomingByte, DEC);
    // set pin
    analogWrite(PIN[IDX], incomingByte);
    IDX++;
    // reset indexer
    if (IDX == 3) IDX = 0;
  }
  delay(10);
}
