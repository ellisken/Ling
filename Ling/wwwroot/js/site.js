/* Tutorial used to get started with Recorder.js
 * https://addpipe.com/blog/using-recorder-js-to-capture-wav-audio-in-your-html5-web-site/
*/

/* Variables */

// Stream from getUserMedia()
let getUserMediaStream;
// Recorder.js object
let rec;
// MediaStreamAudioSourceNode we will be recording
let input;

// Shim for AudioContext when it's not audio video bridging. Shims allow for backwards compatibility by intercepting API calls and providing a layer of abstraction between a caller and a target.
let AudioContext = window.AudioContext || webkit.AudioContext;
// New audio context that helps us record
let audioContext;

// Grab DOM elements
const $recordButton = $('#recordButton');
const stopButton = document.getElementById("stopButton");
const recordingsList = document.getElementById("recordingsList");

// Attach event listeners
recordButton.addEventListener("click", recordButtonHandler);
stopButton.addEventListener("click", stopRecording);


/* Event handlers */

// Pause, Resume, or Record based on classes on recordButton
function recordButtonHandler() {
    if ($recordButton.hasClass("inProgress")) {
        pauseOrResumeRecording();
    } else {
        startRecording();
    }
}

function startRecording() {
    // If there is a recording in the recordingsList, remove it. This way we keep only one recording in the list at a time.
    $('#recordingsList').empty();

    /*
      getUserMedia() is a promise-based method that prompts the user for permission to use a media input, which produces a MediaStream object with a specified list of a/v tracks. In our case, the stream wil have an audio track.
        https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
    */

    // Set request permissions for only audio
    const constraints = { audio: true, video: false };

    navigator.mediaDevices.getUserMedia(constraints).then((stream) => {
        $recordButton.addClass("inProgress");
        toggleEnabledOnRecordButton();
        stopButton.disabled = false;

        console.log("permissions granted!! i'm in the promise!");

        // Assign our getUserMediaStream global variable to the recorded stream for later use
        getUserMediaStream = stream;

        // AudioContext can be created only after some user interaction
        // https://developers.google.com/web/updates/2017/09/autoplay-policy-changes#webaudio
        audioContext = new AudioContext;

        // Use the stream
        input = audioContext.createMediaStreamSource(stream);

        // Create the Recorder object and configure it to record mono channel sound because dual channel will result in double the file size
        rec = new Recorder(input, { numChannels: 1 });

        // Begin recording
        rec.record();

        // Stop recording after 30 sec
        setTimeout(() => {
            if ($recordButton.hasClass("inProgress")) {
                rec.stop();
                // Append audio html element
                rec.exportWAV(appendAudioElement)
            }
        }, 31000);

        // Set "Record" button text to "Pause"
        $recordButton.html("Pause");

        console.log("recording has started");
    }).catch((err) => {
        // Enable the "Record" button again if the recording fails
        stopButton.disabled = true;
    });
}

// TODO: When styling, the "enabled" class can have an active style... maybe pause icon versus play icon
function toggleEnabledOnRecordButton() {
    if ($recordButton.hasClass("enabled")) {
        $recordButton.removeClass("enabled");
    } else {
        $recordButton.addClass("enabled");
    }
}

// "Pause" or "Resume" a recording
function pauseOrResumeRecording() {
    // Make sure user can stop the recording at any time
    stopButton.disabled = false;

    if (rec.recording) {
        console.log("pause hit on rec.recording =", rec.recording);
        // Pause
        rec.stop();
        // Change UI text of "Pause" button to "Resume"
        $recordButton.html("Resume");
        toggleEnabledOnRecordButton();
    } else {
        console.log("resume hit on rec.recording =", rec.recording);
        // Resume
        rec.record();
        $recordButton.html("Pause");
        toggleEnabledOnRecordButton();
    }
}

// "Stop" button event handler
function stopRecording() {
    console.log("Stop button clicked");

    // Disable the stop button
    stopButton.disabled = true;

    // Reset "Record" button text when recording is stopped
    $recordButton.html("Record");

    // Remove "inProgress" class to show recording is stopped
    $recordButton.removeClass("inProgress");

    // Get Recorder object to stop recording
    rec.stop();

    // Close audio ctx
    rec.context.close();

    // Stop microphone access
    getUserMediaStream.getAudioTracks()[0].stop();

    // Create WAV blob and pass on to createDownloadLink
    rec.exportWAV(appendAudioElement);
}


/* Functions called after audio has been stopped/recorded */

// Cited from Recorder.js tutorial. May be tweaked to our app if necessary.
function appendAudioElement(blob) {
    const url = URL.createObjectURL(blob);

    // Create html elements
    const au = document.createElement('audio');
    const li = document.createElement('div');

    //name of .wav file to use during upload and download (without extendion)
    let filename = new Date().toISOString();

    //add controls to the <audio> element
    au.controls = true;
    au.src = url;

    //add the new audio element to li
    li.appendChild(au);

    // Call function that appends link to upload to server
    appendUploadLinkAndAttachEventListener(blob, filename, li);
}

// Event handler after User clicks "Upload"
// This function will make a POST request to the RecordingController/Create action via XHR
const uploadEventHandler = (e, blob, filename) => {
    //grab selected option from dom, pass to form data
    const languageRegion = $('#languageRegion option:selected').html();

    const xhr = new XMLHttpRequest();
    xhr.onload = function (e) {
        if (this.readyState === 4) {
            var jsonResponse = JSON.parse(xhr.responseText);

            $('#recordingsList').append('<div class="results my-3 p-3 bg-white rounded box-shadow"><h6 class="border-bottom border-gray pb-2 mb-0">Transcription</h6><div class="media text-muted pt-3"><p class="media-body pb-3 mb-0 small lh-125 border-bottom border-gray"><strong class="d-block text-gray-dark">' + jsonResponse.language + '</strong>' + jsonResponse.transcript + '</p></div><small class="d-block text-right mt-3"><a href="#">View Transcripts</a></small></div>');
        }
    };
    const fd = new FormData();
    fd.append("language_region", languageRegion);
    fd.append("audio_data", blob, filename);
    xhr.open("POST", "/Recording/Create", true);
    xhr.send(fd); 
}

// Append upload link unto DOM and attach event listener to trigger upload on "click"
function appendUploadLinkAndAttachEventListener(blob, filename, li) {
    //Create upload link
    const upload = document.createElement('a');
    upload.href = "#";
    upload.className = 'btn btn-lg btn-success';
    upload.innerHTML = "Ling It!";

    // Attach event listener to upload
    upload.addEventListener("click", (e) => uploadEventHandler(e, blob, filename));
    li.appendChild(upload)//add the upload form to li

    // Add the li element to the ol
    recordingsList.appendChild(li);
    //$('#selectLanguageRegion').show();
}
