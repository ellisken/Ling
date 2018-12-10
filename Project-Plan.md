# Project Plan

## Contents
1. [Vision](#vision)
2. [Scope](#scope)
3. [Requirements](#requirements)
4. [User Stories](#user-stories)
5. [Wireframes](#wireframes)
6. [Dataflow Diagram](#dataflow-diagram)
7. [Database Schemas](#database-schema)

## Vision
The app allows anonymous users to record audio clips and send those clips off for analysis to determine which human language the clip is in.

## Scope
* IN:
  - The web app will allow any user to record audio up to 5 seconds long
  - The web app will allow the user to listen to the recorded audio
  - The web app will allow the user to re-record the audio
  - The web app will let the user submit the audio for analysis
  - The web app will display the audio analysis results to the user
  - The web app will allow a user to see a page that lists all past audio files submitted for analysis
  - The page of all past audio files will allow the user to listen to any file and see that file’s associated language
  - The web app will be mobile-first

* OUT:
  - We will not allow users to save any other type of data besides sound clips
  - We will not allow users to register for accounts
  - We will not store any personal identifying information about users
  - We will not be creating a mobile app version

  
### MVP
A page that allows a user to 1) record a snippet, 2) replay that snippet, and 3) submit that snippet to the search function. 
A results page that shows the language name in English, in the original version, and in a romanized version. The results page will also show a list of other possible languages the clip could belong to. 
A page that lists and allows a user to listen to all recordings submitted to the site


### Stretch
  - Include a “guess the language” quiz that would allow users to listen to a clip and guess which language the clip belongs to. 
  - Language detail pages that show the name and a short list of useful phrases.

  

## Requirements
### Functional Requirements
 - The user can record and listen to sound clips
 - The user can submit a sound clip for analysis
 - The web app will display sound clips with their associated languages
 - The web app will allows any user to listen to any previous sound clip

### Non-Functional Requirements
* Usability
  - Intuitive Design: The UI will be designed in a way where users do not have to rely on external or extra instructions to use the web app.
  - Clean & Concise: The UI will be uncluttered and easy to follow and understand.
* Maintainability
  - Code will be as modular and as DRY as possible. Methods will exhibit the single responsibility principle.
  - Naming conventions will be descriptive and specific, so there will be no confusion as to what a variable or class member’s purpose is on first glance.

  
## User Stories
### Web App  
* As a user, I would like to have a page where I can view all past recordings so that I can explore other language clips.
  - Features
    - User can navigate to a "Clips" page
    - User can select a clip and listen to it
    - Information about the clip will be shown, like language and length
  - Acceptance
    - Ensure a user can see all clips
    - Ensure a user can listen to any clip listed
* As a Developer, I want to build out the skeleton of an MVC site with a Home Controller so that I can effectively make use of .NET’s MVC framework.
  - Features
    - Each model will have its own service and controller
    - Each controller's action will correspond to a view
  - Acceptance
    - Ensure that the site's architecture matches MVC 
* As a Developer, I want to use SQL Server as my database so that I can easily save, update, and access site data.
  - Features
    - Admin can perform all basic CRUD operations on each table in the database 
    - Admin can wipe and/or migrate and update the database if needed
  - Acceptance
    - The SQL site is hosted on Azure
    - Basic CRUD operations have been tested
* As a user, I would like to be able to record a sound clip, listen to it, and possibly re-record it before triggering language analysis so that I have moderate control over the sound quality.
  - Features
    - User can record a sound clip up to 5 seconds long
    - User can listen to a clip after recording and re-record
    - User can send the clip off for language analysis
  - Acceptance
    - The user can successfully record and play back a sound clip
    - The user can send a clip off for analysis and see a listing of the results
    
## Wireframes
![wireframe](/Assets/lingwf.PNG)

## Dataflow Diagram
![dataflow](/Assets/DataFlowDiagram.png)

## Database Schema
![DB Schema](/Assets/DBSchema.PNG)

*Description* 
* Language: This table holds the data for each language supported by the app.
* Recording: This table holds the data for each recording submitted to the app.
