# sample project for xamarin.forms issue #4706

This is a sample project to demonstrate issue 4706 that occurs in Xamarin.Forms currently as of stable 3.4 version.

[https://github.com/xamarin/Xamarin.Forms/issues/4706](Issue #4706 thread)

The reproduction steps of the issue that I'm experiencing are a little bit more random. We have a recurring issue with this crash on the Samsung Galaxy Tab E running android 6 or android 7. If we run the app with the visual studio mac debugger on this tablet, after about 3 minutes (on average, sometimes longer, sometimes shorter) the MainActivity will get recreated. The OnPause, OnStop, and OnDestroy methods are invoked by the operating system, and then the activity is re-created via OnCreate().

When this happens, if the FormsApplication is registered as a singleton, the crash described in the occurs. Given this, the MainPage is still be replaced like the original comment described via the `LoadApplication(FormsApplication)` call.

I don't have much for reproduction steps beyond this, as it isn't reproducible on all devices. But this particular device, it is reliably occurring given the steps described above. We have seen it happen on other devices as well, it seems to be devices that are older, and therefore have less memory available on the device. But, we haven't been able to reproduce the issue reliably on any device other than the Tab E.

Device Info:
![device info](https://raw.githubusercontent.com/keannan5390/xamarin.forms_issue_4706/master/device_info_1.png "Device Info 1")
![device info](https://raw.githubusercontent.com/keannan5390/xamarin.forms_issue_4706/master/device_info_2.png "Device Info 2")


