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

let audioBlob;
// Grab DOM elements

const recordingsList = document.getElementById("recordingsList");




/* Event handlers */

function startRecording() {
    // If there is a recording in the recordingsList, remove it. This way we keep only one recording in the list at a time.
    $('#recordingsList').empty();
    $(".results").toggleClass("d-none", true);


    /*
      getUserMedia() is a promise-based method that prompts the user for permission to use a media input, which produces a MediaStream object with a specified list of a/v tracks. In our case, the stream wil have an audio track.
        https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
    */

    // Set request permissions for only audio
    const constraints = { audio: true, video: false };

    navigator.mediaDevices.getUserMedia(constraints).then((stream) => {
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
            if (rec.recording) {
                stopRecording();
            }
        }, 31000);

        console.log("recording has started");
    }).catch((err) => {
        // Enable the "Record" button again if the recording fails
        $('.outline').toggleClass("pulse", false);
    });
}

// "Stop" button event handler
function stopRecording() {
    console.log("Stop button clicked");

    // Get Recorder object to stop recording
    rec.stop();
    $("#transcribeBtn").toggleClass("d-none", false);

    // Close audio ctx
    rec.context.close();

    // Stop microphone access
    getUserMediaStream.getAudioTracks()[0].stop();

    // Create WAV blob and pass on to createDownloadLink
    rec.exportWAV(appendAudioElement);
}


$(".recordBtn").click(function () {
    RecordToggleButton();
    console.log("Clicked");
});


function RecordToggleButton() {
        if(rec === undefined ||!rec.recording) {
            startRecording();
            $('.outline').toggleClass("pulse", true);
        } else {
            stopRecording();
            $('.outline').toggleClass("pulse", false);
        }
}


/* Functions called after audio has been stopped/recorded */

// Cited from Recorder.js tutorial. May be tweaked to our app if necessary.
function appendAudioElement(blob) {
    audioBlob = blob;

    const url = URL.createObjectURL(blob);

    // Create html elements
    const au = document.createElement('audio');

    //name of .wav file to use during upload and download (without extendion)
    let filename = new Date().toISOString();

    //add controls to the <audio> element
    au.controls = true;
    au.src = url;

    //add the new audio element to li
    recordingsList.appendChild(au);
}

$("#transcribeBtn").click(function () {
    //grab selected option from dom, pass to form data
    const languageRegion = $('#languageRegion option:selected').html();
    $(".loader-wrap").toggleClass("d-none", false);
    $("#transcribeBtn").toggleClass("d-none", true);

    

    const xhr = new XMLHttpRequest();
    xhr.onload = function () {
        if (this.readyState === 4) {
            var jsonResponse = JSON.parse(xhr.responseText);
            $(".loader-wrap").toggleClass("d-none", true);

            $("#result_language").text(jsonResponse.language);
            $("#result_transcript").text(jsonResponse.transcript);

            $(".results").toggleClass("d-none", false);

        }
    };
    const fd = new FormData();
    fd.append("language_region", languageRegion);
    fd.append("audio_data", audioBlob, new Date().toISOString());
    xhr.open("POST", "/Recording/Create", true);
    xhr.send(fd); 

})
