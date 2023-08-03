# Pomodoro Work Timer
### About
Pomodoro Work Timer is a simple Windows application for time tracking and saving statistics locally and securely.

### Functionality
- After stopping timer before time is out, saves only current duration.
- Set work/rest/long rest timer mode.
- Change duration for each mode in settings.
- Check statistic.
- Cycle (work-rest-work) mode.
### Architecture 
- Statistic stored in Data folder in binary files. (one file for one day)
- For notification sound only .wav files.
- App built on MVVM architecture pattern.