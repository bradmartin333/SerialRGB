# SerialRGB ![Nuget](https://img.shields.io/nuget/v/SerialRGBController) [![CodeFactor](https://www.codefactor.io/repository/github/bradmartin333/serialrgb/badge)](https://www.codefactor.io/repository/github/bradmartin333/serialrgb)
WinForms Arduino RGB Controller

1) Flash an Arduino with the .ino
	- Adjust the PWM Pins accordingly
	- Replace GND pin with GND net on controller if desired
2) Add the NuGet package or [Communication.cs](https://github.com/bradmartin333/SerialRGB/blob/main/SerialRGBController/SerialRGBController/Communication.cs) to WinForms project
3) Follow protocol seen in [SampleForm.cs](https://github.com/bradmartin333/SerialRGB/blob/main/SerialRGBController/SerialRGBSample/SampleForm.cs)
