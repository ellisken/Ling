# Ling
Add description

## Planning
[Project Requirements](/Requirements.md)

## Deployed Site
https://lingrecord.azurewebsites.net/

## Usage
Our web app features a clean and easy to follow UI. Our home page shows a microphone icon and a Language Region selection dropdown. A user clicks on the microphone to start recording, and then clicks it again to stop.
![home-page](assets/usage1.JPG)

After capturing a recording, the Transcribe button appears. Clicking on Transcribe will send the recording off for language analysis (the user sees a loading bar animation during the analysis).
![transcribe](assets/usage2.JPG)

After analysis, the results appear below the recording.
![results](assets/usage3.JPG)

Clicking the hamburger menu in the top left corner expands the side navigation bar from which the user can navigate to the Recordings page.
The recordings page lists all captured recordings, and allows the user to browse through and play recordings.
![recordings](assets/usage4.JPG)



## Database Schema
![db-schema](Assets/DBSchema.PNG)

## Tools used
Visual Studio, .NET MVC CORE, Entity Framework, CSS/HTML, SQL database, Azure, Google Cloud Speech API (beta), Bootstrap

## Contributors
* [Tre Cain](https://github.com/trecain)
* [Kendra Ellis](https://github.com/ellisken)
* [Rebecca Hong](https://github.com/rh24)
* [Gui Yazbek](https://github.com/gyazbek)

## License
MIT
